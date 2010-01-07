<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript">
    /*
        Javascript to handle streaming images, redraws on canvas in FF
        in IE changes src attribute for an img.
        author : Abhishek Mishra (ideamonk@gmail.com)
    */
    var fps = 66; // 15fps => 1/15 * 1000 = 66ms delay

    function randomPassword(length) {
        // To prevent browser from showing anything at all from cache
        chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        pass = "";
        for (x = 0; x < length; x++) {
            i = Math.floor(Math.random() * 62);
            pass += chars.charAt(i);
        }
        return pass;
    }

    function draw() {
        // canvas smooth refresh :)
        var can = document.getElementById('canv');
        var ctx = can.getContext('2d');
        var img = new Image();
        img.onload = function() {
            can.width = img.width;
            can.height = img.height;
            ctx.drawImage(img, 0, 0, img.width, img.height);
        }
        img.src = '/Stream/?h=' + randomPassword(5);

        setTimeout("draw()", fps);
    }

    function draw2() {
        // Alternative for buggy canvas support on IE
        document.getElementById("cimg").src = '/Stream/?h=' + randomPassword(5);
        setTimeout("draw2()", fps);
    }

    $(document).ready(function() {
        <% if (Request.Browser.Browser == "IE") {%>
            draw2();
            <% } else { %>
            draw();
            <% } %>
    });
    
</script>

<h2>&nbsp;<br /></h2>
    <div class="leftpane">
    <% if (Request.Browser.Browser == "IE")
       { %>
            <img src="/Stream/" alt="Live Stream" id="cimg"/>
         <%
        }
       else
       {
    %>
        <canvas id="canv" width="320" height="240"></canvas>
    
    <% } %>
        <p>Live View</p>
    </div>
    <div class="rightpane">
        <h2>Activity Report</h2>
        <div class="lastlist">
            <ul>
            <%
                var int_dates = ViewData["int_dates"] as string [];
                var int_ids = ViewData["int_ids"] as string[];
                var int_times = ViewData["int_times"] as string[];

                for (int i = 0; i < (int)ViewData["int_count"]; i++)
                {
            %>
                    <li> 
                        <a href="/Intrusions/View/?int_id=<%= int_ids[i] %>" >
                        Intrusion #<%= int_ids[i]%></a> <small>on <%= int_dates[i]%> at <%= int_times[i]%> </small> 
                    </li>
             <% } %>
            </ul>
        </div>
        <h2>System Status</h2>
        <div class="sysstat">
            <strong>Preset : </strong><%= ViewData["current_preset"] %>
        </div>
        <div class="sysstat">
            <strong>Uptime : </strong><%= ViewData["uptime"] %>
        </div>
        <div class="sysstat">
            <strong>Surveillance : </strong>
            <% if (ViewData["surveillance"] != null)
               {
                   if (int.Parse(ViewData["surveillance"].ToString()) == 1)
                   { %>
                <span class="green">
                    <strong>ON</strong>
                </span>
            <% }
                   else
                   { %>
                <span class="red">
                    <strong>OFF</strong>
                </span>
            <% }
               } else { %>
               <div class="red">Error Getting ViewData for Camera Status</div>
               <%} %>
        </div>
        <div class="sysstat">
            <strong>Last Login : </strong><%= ViewData["last_date"] %> @ <%= ViewData["last_time"] %>
        </div>
    </div>

</asp:Content>
