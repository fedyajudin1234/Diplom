using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practic.Data.Models
{
    public class ApplicationUser: IdentityUser<int>
    {
        //public string Id { get; set; }
        //public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Aim> userAims { get; set; }
    }
}
