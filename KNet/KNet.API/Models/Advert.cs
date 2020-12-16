﻿using System;

namespace KNet.API.Models
{
    public class Advert
    {
        public int UserId { get; set; }
        public string Heading { get; set; }
        public string Content { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
