using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KNet.API.Models
{
    public class Advert : Entity
    {
        public Guid UserId { get; set; }
        [NotMapped]
        public User User { get; set; }
        public Guid CategoryId { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
