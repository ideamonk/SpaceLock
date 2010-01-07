<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">






    <h2>View - Player for Intrusion ID # <%= ViewData["int_id"] %></h2>
 
<div id="container"><a href="http://www.macromedia.com/go/getflashplayer">Get the Flash Player</a> to see this player.</div>
<script type="text/javascript" src="../../Content/swfobject.js"></script>
	<script type="text/javascript">
	    var s1 = new SWFObject("../../Content/player.swf", "ply", "640", "480", "9", "#FFFFFF");
	    s1.addParam("allowfullscreen", "true");
	    s1.addParam("allowscriptaccess", "always");
	    s1.addParam("flashvars", "file=http://localhost:27051/a.flv&image=../../preview.jpg");
	    s1.write("container");
	</script>

</asp:Content>
