namespace Web.Bussiness.Models.UserModels
{
    public class RoleModificationModel
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}