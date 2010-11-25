<%@ Page Title="" Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ExampleMvcApp.Models.Person>>" MasterPageFile="~/Views/Shared/Site.Master" %>
<asp:Content runat="server" ID="Title" ContentPlaceHolderID="TitleContent"></asp:Content>
<asp:Content runat="server" ID="Main" ContentPlaceHolderID="MainContent">
<h2>People</h2>
<ul>
<% foreach (var p in Model)
   {%>
<li><%: p.Name %></li>
<%
   }%>
</ul>
</asp:Content>
