using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObj;

namespace DataAccess
{
    public interface IEmployee
    {
        List<MaritalStatus> GetMaritalStatusListDB();
        string AddDatatoDatabase(EmployeeBO emp);
        List<EmployeeBO> GetEmployeeListDB();
        string DeleteRecord(int Id);
        List<BusinessObj.Location> GetLocationListDB();
    }
}
