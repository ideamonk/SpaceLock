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


                              Author - Abhishek Mishra (ideamonk@gmail.com)
===========================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebInterface.Models;

namespace WebInterface.Controllers
{
    public class SettingsController : Controller
    {
        //
        // GET: /Settings/

        public ActionResult Index(string message,string msgType)
        {
            if (Session["LoggedIn"] != null)
            {
                ViewData["Title"] = "SpaceLock - Settings";
                ViewData["atPage"] = "config";
                
                if (msgType == "error")
                    ViewData["error"] = message;
                else
                    ViewData["success"] = message;


                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                try
                {
                    var setting =
                        (from set1 in db.settings select set1).Single();

                    if (setting.int_tracking == 1)
                    {
                        ViewData["tracking"] = "on";
                        ViewData["_tracking"] = "off";
                    }
                    else
                    {
                        ViewData["tracking"] = "off";
                        ViewData["_tracking"] = "on";
                    }

                    if (setting.sms_alerts == 1)
                    {
                        ViewData["sms"] = "on";
                        ViewData["_sms"] = "off";
                    }
                    else
                    {
                        ViewData["sms"] = "off";
                        ViewData["_sms"] = "on";
                    }

                    ViewData["lookup"] = setting.lookup_time;
                    ViewData["maxarch"] = setting.archive_max;
                }
                catch
                {
                    ViewData["error"] = "Error retrieving SpaceLock settings";
                }

                db.Connection.Close();

                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        public ActionResult Tracking(string set)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from set1 in db.settings select set1).Single();
                query.int_tracking = int.Parse(set);
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index",Random.Equals(3,10));
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        public ActionResult sms(string set)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from set1 in db.settings select set1).Single();
                query.sms_alerts = int.Parse(set);
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index", Random.Equals(3, 10));
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        public ActionResult LookUp(string set)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from set1 in db.settings select set1).Single();
                query.lookup_time = int.Parse(set);
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index", Random.Equals(3, 10));
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        
        
        public ActionResult ChangePassword(string pwdCurrent, string pwdNew, string pwdRepeat)
        {
            if (Session["LoggedIn"] != null)
            {
               /*
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from set1 in db.settings select set1).Single();
                query.lookup_time = int.Parse(set);
                db.SubmitChanges();
                db.Connection.Close();
                */
                if (pwdNew != pwdRepeat)
                {
                    return RedirectToAction("Index", "Settings",
                        new { message = "The passwords you entered did not match!", msgType = "error" });
                }

                if (pwdNew.Length < 6)
                {
                    return RedirectToAction("Index", "Settings",
                        new { message = "Please enter a password of minimum 6 characters!", msgType = "error" });
                }

                if (pwdNew.Length > 50)
                {
                    return RedirectToAction("Index", "Settings",
                        new { message = "The password is too long. Please enter a password that you can remember.", msgType = "error" });
                }

                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from pass1 in db.users select pass1).Single();

                if (query.password != pwdCurrent)
                {
                    db.Connection.Close();

                    return RedirectToAction("Index", "Settings",
                            new { message = "Please enter the correct current password.", msgType = "error" });
                }

                query.password = pwdNew;
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index", "Settings",
                        new { message = "The password was successfully changed.", msgType = "success" });
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

    }
}
