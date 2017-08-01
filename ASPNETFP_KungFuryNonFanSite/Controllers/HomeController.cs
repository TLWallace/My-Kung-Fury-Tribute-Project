using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ASPNETFP_KungFuryNonFanSite.Models;

namespace ASPNETFP_KungFuryNonFanSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Movie()
        {
            ViewBag.Message = "Enjoy the film right here!";

            return View();
        }
        public ActionResult Video()
        {
            ViewBag.Message = "Enjoy the video right here!";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Lazily Pointing A Way...";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Let Us Know Your Thoughts...";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Requestor's Name & E-mail: {0} ({1})</p><p>Requestor's Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("Tango@triosstudent.com"));
                message.CC.Add(new MailAddress("thomas_l_wallace@live.com"));
                //message.Bcc.Add(new MailAddress("Bravo@trios.com"));
                message.From = new MailAddress("Thomas.Wallace@triosstudent.com");
                message.Subject = "Contact Request -- Kung Fury Non-Fan";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "Tango@triosstudent.com",
                        Password = "ahahaaaahyoudidntsaythemagicwoooord"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.office365.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
    }
}