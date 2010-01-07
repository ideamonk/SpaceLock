using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;

namespace MotionDetection
{
   public partial class Form1 : Form
   {
      private Capture _capture;
      private MotionHistory _motionHistory;
      int i = 1;//this is used as  pic counter.
      int thershold;
      public Form1()
      {
         InitializeComponent();
        
         //try to create the capture
         if (_capture == null)
         {
            try
            {
               _capture = new Capture();
            }
            catch (NullReferenceException excpt)
            {   //show errors if there is any
               MessageBox.Show(excpt.Message);
            }
         }

         if (_capture != null) //if camera capture has been successfully created
         {   
            _motionHistory = new MotionHistory(
                6, //number of images to store in buffer, adjust it to fit your camera's frame rate
                20, //0-255, the amount of pixel intensity change to consider it as motion pixel
                1.0, //in second, the duration of motion history you wants to keep
                0.05, //in second, parameter for cvCalcMotionGradient
                0.5); //in second, parameter for cvCalcMotionGradient

            Application.Idle += new EventHandler(ProcessFrame);
            
         }
      }

      private void ProcessFrame( object sender, EventArgs e)
      {
         using (MemStorage storage = new MemStorage()) //create storage for motion components
         {
            
            Image<Bgr, Byte> image = _capture.QuerySmallFrame().PyrUp();//capturing a frame.
            Image<Bgr, Byte> cloned = image.Clone();//creating a copy of orginal image
            cloned = image.Resize(320, 240);//setting the resolution to 320 x 240
            
            capturedImageBox.Image = image;
           
             //Setting of region of interest
             //x1=get point x1
             // y1=get point y1
             //x2=get point x2
             // y2=get point y2
              //height=y1-y2
              //width=x1-x2
              //arg of rectangle are (x1,y1,width,height)
              


            image.ROI = new System.Drawing.Rectangle(10, 20, 300, 200);


            _motionHistory.Update(image.Convert<Gray, Byte>());//update the motion history

            #region get a copy of the motion mask and enhance its color
            Image<Gray, Byte> motionMask = _motionHistory.Mask;
            double[] minValues, maxValues;
            System.Drawing.Point[] minLoc, maxLoc;
            motionMask.MinMax(out minValues, out maxValues, out minLoc, out maxLoc);
            motionMask._Mul(255.0 / maxValues[0]);
            #endregion
   
            //create the motion image 
            Image<Bgr, Byte> motionImage = new Image<Bgr, byte>(motionMask.Size);
            //display the motion pixels in blue (first channel)
            motionImage[0] = motionMask;
        
            //Threshold to define a motion area, reduce the value to detect smaller motion
            double minArea = 100;

            storage.Clear(); //clear the storage
            Seq<MCvConnectedComp> motionComponents = _motionHistory.GetMotionComponents(storage);

            //iterate through each of the motion component
            foreach (MCvConnectedComp comp in motionComponents)
            {
               //reject the components that have small area;
               if (comp.area < minArea) continue;

               // find the angle and motion pixel count of the specific area
               double angle, motionPixelCount;
               _motionHistory.MotionInfo(comp.rect, out angle, out motionPixelCount);

               //reject the area that contains too few motion
               if (motionPixelCount < comp.area * 0.05) continue;

               //Draw each individual motion in red
               DrawMotion(motionImage, comp.rect, angle, new Bgr(Color.Red));
            }
            
       



            // find and draw the overall motion angle
            double overallAngle, overallMotionPixelCount;
            _motionHistory.MotionInfo(motionMask.ROI, out overallAngle, out overallMotionPixelCount);
            DrawMotion(motionImage, motionMask.ROI, overallAngle, new Bgr(Color.Green));

            //Display the amount of motions found on the current image
            UpdateText(String.Format("Total Motions found: {0}; Motion Pixel count: {1}", motionComponents.Total, overallMotionPixelCount));
             string s1;
             string s2;
             //creating folder--single folder is created with name-motion.you can change name of folder according to you.
             string activeDir = @"d:\";

             //Create a new subfolder under the current active folder
             string newPath = System.IO.Path.Combine(activeDir, "intro123");
             activeDir = @newPath;
             string newPath1 = System.IO.Path.Combine(activeDir, "video");
             string newPath2 = System.IO.Path.Combine(activeDir, "streaming");
             // Create the subfolder
             System.IO.Directory.CreateDirectory(newPath1);
             System.IO.Directory.CreateDirectory(newPath2);
             thershold = 1000;
             
             if (overallMotionPixelCount>thershold)//check minimium threshold for consider motion.
             {
                 

                 s1 = String.Format("d:/intro123/video/{0}.jpg", i);
                 s2 = String.Format("d:/intro123/streaming/{0}.jpg", i);//formatting the string as e:/images/1.jpg etc
                 CvInvoke.cvSaveImage(s1, cloned.Ptr );
                 CvInvoke.cvSaveImage(s2, cloned.Ptr);//saving the image
                 i++;//incrementing the pic counter
                 
             }
                 
            //Display the image of the motion
            motionImageBox.Image = motionImage;

         }
         
      }

      private void UpdateText(String text)
      {
         label3.Text = text;
      }

      private static void DrawMotion(Image<Bgr, Byte> image, System.Drawing.Rectangle motionRegion, double angle, Bgr color)
      {
         float circleRadius = (motionRegion.Width + motionRegion.Height) >> 2;
         Point center = new Point(motionRegion.X + motionRegion.Width >> 1, motionRegion.Y + motionRegion.Height >> 1);
         
         CircleF circle = new CircleF(
            center, 
            circleRadius);

         int xDirection = (int)(Math.Cos(angle * (Math.PI / 180.0)) * circleRadius);
         int yDirection = (int)(Math.Sin(angle * (Math.PI / 180.0)) * circleRadius);
         Point pointOnCircle = new Point(
             center.X + xDirection,
             center.Y - yDirection);
         LineSegment2D line = new LineSegment2D(center, pointOnCircle);

         image.Draw(circle, color, 1);//
         image.Draw(line, color, 2);
         
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {

         if (disposing && (components != null))
         {
            components.Dispose();
         }

         base.Dispose(disposing);
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }

      private void capturedImageBox_Click(object sender, EventArgs e)
      {

      }
   }
}
