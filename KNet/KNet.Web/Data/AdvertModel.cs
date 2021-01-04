using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KNet.Web.Data
{
    public class AdvertModel
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFlagged { get; set; }
    }
}
