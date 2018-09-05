using Hard_Task_Evaluation.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace Hard_Task_Evaluation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet, Authorize]
        public ActionResult UserProfile(string id)
        {
            Hard_Task_Evaluation.Models.User user;
            using (var ctx = new ApplicationDbContext())
            {
                if (!string.IsNullOrEmpty(id))
                {
                    user = ctx.Users.Include(x => x.MedicalInfo)
                    .FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    user = ctx.Users.Include(x => x.MedicalInfo)
                    .FirstOrDefault(x => x.Email == User.Identity.Name);
                }
            }
            return View(user);
        }

        [HttpGet, Authorize]
        public ActionResult EditProfile(string id)
        {
            Hard_Task_Evaluation.Models.User user;
            using (var ctx = new ApplicationDbContext())
            {
                if (!string.IsNullOrEmpty(id))
                {
                    user = ctx.Users.Include(x => x.MedicalInfo)
                    .FirstOrDefault(x => x.Id == id);
                }
                else
                {
                    user = ctx.Users.Include(x => x.MedicalInfo)
                    .FirstOrDefault(x => x.Email == User.Identity.Name);
                }
            }
            return View(user);
        }

        [HttpPost, Authorize]
        public ActionResult EditProfile(User user)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (user.MedicalInfo.Id == 0)
                {
                    ctx.Entry(user.MedicalInfo).State = EntityState.Added;
                    ctx.SaveChanges();
                    user.MedicalInfoId = user.MedicalInfo.Id;
                }
                else
                {
                    ctx.Entry(user.MedicalInfo).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
                user.PasswordHash = ctx.Users.Where(x => x.Id == user.Id).Select(x => x.PasswordHash).FirstOrDefault();
                user.SecurityStamp = ctx.Users.Where(x => x.Id == user.Id).Select(x => x.SecurityStamp).FirstOrDefault();
                user.UserName = ctx.Users.Where(x => x.Id == user.Id).Select(x => x.UserName).FirstOrDefault();
                ctx.Entry(user).State = EntityState.Modified;
                ctx.SaveChanges();
                return View("UserProfile", user);
            }
        }
    }
}