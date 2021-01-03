using System.ComponentModel.DataAnnotations;

namespace KNet.Web.Data
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
