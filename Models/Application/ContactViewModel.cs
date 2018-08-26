﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sajt.BiznisSloj.DTO;

namespace Sajt.Models.Application
{
    public class ContactViewModel
    {

        [Required]           
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }



    }
}