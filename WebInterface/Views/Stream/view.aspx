<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.3.2.js"></script>
<!--[if IE]><script type="text/javascript" src="../../../Scripts/excanvas.js"></script><![endif]-->

    <title>view</title>
    <script language="javascript">
        function randomPassword(length) {
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            pass = "";
            for (x = 0; x < length; x++) {
                i = Math.floor(Math.random() * 62);
                pass += chars.charAt(i);
            }
            return pass;
        }

        function draw() {

            var can = document.getElementById('canv');
            var ctx = can.getContext('2d');
            var img = new Image();
            img.onload = function() {
                can.width = img.width;
                can.height = img.height;
                ctx.drawImage(img, 0, 0, img.width, img.height);
            }
            img.src = 'http://localhost:27051/Stream/?h=' + randomPassword(5);
            
            setTimeout("draw()", fps);
        }
        function draw2() {

            document.getElementById("cimg").src = 'http://localhost:27051/Stream/?h=' + randomPassword(5);

            setTimeout("draw2()", fps);
        }
    </script>
</head>
<body>
    <div>

<canvas id="canv" width="320" height="240" onclick="draw();"></canvas>
<img src="http://localhost:27051/Stream/" id="cimg"/>
 
    </div>
</body>
</html>
