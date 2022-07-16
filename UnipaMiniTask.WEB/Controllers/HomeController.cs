using UnipaMiniTask.BLL;
using UnipaMiniTask.CORE;
using UnipaMiniTask.WEB.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnipaMiniTask.WEB.tcNoDogrula;
using System.Net;
using System.Text;

namespace UnipaMiniTask.WEB.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(BLLContext bll) : base(bll)
        {

        }
        public ActionResult Index()
        {
            var students = _bll.studentService.GetAll().ToList();

            var modelHome = new HomeViewModel()
            {
                Students = students,
            };
            return View(modelHome);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Student student, Verification verification)
        {
            long trNo = Convert.ToInt64(student.TR_IdentificationNumber);
            string name = student.Name;
            string surname = student.Surname;
            var bYear = Convert.ToInt32(student.BirthDay.Year);

            tcNoDogrula.KPSPublic tc = new tcNoDogrula.KPSPublic();
            try
            {
                bool control = tc.TCKimlikNoDogrula(trNo, name, surname, bYear);
                if (control)
                {
                    student.IsApproved = true;
                    _bll.studentService.Add(student);
                    _bll.verificationService.Add(verification);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "TC Kimlik bilgileri doğrulanmadı. Lütfen bilgilerinizi kontrol ediniz!";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "TC Kimlik bilgileri doğrulanmadı. Lütfen bilgilerinizi kontrol ediniz!";
                return View();
            }
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index", "Home");
            var result = _bll.studentService.Get(id.Value);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Student student, Verification verification)
        {
            long trNo = Convert.ToInt64(student.TR_IdentificationNumber);
            string name = student.Name;
            string surname = student.Surname;
            var bYear = Convert.ToInt32(student.BirthDay.Year);

            tcNoDogrula.KPSPublic tc = new tcNoDogrula.KPSPublic();
            try
            {
                bool control = tc.TCKimlikNoDogrula(trNo, name, surname, bYear);
                if (control)
                {
                    student.IsApproved = true;
                    _bll.studentService.Update(student);
                    _bll.verificationService.Add(verification);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "TC Kimlik bilgileri doğrulanmadı. Lütfen bilgilerinizi kontrol ediniz!";
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "TC Kimlik bilgileri doğrulanmadı. Lütfen bilgilerinizi kontrol ediniz!";
                return View();
            }
        }
        public ActionResult Remove(int? id)
        {
            if (id != null)
            { 
                _bll.studentService.Delete(id);
                return RedirectToAction("Index","Home");
            }
            else
                return RedirectToAction("Index","Home");
        }
    }
}