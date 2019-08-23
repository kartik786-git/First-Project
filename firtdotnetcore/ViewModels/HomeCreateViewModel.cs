﻿using firstdotnetcore.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firtdotnetcore.Web.ViewModels
{
    public class HomeCreateViewModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        [Display(Name = "Office Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }
        #region single file upload property
        public IFormFile Photo { get; set; }
        #endregion
        #region multi file upload property
        //public List<IFormFile> Photos { get; set; }
        #endregion

    }
}