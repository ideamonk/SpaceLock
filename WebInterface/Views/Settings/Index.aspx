<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>&nbsp;SpaceLock Settings</h2>

    <!-- Features config =================================== -->
    <table class="intrusionLog" width="100%" align="center">
        <tr>
            <th  width="270px" align="left">Features</th>
            <th style="text-align:right;">
                Legend : <span class="lon">enabled</span> | <span class="loff"> disabled </span>
            </th>
        </tr>
        
        <tr class="stripe1">
            <td>Intruder Tracking</td>
            <td align="center">
                <span class="<%= ViewData["tracking"] %>">
                    <a href="/Settings/Tracking/?set=1">
                        <b>ON</b>
                    </a>
                </span>
                <span class="<%= ViewData["_tracking"] %>">
                    <a href="/Settings/Tracking/?set=0">OFF</a>
                </span>
            </td>
        </tr>
        
        <tr class="stripe1">
            <td>SMS Alerts</td>
            <td align="center">
                <span class="<%= ViewData["sms"] %>">
                    <a href="/Settings/sms/?set=1">ON</a>
                </span>
                <span class="<%= ViewData["_sms"] %>">
                    <a href="/Settings/sms/?set=0">
                    <b>OFF</b>
                    </a>
                </span>
            </td>
        </tr>
        
         <tr class="stripe1">
            <td>
                Intruder Look-Up Time 
                    [<a href="#"> ? </a>]
            </td>
            <td align="center">
                <span class="<% if (ViewData["lookup"].ToString()=="5") {%>on<%}else{%>off<%} %>">
                    <a href="/Settings/LookUp/?set=5">
                        <b>5 min</b>
                    </a>
                </span>
                <span class="<% if (ViewData["lookup"].ToString()=="15") {%>on<%}else{%>off<%} %>">
                    <a href="/Settings/LookUp/?set=15">15 min</a>
                </span>
                <span class="<% if (ViewData["lookup"].ToString()=="30") {%>on<%}else{%>off<%} %>">
                    <a href="/Settings/LookUp/?set=30">30 min</a>
                </span>
            </td>
        </tr>
       
    </table>
    
    <!-- Configuration ================================================= -->
    <!--
    <table class="intrusionLog" width="100%" align="center">
        <tr>
            <th  width="270px" align="left">Configuration</th>
            <th style="text-align:right;">
                
            </th>
        </tr>
        
        
        <tr class="stripe1">
            <td>Maximum Videos to Archive</td>
            <td align="center">
                <span class="<% if (ViewData["maxarch"].ToString()=="40") {%>on<%}else{%>off<%} %>">
                    <a href="#">40</a>
                </span>
                <span class="<% if (ViewData["maxarch"].ToString()=="100") {%>on<%}else{%>off<%} %>">
                    <a href="#">
                    <b>100</b>
                    </a>
                </span>
                <span class="<% if (ViewData["maxarch"].ToString()=="400") {%>on<%}else{%>off<%} %>">
                    <a href="#">
                    <b>400</b>
                    </a>
                </span>
            </td>
        </tr>
    </table> 
    -->   
    
    
    <% if (ViewData["error"] != null)
       { %>
        <div class="intError">
            <%= ViewData["error"] %>
        </div>
    <% } %>

    <% if (ViewData["success"] != null)
       { %>
        <div class="intSuccess">
            <%= ViewData["success"] %>
        </div>
    <% } %>

    
    <!-- Password Change ============================================== -->
    <table class="intrusionLog" width="100%" align="center">
        <tr>
            <th  width="270px" align="left">Change Password</th>
            <th style="text-align:right;">    
            </th>
        </tr>
            
        <form id="frmPassword" action="/Settings/ChangePassword/" method="post">
            <tr class="stripe1">
                <td>
                    Current Password
                </td>
                <td align="center">
                    <input name="pwdCurrent" type="password" class="btnSubmit"/>
                </td>
            </tr>
            <tr class="stripe1">
                <td>
                    New Password (min 6 characters)
                </td>
                <td align="center">
                    <input name="pwdNew" type="password" class="btnSubmit"/>
                </td>
            </tr>
            <tr class="stripe1">
                <td>
                    Re-Enter Password
                </td>
                <td align="center">
                    <input name="pwdRepeat" type="password" class="btnSubmit"/>
                </td>
            </tr>
            <tr class="stripe1">
                <td>
                   
                </td>
                <td align="center">
                    <button type="submit" value="Change" class="btnSubmit">Change</button>
                </td>
            </tr>
        </form>
    </table>    
</asp:Content>
