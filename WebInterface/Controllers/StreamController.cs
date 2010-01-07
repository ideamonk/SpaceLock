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
using System.Text;
using System.Threading;

namespace WebInterface.Controllers
{
    public class StreamController : Controller
    {
        //
        // GET: /Stream/

        public ActionResult Index()
        {
            string boundary = "----------1234567890";
            
           
            SpaceLockLSDataContext db = new SpaceLockLSDataContext();

            Response.Clear();
            Response.ContentType = "image/jpeg";
              
            var frames = (from f in db.Streams
                          select f).Single(); // sample the first 50 frames

            byte[] frame = frames.frame.ToArray();
                
            Response.BinaryWrite(frame);
            db.Connection.Close();
            return null;
        }

        public ActionResult view()
        {
            return View();
        }

    }
}
