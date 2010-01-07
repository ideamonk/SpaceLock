<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript">
function delete_preset(number) {
    if (confirm("Are you sure you want to delete this preset ?") == true) {
        location.href = "/Control/Delete/?preset_id="+number;
    }
}

function save() {
    document.getElementById("frm_save").submit();
}    
</script>

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

<h2>&nbsp;Control Center</h2>
<% if (ViewData["error"] != null)
       { %>
        <div class="intError">
            <%= ViewData["error"] %>
        </div>
<% } %>

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
    
        <p>Preset - <%= ViewData["current_preset"] %></p>
        <div class="sysstat">
            <strong>Surveillance Status : </strong>
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
               }
               else 
               { %>
               <div class="red">Error Loading ViewData for Camera Status...</div>
               <%} %>
        </div>
        <br />
        <h2>Surveillance Control</h2>
        <div class="controlbox">
            <a href="/Control/Start/">
                <div class="ctrlButton">Start</div>
            </a>
            <a href="/Control/Stop/">
                <div class="ctrlButton">Stop</div>
            </a>
        </div>
    </div>
    <div class="rightpane">
        <h2>Camera Control</h2>
        <div class="controlbox">
            <table id="controltab" width="264px" border="0px" align="center" cellpadding="0px" cellspacing="0px">
            <tr>
                <td></td>
                <td valign="bottom" align="center">
                    <a href="/Control/Move/?direction=UP">
                        <img src="../../Content/images/cup.gif" alt="move up" />
                    </a>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="width:88px;" align="right" valign="top" >
                    <a href="/Control/Move/?direction=LEFT">
                        <img src="../../Content/images/cleft.gif" alt="move left" />
                    </a>
                </td>
                <td style="width:88px;" valign="top">
                    <img src="../../Content/images/cmid.gif" alt="control" />
                </td>
                <td style="width:88px;" align="left" valign="top">
                    <a href="/Control/Move/?direction=RIGHT">
                        <img src="../../Content/images/cright.gif" alt="move right" />
                    </a>
                </td>
            </tr>
            <tr>
                <td style="width:88px;"></td>
                <td style="width:88px;" align="center" valign="top">
                    <a href="/Control/Move/?direction=DOWN">
                        <img src="../../Content/images/cdown.gif" alt="move down" />
                    </a>
                </td>
                <td style="width:88px;"></td>
            </tr>
            </table>
            <form action="/Control/Save/" method="post" id="frm_save">
                <input type="text" name="preset_name" value="Preset #<%= ViewData["pre_count"] %>" id="txt_name" class="SaveBox"/>
            </form>

            <a href="javascript:save();">
                <div class="ctrlButton">Save As Preset</div>
            </a>
        </div>
        <h2>Presets</h2>

        <%
            string[] pre_names = ViewData["pre_names"] as string[];
            int[] pre_ids = ViewData["pre_ids"] as int[];

            for (int i = 0; i < int.Parse(ViewData["pre_count"].ToString()); i++)
            {
        %>
            <div class="sysstat">
                <strong> <%= pre_names[i]%> </strong> 
                <span class="presetControl">
                        <a href="/Control/Load/?preset_id=<%= pre_ids[i] %>">load</a>
                        <a href="javascript:delete_preset(<%= pre_ids[i] %>);">delete</a>
                </span>
            </div>
        <%  } %>
        
        <!-- design backup         
        <div class="sysstat">
            <strong>UI's stress test -sdhjkjksdhgfffgdfgjk hdsdjkg</strong> 
            <span class="presetControl">
                    <a href="#">load</a>
                    <a href="#">delete</a>
            </span>
        </div>
        -->
       
    </div>
    
    <!-- Spacer span    -->


</asp:Content>
