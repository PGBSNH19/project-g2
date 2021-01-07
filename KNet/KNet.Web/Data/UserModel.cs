using System.ComponentModel.DataAnnotations;

namespace KNet.Web.Data
{
    public class UserModel
    {
        public bool IsAuthenticated { get; set; } = false;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
