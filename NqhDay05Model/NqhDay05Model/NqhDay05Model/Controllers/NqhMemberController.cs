using Microsoft.AspNetCore.Mvc;
using NqhDay05Model.Models;

namespace NqhDay05Model.Controllers
{
    public class NqhMemberController : Controller
    {
        static List<NqhMember> members = new List<NqhMember>()
        {
           new NqhMember { MemberId = Guid.NewGuid().ToString(), Username = "alice", Fullname = "Alice Nguyễn", Password = "123456", Email = "alice@gmail.com" },
           new NqhMember { MemberId = Guid.NewGuid().ToString(), Username = "bob", Fullname = "Bob Trần", Password = "234567", Email = "bob@gmail.com" },
           new NqhMember { MemberId = Guid.NewGuid().ToString(), Username = "charlie", Fullname = "Charlie Lê", Password = "345678", Email = "charlie@gmail.com" },
           new NqhMember { MemberId = Guid.NewGuid().ToString(), Username = "daisy", Fullname = "Daisy Phạm", Password = "456789", Email = "daisy@gmail.com" },
           new NqhMember { MemberId = Guid.NewGuid().ToString(), Username = "eric", Fullname = "Eric Vũ", Password = "567890", Email = "eric@gmail.com" }
        };
        public IActionResult Index()
        {
            // scaffolding

            return View(members);
        }
        // get NqhCreate
        public IActionResult NqhCreate()
        {
            return View();
        }

        // POST NqhCreate
        [HttpPost]
        public IActionResult NqhCreate(NqhMember model)
        {
            var member = new NqhMember();
            member.MemberId = Guid.NewGuid().ToString();
            member.Fullname = model.Fullname;
            member.Username = model.Username;
            member.Password = model.Password;
            member.Email = model.Email;

            members.Add(member);
            return RedirectToAction("Index");
        }
        // Get NqhEdit
        [HttpGet]
        public IActionResult NqhEdit(string id)
        {
            var model  = members.Where(x => x.MemberId == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult NqhEdit(string id, NqhMember model)
        {
            members.Where(x => x.MemberId == id).FirstOrDefault().Fullname = model.Fullname;
            members.Where(x => x.MemberId == id).FirstOrDefault().Username = model.Username;
            members.Where(x => x.MemberId == id).FirstOrDefault().Password = model.Password;
            members.Where(x => x.MemberId == id).FirstOrDefault().Email = model.Email;

            return RedirectToAction("Index");
        }

        //Details
        [HttpGet]
        public IActionResult NqhDetails(string id)
        {
            var model = members.Where(x => x.MemberId == id).FirstOrDefault();
            return View(model);
        }
        //Delete 
        [HttpGet]
        public IActionResult NqhDelete(string id)
        {
            var model = members.Where(x => x.MemberId == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public IActionResult NqhDelete(string id, NqhMember model)
        {
            var member = members.FirstOrDefault(x => x.MemberId == id);
            if (member != null);
            {
                members.Remove(member);
            }
            return RedirectToAction("Index");
        }

        public IActionResult NqhGetMember()
        {
            var nqhMember = new NqhMember();
            nqhMember.MemberId = Guid.NewGuid().ToString();
            nqhMember.Username = "nqh";
            nqhMember.Fullname = "Nguyễn Quang Huy";
            nqhMember.Password = "234234";
            nqhMember.Email = "nguyenquanghuy285204@gmail.com";

            ViewBag.nqhMember = nqhMember;

            return View();
        }
        public IActionResult NqhGetMembers()
        {


            return View(members);
        }
    }
}
