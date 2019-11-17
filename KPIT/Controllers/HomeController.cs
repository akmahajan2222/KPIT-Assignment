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
            ViewBag.MaritalStatus = _empBL.GetMaritalStatus();
            ViewBag.Message = _empBL.Savedata(emp);
            ModelState.Clear();
            return View();
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