﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessObj
{
   public class EmployeeBO
    {
       public int Id { get; set; }
      [Required]
       public string Name { get; set; }
       [Required]
       [Range(0, 99, ErrorMessage = "Age must be between 0 and 99.")]
       public int? Age { get; set; }
       public string MaritalStatus { get; set; }
       [Required]
       [Display(Name = "Marital Status")]
       public int MaritalStatusId { get; set; }
       [Required]
       [Range(0, 1000000000, ErrorMessage = "Salary must be between 0 and 1000000000.")]
       public int? Salary { get; set; }
       public string Location { get; set; }
       [Required]
       [Display(Name = "Location")]
       public int LocationId { get; set; }
    }
   public class MaritalStatus
   {
       public int Id { get; set; }
       public string Status { get; set; }
   }
   public class Location
   {
       public int LocationId { get; set; }
       public string LocationName { get; set; }
   }
}
