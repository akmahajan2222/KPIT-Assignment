using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObj;
namespace BUsinessLogic
{
   public class EmployeeBL
   {
       #region Global Object
       private IEmployee _emprepository;
       public EmployeeBL()
       {
           this._emprepository = new EmployeeDL();
       }
       #endregion

       public string Savedata(EmployeeBO emp)
       {
         return _emprepository.AddDatatoDatabase(emp);
           
       }
       public List<MaritalStatus> GetMaritalStatus()
       {
           return _emprepository.GetMaritalStatusListDB();
       }
       public List<EmployeeBO> GetEmployeeList()
       {
           return _emprepository.GetEmployeeListDB();
       }
       public string DeleteRecord(int Id)
       {
           return _emprepository.DeleteRecord(Id);
       }
       public List<BusinessObj.Location> GetLocationList()
       {
           return _emprepository.GetLocationListDB();
       }
    }
}
