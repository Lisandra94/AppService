using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using App.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Models
{
    public class PersonModel
    {
        [Key]
        public int GUID { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
    }
}
