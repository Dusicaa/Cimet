using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using JetBrains;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Sajt.BiznisSloj;
using Sajt.BiznisSloj.DTO;
using Sajt.BiznisSloj.Operations;
using Sajt.DataSloj;
using Sajt.Models;
using Sajt.Models.Application;

namespace Sajt.Controllers
{
    public class HomeController : Controller
    {
        private OperationManager _manager = OperationManager.Singleton;

        [HttpGet]
        public ActionResult Index()
        {
            OpSliderBase op = new OpSliderBase();
            var result = _manager.executeOperation(op);
            OpBlogBase opBlog = new OpBlogBase();
            var resultBlog = _manager.executeOperation(opBlog);

            OpRecipesBase opRecipes=new OpRecipesBase();
            var resultrecept= _manager.executeOperation(opRecipes);
            PocetnaViewModel vm = new PocetnaViewModel
            {
                Slider = result.Items[0] as SliderDto,
                Blog=(resultBlog.Items as BlogDto[]).ToList(),
                Recepti = (resultrecept.Items as RecipesDto[]).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult About()
        {

            Operation op = new OpAboutBase();
            var result = _manager.executeOperation(op);
            return View(result.Items as AboutDto[]);
        }

        [HttpGet]
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel e)
        {
            if (ModelState.IsValid)
            {

                //prepare email
                var toAddress = "dusicacakic@gmail.com";
                var fromAddress = e.Email.ToString();
                var subject = "Test enquiry from " + e.Name;
                var message = e.Message.ToString();
                message.AppendLine("Name: " + e.Name + "\n");
                message.AppendLine("Email: " + e.Email + "\n");
                message.AppendLine("Subject: " + e.Subject + "\n\n");
                message.AppendLine(e.Message);

                //start email Thread
                var tEmail = new Thread(() =>
                    SendEmail(toAddress, fromAddress, subject, message));
                tEmail.Start();
               
            }
            return View();


        }       //baca gresku

        
        public void SendEmail(string toAddress, string fromAddress,         //baca gresku
                      string subject, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                {
                    const string email = "dusicacakic@gmail.com";
                    const string password = "password!";

                    var loginInfo = new NetworkCredential(email, password);


                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(new MailAddress(toAddress));
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;

                    try
                    {
                        using (var smtpClient = new SmtpClient(
                                                         "smtp.mail.yahoo.com", 465))
                        {
                            smtpClient.EnableSsl = true;
                            smtpClient.UseDefaultCredentials = false;
                            smtpClient.Credentials = loginInfo;
                            smtpClient.Send(mail);
                        }

                    }

                    finally
                    {
                        //dispose the client
                        mail.Dispose();
                    }

                }
            }
            catch (SmtpFailedRecipientsException ex)
            {
                foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
                {
                    var status = t.StatusCode;
                    if (status == SmtpStatusCode.MailboxBusy ||
                        status == SmtpStatusCode.MailboxUnavailable)
                    {
                        Response.Write("Delivery failed - retrying in 5 seconds.");
                        System.Threading.Thread.Sleep(5000);
                        //resend
                        //smtpClient.Send(message);
                    }
                    else
                    {
                        //Response.Write("Failed to deliver message to {0}",
                        // t.FailedRecipient);
                    }
                }
            }
            catch (SmtpException Se)
            {
                // handle exception here
                Response.Write(Se.ToString());
            }

            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

        }

        public ActionResult Galerija()
        {
            OpGalerijaBase op = new OpGalerijaBase();
            var result = _manager.executeOperation(op);

            GalerijaViewModel vm = new GalerijaViewModel
            {
                Galerija =result.Items[0] as GalleryDto
            };

            return View(vm);
        }
        public ActionResult Recepti()
        {
            OpRecipesBase opRecipes = new OpRecipesBase();
            var resultrecept = _manager.executeOperation(opRecipes);
            PocetnaViewModel vm = new PocetnaViewModel
            {
               
                Recepti = (resultrecept.Items as RecipesDto[]).ToList()
            };


            return View(vm);
        }
        public ActionResult Blog()
        {
            OpBlogBase opBlog = new OpBlogBase();
            var resultBlog = _manager.executeOperation(opBlog);
            PocetnaViewModel vm = new PocetnaViewModel
            {

                Blog = (resultBlog.Items as BlogDto[]).ToList()
            };


            return View(vm);
        }

        public ActionResult Dokumentacija()
        {
            return File("~/Content/Dokumentacija.pdf", "application/pdf", "Dokumentacija2213.pdf");
        }
       

        //[HttpGet]
        //public JsonResult ajax(string id)
        //{
            

        //    //return Json(p, JsonRequestBehavior.AllowGet);
        //}

    }
}