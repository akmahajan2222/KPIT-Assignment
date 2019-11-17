using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObj
{
   public class EmployeeBO
    {
       public int Id { get; set; }
      
       public string Name { get; set; }
       public int? Age { get; set; }
       public string MaritalStatus { get; set; }
       public int MaritalStatusId { get; set; }
       public int? Salary { get; set; }
       public string Location { get; set; }
    }
   public class MaritalStatus
   {
       public int Id { get; set; }
       public string Status { get; set; }
   }
}
