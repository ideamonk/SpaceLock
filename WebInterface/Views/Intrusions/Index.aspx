<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script language=javascript>
    var Descriptions = new Array();
    var IDs = new Array();
    
    function show_edit(number) {
        //document.getElementById("desc_" + number).innerHTML = "<textarea class='edit_text'>" + Descriptions[number] + "</textarea>";
        $("#desc_" + number).hide("fast", function(e) {
        $("#desc_" + number).html(
            "<form id='frm_" + number + "' action='/Intrusions/Update' method='POST'>" +
            "<input type='hidden' value='"+ IDs[number] +"' name='desc_id' />" +
            "<textarea name = 'description' class='edit_text' id = 'textbox_" + number + "'>" + 
            Descriptions[number] + 
            "</textarea></form>"
            );
            $("#desc_" + number).show("fast");
        }
        );
        
        
        //document.getElementById("butt_" + number).innerText = "Save";
        document.getElementById("butt_" + number).innerHTML =
            '<a href="javascript:post_edit(' + number + ');" class="intButton">save</a>';
            
        document.getElementById("cancel_" + number).innerHTML =
            '<a href="javascript:cancel_edit(' + number + ');" class="intButton">cancel</a>';
        
    }

    function cancel_edit(number) {
        
        document.getElementById("butt_" + number).innerHTML =
            '<a href="javascript:show_edit(' + number + ');" class="intButton">edit</a>';

        $("#desc_" + number).hide("fast", function(e) {
            $("#desc_" + number).html(Descriptions[number]);
            $("#desc_" + number).show("fast");
            $("#cancel_" + number).html("");
        }
           );
    }
    
    function post_edit(number) {
        document.getElementById("frm_" + number).submit();
    }

    function delete_entry(number) {
        if (confirm("Are you sure you want to delete Intrusion #" + number + " ?") == true) {
            document.getElementById("delfrm_" + number).submit();
        }
    }
    
</script>

<!-- Old Code ---------------------------------------------------------------------------------------- -->
    <h2>&nbsp;Intrusion Archive <small> (<%= ViewData["int_count"] %> events)</small></h2>
    <% if (ViewData["error"] != null)
       { %>
        <div class="intError">
            <%= ViewData["error"] %>
        </div>
    <% } %>
    

        <table id="intrusionLog" width="100%" align="center">
        <!-- Table head -->
            <tr>
                <th  width="170px" >Preview</th>
                <th>
                    <span style="float:right;">
                        <a href="?order=<%= ViewData["order"] %>">
                            <small>flip order</small>
                        </a>
                    </span>
                    Details 
                </th>
                <th width="150px">Manage</th>
            </tr>
            
            <!-- Intrusion Entry block | replace stripe1 by stripe2 alternatively -->
            
            <%  bool stripe=false; 
                var int_dates = ViewData["int_dates"] as string [];
                var int_descs = ViewData["int_descs"] as string [];
                var int_ids = ViewData["int_ids"] as string[];
                var int_times = ViewData["int_times"] as string[];
                
                for (int i = 0; i < (int)ViewData["int_count"]; i++)
                {
                    stripe = !stripe; 
            %>
                    
                <tr <% if (stripe) { %> class="stripe1" <%} else { %> class="stripe2" <%} %> >
                <!-- Preview -->
                <td align="center">
                    <a href="/Intrusions/View/?int_id=<%= int_ids[i] %>">
                        <img src="../../Content/thumbs/th<%= int_ids[i] %>.jpg" alt="Intrusion Preview" />
                    </a>
                </td>
                <!-- Details -->
                <td valign="top" align="left">
                    <div class="controlbox">
                    <b>Intrusion #<%= int_ids[i] %></b> @ <%= int_times[i] %> on <b><%= int_dates[i] %></b>
                    </div>
                    <script language="javascript">
                        Descriptions[<%= i %>] = "<%= int_descs[i] %>";
                        IDs[<%= i %>] = "<%= int_ids[i] %>";
                    </script>
                    <div class="intNotes">
                        <p id="desc_<%= i %>" >
                            <%= int_descs[i] %>
                        </p>
                        <span id="butt_<%= i %>">
                            <a href="javascript:show_edit(<%= i %>);" class="intButton">edit</a>
                        </span>
                        <span id="cancel_<%= i %>"> &nbsp;
                        </span>
                    </div>
                </td>
                <!-- menu -->
                <td valign="top" align="center" >
                    <a href="/Intrusions/View/?int_id=<%= int_ids[i] %>">
                        <img src="../../Content/images/man_view.gif" alt="View" title="Shows you a streaming video of the Intrusion." />
                    </a><br />
                    <a href="/Intrusions/Download/?int_id=<%= int_ids[i] %>">
                        <img src="../../Content/images/man_ddl.gif" alt="Download" title="Lets you download video of the intrusion for future references." />
                    </a><br />
                    <a href="javascript:delete_entry(<%= int_ids[i] %>);">
                        <img src="../../Content/images/man_del.gif" alt="Delete" title="Deletes unnecessary recordings to help you optimize storage space." />
                    </a>
                    <form id="delfrm_<%= int_ids[i] %>" action="/Intrusions/Delete/" method="get">
                        <input type="hidden" name = "desc_id" value = "<%= int_ids[i] %>" />
                    </form>
                </td>
            </tr>
            <% } %>

            
            
            <!-- End of an intrusion block -->
            
            
<!--            
            
            <tr class="stripe2">
                <td align="center">
                    <a href="#">
                        <img src="../../Content/thumbs/th1.jpg" alt="Intrusion title" />
                    </a>
                </td>
                <td valign="top" align="left">
                    <div class="controlbox">
                    @ 5:30 PM on <b>5th December 2009</b>
                    </div>
                    <div class="intNotes" >
                    <p id="intNote" onclick="show_edit(this);">
                        Mr. Sharma stealing something...
                    </p>
                        <a href="javascript:show_edit(this);" class="intButton">edit</a>
                    </div>
                </td>
                <td valign="top" align="center" >
                    <a href="#">
                        <img src="../../Content/images/man_view.gif" alt="View" title="Shows you a streaming video of the Intrusion." />
                    </a><br />
                    <a href="#">
                        <img src="../../Content/images/man_ddl.gif" alt="Download" title="Lets you download video of the intrusion for future references." />
                    </a><br />
                    <a href="#">
                        <img src="../../Content/images/man_del.gif" alt="Delete" title="Deletes unnecessary recordings to help you optimize storage space." />
                    </a>
                </td>
            </tr>
-->                       
        </table>
        <%
            if (int.Parse(ViewData["int_count"].ToString()) == 0)
            {
             %>
             <div class="happyBox">Yay! No Intrusions so far :)</div>
             <%} %>

</asp:Content>

