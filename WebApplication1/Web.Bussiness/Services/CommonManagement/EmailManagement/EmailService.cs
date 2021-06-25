using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Web.Bussiness.Constants;
using Web.Bussiness.Models.ServiceModels;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Services.CommonManagement.EmailManagement
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<EmailModel> CreateMailModelAsync(CreateUserModel userModel)
        {
            var mailModel = Task.FromResult(new EmailModel
            {
                Subject = EmailConstants.FromDomain,
                Email = userModel.Email,
                Message = EmailConstants.Text
            });

            return mailModel;
        }

        public async Task SendEmailAsync(EmailModel model)
        {
            var emailMessage = new MimeMessage();

            //Parsing data from app.settings.development.json in a direct style:

            var nameFrom = _configuration["AppParameters:EmailServiceParameters:nameFrom"];
            var emailFrom = _configuration["AppParameters:EmailServiceParameters:emailFrom"];
            var host = _configuration["AppParameters:EmailServiceParameters:host"];
            var port = Int32.Parse(_configuration["AppParameters:EmailServiceParameters:port"]);
            var useSsl = Convert.ToBoolean(_configuration["AppParameters:EmailServiceParameters:useSsl"]);
            var emailTo = _configuration["AppParameters:EmailServiceParameters:emailTo"];
            var password = _configuration["AppParameters:EmailServiceParameters:password"];

            emailMessage.From.Add(new MailboxAddress(nameFrom, emailFrom));
            emailMessage.To.Add(new MailboxAddress("", model.Email));
            emailMessage.Subject = model.Subject;
            emailMessage.Body = new TextPart("Hello, world")
            {
                Text = model.Message
            };

            using var client = new SmtpClient();
            //await client.ConnectAsync(host, port, useSsl);
            await client.ConnectAsync(host,port,true);
            await client.AuthenticateAsync(emailTo, password);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
    }
}