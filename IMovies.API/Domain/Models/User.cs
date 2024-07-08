using Microsoft.AspNetCore.Identity;

namespace IMovies.API.Domain.Models
{
    public class User : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public User() : base() { }
    }
}