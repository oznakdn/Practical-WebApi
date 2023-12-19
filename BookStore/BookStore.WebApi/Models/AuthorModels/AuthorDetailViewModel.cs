using System;

namespace BookStore.WebApi.Models.AuthorModels
{
    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}