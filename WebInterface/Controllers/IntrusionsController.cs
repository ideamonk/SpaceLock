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

Intrusion Archives

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
    public class IntrusionsController : Controller
    {
        //
        // GET: /Intrusions/

        public ActionResult Index(string order)
        {
            if (Session["LoggedIn"] != null)
            {
                ViewData["atPage"] = "intrusions";
                ViewData["Title"] = "SpaceLock - Intrusion Archive";
                
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();
                int i=0,count;
                DateTime d;

                var query = from details in db.intrusions orderby details.int_id ascending select details;
                if (order == "1")
                {
                    ViewData["order"] = "0";
                    query = from details in db.intrusions orderby details.int_date select details;
                }
                else
                {
                    ViewData["order"] = "1";
                }

                count = query.ToList().Count;

                string[]    int_ids = new string[count], 
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
                }

                ViewData["int_ids"] = int_ids;
                ViewData["int_dates"] = int_dates;
                ViewData["int_times"] = int_times;
                ViewData["int_descs"] = int_descs;
                ViewData["int_count"] = i;
                db.Connection.Close();
                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        /// <summary>
        /// AJAX update for description in the background.
        /// </summary>
        /// <param name="description"></param>
        /// <returns>a message to be shown through AJAX as status</returns>
        public ActionResult Update(string desc_id,string description)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from details in db.intrusions where details.int_id == int.Parse(desc_id) select details).Single();
                query.int_desc =  description;
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        
        public ActionResult Delete(string desc_id)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();
                var query = (from details in db.intrusions where details.int_id == int.Parse(desc_id) select details).Single();

                db.intrusions.DeleteOnSubmit(query);
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        public ActionResult View(string int_id)
        {
            if (Session["LoggedIn"] != null)
            {
                    // create a player code in view
                ViewData["int_id"] = int_id;
                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        public ActionResult Download(string int_id)
        {
            if (Session["LoggedIn"] != null)
            {
                // create a player code in view
                ViewData["int_id"] = int_id;
                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }
    }
}
