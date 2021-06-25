using Web.Bussiness.DTOs;
using Web.Bussiness.Models.UserModels;

namespace Web.Bussiness.Extensions
{
    public static class CreateModelExtension
    {
        public static EditUser CreateThisLayerEditUser(this EditUserModelDto editUserModelDto)
        {
            var editUserModel = new EditUserModel();

            var editUser = editUserModel.HasId(editUserModelDto.Id)
                                        .Called(editUserModelDto.Name)
                                        .HasEmail(editUserModelDto.Email)
                                        .HasPassword(editUserModelDto.Password)
                                        .Build();
            return editUser;
        }
    }
}