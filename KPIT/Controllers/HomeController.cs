using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObj;
using BUsinessLogic;

namespace KPIT.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        #region GlobalObject
        EmployeeBL _empBL = new EmployeeBL();
        #endregion

        /// <summary>
        /// To display add records view
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRecords()
        {
            ViewBag.MaritalStatus = _empBL.GetMaritalStatus();
            ViewBag.Location = _empBL.GetLocationList();
            return View();
        }

        /// <summary>
        /// To insert  records in database
        /// </summary>
        /// <param name="emp">Employee model</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddRecords(EmployeeBO emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.MaritalStatus = _empBL.GetMaritalStatus();
                    ViewBag.Location = _empBL.GetLocationList();
                    ViewBag.Message = _empBL.Savedata(emp);
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    //var erroneousFields = ModelState.Where(ms => ms.Value.Errors.Any()).ToList();
                    //Dictionary<string, string> Errors = new Dictionary<string, string>();
                    //foreach (var item in erroneousFields)
                    //{
                    //    Errors.Add(item.Key, item.Value.Errors[0].Exception.InnerException.Message);
                    //} 
                    ModelState.AddModelError("Age", "Please enter a Valid age");
                    ModelState.AddModelError("Salary", "Plesase enter a valid value");
                    ViewBag.MaritalStatus = _empBL.GetMaritalStatus();
                    ViewBag.Location = _empBL.GetLocationList();
                    ViewBag.ErrorMessage = _empBL.GeneralErrorMessage();
                    return View(emp);
                }
            }
            catch (Exception ex)
            {

                ViewBag.MaritalStatus = _empBL.GetMaritalStatus();
                ViewBag.Location = _empBL.GetLocationList();
                ViewBag.ErrorMessage = ex.Message.ToString();
                return View(emp);
            }
           
            
        }
        /// <summary>
        /// To show list of employees
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowList()
        {
            return View();
        }
        /// <summary>
        /// Used in displaying data in json format for datatable
        /// </summary>
        /// <returns></returns>
        public JsonResult ShowListJson()
        {
            return Json(new { data = _empBL.GetEmployeeList().ToList() }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To delete a record from employee
        /// </summary>
        /// <param name="Id">Primary Id</param>
        /// <returns></returns>
        public JsonResult Delete(int Id)
        {
            return Json(_empBL.DeleteRecord(Id), JsonRequestBehavior.AllowGet);
        }
    }
}