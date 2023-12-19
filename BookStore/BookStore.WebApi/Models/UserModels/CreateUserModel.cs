namespace BookStore.WebApi.Models.UserModels
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}