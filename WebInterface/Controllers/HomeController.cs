/*
                          _            _    
                         | |          | |   
 ___ _ __   __ _  ___ ___| | ___   ___| | __
/ __| '_ \ / _` |/ __/ _ \ |/ _ \ / __| |/ /
\__ \ |_) | (_| | (_|  __/ | (_) | (__|   < 
|___/ .__/ \__,_|\___\___|_|\___/ \___|_|\_\
    | |                                     
    |_|		 Easy to Install, Affordable Surveillance System for everyone!
		
									http://spacelock.madetokill.com
									http://spacelock.blogspot.com

Home Controller for SpaceLock's Web Interface based on ASP.NET MVC.

                              Author - Abhishek Mishra (ideamonk@gmail.com)
===========================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebInterface.Models;

namespace WebInterface.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Page for a visitor.
        /// </summary>
        /// <returns>To Login page if Session is not set, else takes them in.</returns>
        public ActionResult Index()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewData["Title"] = "SpaceLock - Home";
                ViewData["atPage"] = "home";

                SpaceLockLSDataContext db = new SpaceLockLSDataContext();
                
                // Last 5 Intrusions
                int i = 0, count=5;
                DateTime d;

                var query = from details in db.intrusions orderby details.int_id descending select details;

                string[] int_ids = new string[count],
                            int_dates = new string[count],
                            int_times = new string[count],
                            int_descs = new string[count];

                foreach (var detail in query)
                {
                    int_ids[i] = detail.int_id.ToString();
                    int_times[i] = detail.int_time.ToString();
                    int_descs[i] = Server.HtmlEncode(detail.int_desc.ToString());

                    d = DateTime.Parse(detail.int_date.ToString());
                    int_dates[i] = d.ToString("D").Split(',')[1] + d.ToString("D").Split(',')[2];
                    i++;

                    if (i >= 5) break;
                }

                ViewData["int_ids"] = int_ids;
                ViewData["int_dates"] = int_dates;
                ViewData["int_times"] = int_times;
                ViewData["int_count"] = i;
                
                // Preset Status
                var status = (from stat in db.camStatus select stat).Single();
                try
                {
                    var preset_info = (from presets in db.presets
                                       where
                                           presets.pre_id == status.pre_id
                                       select presets).Single();

                    ViewData["current_preset"] = preset_info.pre_name;
                }
                catch
                {
                    ViewData["current_preset"] = "<i>no preset loaded</i>";
                }

                ViewData["uptime"] = status.uptime.ToString();
                
                d = DateTime.Parse(status.last_date.ToString());
                ViewData["last_date"] = d.ToString("D").Split(',')[1] + d.ToString("D").Split(',')[2];
                ViewData["last_time"] = status.last_time.ToString();
                ViewData["surveillance"] = status.surveillance;
                
                db.Connection.Close();

                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        /// <summary>
        /// Shows the Logins page to the user
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowLogin()
        {
            ViewData["Title"] = "SpaceLock - Login";
            return View();
        }


        /// <summary>
        /// Validates the user's attempt to login. Shows error messages accordingly
        /// </summary>
        /// <param name="txtUser">Username entered by the user</param>
        /// <param name="txtPass">Password entered by the user</param>
        /// <returns>An appropriate view depending on password</returns>
        public ActionResult DoLogin(string txtUser, string txtPass)
        {
            SpaceLockLSDataContext spacelockDC;
            try
            {
                // Try creating a Data Context
                spacelockDC = new SpaceLockLSDataContext();
            }
            catch
            {
                ViewData["message"] = "Failed to Connect to DB [DataContext failed]!";
                return View("ShowLogin");
            }

            var query =
                from user1 in spacelockDC.users where user1.username == txtUser select user1.password;

            if (query.ToList().Count == 1)
            {
                // There was some password stored for given username in the DB
                if (query.ToArray().Last() == txtPass)
                {
                    // Passwords match
                    Session.Timeout = 60;
                    Session["LoggedIn"] = "True";
                    spacelockDC.Connection.Close();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["message"] = "Wrong Username or Password!";
                }
            }
            else
            {
                // nothing was selected - invalid username
                ViewData["message"] = "Wrong Username or Password!";
            }

            spacelockDC.Connection.Close();
            return View("ShowLogin");
        }


        /// <summary>
        /// Logs out by turning off the session variable
        /// </summary>
        /// <returns>to the Login view with a message</returns>
        public ActionResult DoLogout()
        {
            Session.Remove("LoggedIn");
            Session.Abandon();
            ViewData["message"] = "Logged Out Successfully";
            return RedirectToAction("ShowLogin","Home");
        }

        /// <summary>
        /// Online Help Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Help()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewData["atPage"] = "help";
                ViewData["Title"] = "SpaceLock - Online Help";
                return View("Help");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }
    }
}
