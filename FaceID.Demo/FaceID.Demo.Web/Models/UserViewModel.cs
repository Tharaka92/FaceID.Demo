using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceID.Demo.Web.Models
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(Guid id)
        {
            Id = id;
        }

        public UserViewModel(string name, string description, Guid id)
        {
            Name = name;
            Description = description;
            Id = id;
        }

        [StringLength(64)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [StringLength(64)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Url is required")]
        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public double? Confidence { get; set; }
    }
}