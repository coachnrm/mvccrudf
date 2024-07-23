using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvccrudf.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvccrudf.Controllers
{
    public class studentController : Controller
    {
        mycontext my_context;
        public studentController(mycontext my)
        {
            my_context = my;
        }
        public IActionResult Index()
        {
            var fetch = my_context.students.Include(x=>x.Skill).Include(x=>x.Status).ToList();
            return View(fetch);
        }

        public IActionResult addskill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult addskill(skill s)
        {
            my_context.skills.Add(s);
            my_context.SaveChangesAsync();
            ModelState.Clear();
            ViewBag.success="Skill has been added";
            return View();
        }

        public IActionResult addstudent()
        {
            ViewBag.getskill = my_context.skills.ToList();
            ViewBag.getstatus = my_context.statuses.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult addstudent(student s)
        {
            my_context.students.Add(s);
            my_context.SaveChanges();
            ModelState.Clear();
            //return RedirectToAction("addstudent");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            List<skill> skills = my_context.skills.ToList();
            List<status> statuses = my_context.statuses.ToList();
            ViewBag.skills = new SelectList(skills,"id","skillname");
            ViewBag.statuses = new SelectList(statuses,"id","statusname");
            var y = await my_context.students.FirstOrDefaultAsync(x => x.id == id);

            if (y != null)
            {
                var viewModel = new updatestudentviewmodel()
                {
                    id = y.id,
                    studentname = y.studentname,
                    studentphone = y.studentphone,
                    skillid = y.skillid,
                    statusid = y.statusid
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(updatestudentviewmodel model)
        {
            var z = await my_context.students.FindAsync(model.id);

            if (z != null)
            {
                z.studentname = model.studentname;
                z.studentphone = model.studentphone;
                z.skillid = model.skillid;
                z.statusid = model.statusid;

                await my_context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(updatestudentviewmodel model)
        {
            var a = await my_context.students.FindAsync(model.id);

            if (a != null)
            {
                my_context.students.Remove(a);
                await my_context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}