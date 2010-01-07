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
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace WebInterface.Controllers
{
    public class ControlController : Controller
    {
        //
        // GET: /Control/
        public ActionResult Index()
        {
            if (Session["LoggedIn"] != null)
            {
                ViewData["Title"] = "SpaceLock - Control";
                ViewData["atPage"] = "control";

                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                // Preset status
                var status = (from stat in db.camStatus select stat).Single();
                var presets = from pre in db.presets  orderby pre.pre_id descending select pre;
                try
                {
                    var preset_info = (from pres in db.presets
                                       where
                                           pres.pre_id == status.pre_id
                                       select pres).Single();

                    ViewData["current_preset"] = "<b>" + preset_info.pre_name + "</b>";
                }
                catch
                {
                    ViewData["current_preset"] = "<i>no preset loaded</i>";
                }


                ViewData["surveillance"] = status.surveillance;

                int count = presets.ToList().Count;
                int[] pre_ids = new int[count];
                string[] pre_names = new string[count];

                int  i = 0;
                foreach (var row in presets)
                {
                    pre_names[i] = row.pre_name;
                    pre_ids[i] = row.pre_id;
                    i++;
                }

                ViewData["pre_ids"] = pre_ids;
                ViewData["pre_names"] = pre_names;
                ViewData["pre_count"] = count;

                return View();
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        /// <summary>
        /// Start the surveillance
        /// </summary>
        public ActionResult Start()
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from status in db.camStatus select status).Single();
                query.surveillance = 1;
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        /// <summary>
        /// Stop the Surveillance
        /// </summary>
        public ActionResult Stop()
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from status in db.camStatus select status).Single();
                query.surveillance = 0;
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        /// <summary>
        /// Loads a predefined camera configuration
        /// </summary>
        public ActionResult Load(string preset_id)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                var query = (from status in db.camStatus select status).Single();
                query.pre_id = int.Parse(preset_id);
                db.SubmitChanges();
                db.Connection.Close();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }


        public ActionResult Delete(string preset_id)
        {
            if (Session["LoggedIn"] != null)
            {
                SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                try
                {
                    var query = (from preset1 in db.presets
                                 where preset1.pre_id == int.Parse(preset_id)
                                 select preset1).Single();

                    db.presets.DeleteOnSubmit(query);
                    db.SubmitChanges();
                }
                catch { return RedirectToAction("Index"); }

                db.Connection.Close();

                return RedirectToAction("Index",Random.Equals(3,10));
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        public ActionResult Save(string preset_name)
        {
            if (Session["LoggedIn"] != null)
            {
                if (preset_name != null && preset_name.Length>0)
                {
                    SpaceLockLSDataContext db = new SpaceLockLSDataContext();

                    var query = (from stat in db.camStatus
                                 select stat).Single();

                    preset mypreset = new preset
                    {
                        pre_name = preset_name,
                        cam_x = query.cam_x,
                        cam_y = query.cam_y,
                        cam_z = query.cam_z,
                    };

                    db.presets.InsertOnSubmit(mypreset);
                    db.SubmitChanges();
                    db.Connection.Close();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }

        public ActionResult Move(string direction)
        {
            if (Session["LoggedIn"] != null)
            {
                IPEndPoint hostep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9080);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                byte[] data = new byte[1024];

                try
                {
                   sock.Connect(hostep);  
                }
                catch
                {
                    ViewData["error"] = "Failed to create sockets...";
                    sock.Close();
                    return View();
                }
                //sock.Receive(data);
                try
                {
                    sock.Send(Encoding.ASCII.GetBytes(direction));
                }
                catch 
                {
                    ViewData["error"] = "Failed to send signal to control module...";
                    sock.Close();
                    return View();
                }
                sock.Close();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ShowLogin","Home");
            }
        }
        
        
        
     }
}
