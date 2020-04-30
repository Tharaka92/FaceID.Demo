using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FaceID.Demo.Windows.Azure
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


        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        public Guid Id { get; set; }
        public double? Confidence { get; set; }
    }
}