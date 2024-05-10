using MemberRegistration.Business.Abstract;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.MvcWebUI.Filters;
using MemberRegistration.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberRegistration.MvcWebUI.Controllers
{
    public class MemberController : Controller
    {
        private IMemberService _memberSevice;

        public MemberController(IMemberService memberSevice)
        {
            _memberSevice = memberSevice;
        }

        // GET: Member
        public ActionResult Add()
        {
            return View(new MemberAddViewModel());
        }

        [HttpPost]
        [ExceptionHandler]
        public ActionResult Add(Member member)
        {
            _memberSevice.Add(member);

            return View(new MemberAddViewModel());
        }
    }
}