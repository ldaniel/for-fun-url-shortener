<%@ Page Language="C#" MasterPageFile="~/Views/Master/DefaultViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<RaboURLShortner.Models.URL>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RaboTrim(url)! - Create
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Your RaboTrim(url) was successfully created!</h2>
    <br />
    <p>The following URL:</p>
    <p><label><%=Model.Original%></label></p>
    <p>has a length of <%=Model.Original.Length %> characters and resulted in the following URL which 
        has a length of <%=(System.Configuration.ConfigurationManager.AppSettings["base_url"].Length + Model.Id.Length) %> characters:</p>
    <p>
        <label><%=System.Configuration.ConfigurationManager.AppSettings["base_url"] + Model.Id %></label><br />
        [<a href="<%= System.Configuration.ConfigurationManager.AppSettings["base_url"] + Model.Id %>" target="_blank">Open in new window</a>]
    </p>
    <p>Or, give your recipients confidence with a preview URL:</p>
    <p>
        <label><%=System.Configuration.ConfigurationManager.AppSettings["base_url"] + "preview/" + Model.Id %></label><br />
        [<a href="<%=System.Configuration.ConfigurationManager.AppSettings["base_url"] + "preview/" + Model.Id %>" target="_blank">Open in new window</a>]
    </p>
    <br />
    <input type="submit" value="Back to RaboTrim(url)!" onclick="window.history.back(-1);" class="btn btn-lg btn-primary" />
</asp:Content>