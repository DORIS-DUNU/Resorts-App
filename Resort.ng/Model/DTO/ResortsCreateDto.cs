﻿using System.ComponentModel.DataAnnotations;

namespace Resort.ng.Model.DTO
{
    public class ResortsCreateDto
    {
        
       
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public double Rate { get; set; }
        public int Occupancy { get; set; }
        public string  Details{ get; set; }
        public int Sqft { get; set; }

        public string ImageUrl { get; set; }

        public string Amenity { get; set; }
    }
}
