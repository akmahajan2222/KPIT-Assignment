using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessObj;

namespace DataAccess
{
    
    public class EmployeeDL:IEmployee
    {
        #region Global Object
        EmployeeEntities1 _empDB = new EmployeeEntities1();
        #endregion

        public List<MaritalStatus> GetMaritalStatusListDB()
        {
            return _empDB.MaritalStatus.Select(x => new MaritalStatus() { Id = x.Id, Status = x.MaritalStatus }).ToList();   
        }
        public List<BusinessObj.Location> GetLocationListDB()
        {
            return _empDB.Locations.Select(x => new BusinessObj.Location() { LocationId = x.LocationId, LocationName = x.Location1}).ToList();
        }
        public string AddDatatoDatabase(EmployeeBO emp)
        {
            EmployeeData objdata = new EmployeeData()
            {
                Age=emp.Age,
                LocationId=emp.LocationId,
                MaritalStatusId=emp.MaritalStatusId,
                Name=emp.Name,
                Salary=emp.Salary
            };
           _empDB.EmployeeDatas.Add(objdata);
          return _empDB.SaveChanges()==1?"Data Saved Successfully":"Some-Problem Occured";
            
        }

        public List<EmployeeBO> GetEmployeeListDB()
        {
            return _empDB.EmployeeDatas.Select(x => new EmployeeBO() { Name = x.Name, Age = x.Age, Salary = x.Salary, MaritalStatus = _empDB.MaritalStatus.Where(z => z.Id == x.MaritalStatusId).Select(z => z.MaritalStatus).FirstOrDefault(), Location = x.Location.Location1, Id = x.EmpId })
     .ToList();
        }

        public string DeleteRecord(int Id)
        {
            if (_empDB.EmployeeDatas.Where(x => x.EmpId == Id).FirstOrDefault()==null)
            {
                return "Some Problem Occured";
            }
            else
            {
                _empDB.EmployeeDatas.Remove(_empDB.EmployeeDatas.Where(x => x.EmpId == Id).FirstOrDefault());
                _empDB.SaveChanges();
                return "Data Deleted Successfully";
            }
        }
    }
}