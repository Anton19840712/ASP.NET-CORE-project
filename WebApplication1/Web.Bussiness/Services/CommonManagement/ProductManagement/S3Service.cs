using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Web.Bussiness.Services.CommonManagement.ProductManagement
{
    public class S3Service : IS3Service
    {
        private readonly IAmazonS3 _client;
        private readonly IConfiguration _configuration;
        private const double TimeoutDuration = 12;
        public S3Service(IAmazonS3 client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async Task<string> UploadFileAsync(IFormFile fileForUploading)
        {
            var keyName = GetUriForTypeOfPhoto(fileForUploading.FileName);
            
            var filePath = Path.GetTempFileName();

            await using (var stream = System.IO.File.Create(filePath))
            {
                await fileForUploading.CopyToAsync(stream);
            }

            var fileTransferUtility = new TransferUtility(_client);

            await fileTransferUtility.UploadAsync(filePath, _configuration["AWS:directoryLogo"]);

            return keyName;
        }

        private string GetUriForTypeOfPhoto(string keyName)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = _configuration["AWS:directoryLogo"],
                Key = keyName,
                Expires = DateTime.UtcNow.AddHours(TimeoutDuration)
            };

            var fileLink = _client.GetPreSignedURL(request);
            var uri = new Uri(fileLink);
            var fixedUri = uri.AbsoluteUri.Replace(uri.Query, string.Empty);

            return fixedUri;
        }

        public async Task DeleteAwsFileAsync(string file)
        {
            var uri = new Uri(file);
            
            var amazonS3PathAfterBucketName = (uri.AbsolutePath);

            var request = new DeleteObjectRequest();

            request.BucketName = _configuration["AWS:directoryLogo"];

            request.Key = amazonS3PathAfterBucketName;

            await _client.DeleteObjectAsync(request);
        }
    }
}