<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br /><br /><br /><br /><br />
<div class="login">
<h3>SpaceLock - Login</h3>
<form id="frmLogin" name="frmLogin" action="/Home/DoLogin" method="post">
    <% if (ViewData["message"] != null)
       { 
    %>
                <h4>
                    <%=ViewData["message"]%>
                </h4>
    <% } %>

    <label>Username</label>
    <input name="txtUser" type="text"/>
    <label>Password</label>
    <input name="txtPass" type="password" />
    <br />
    <input type="submit" value="Login" id="btnLogin" />
</form>
</div>
</asp:Content>
