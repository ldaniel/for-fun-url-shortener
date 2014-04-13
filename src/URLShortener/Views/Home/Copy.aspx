<%@ Page Language="C#" MasterPageFile="~/Views/Master/DefaultViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<RaboURLShortner.Models.URL>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RaboTrim(url)! - Copy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>This URL has already been trimmed before!</h2>
    <br />
    <p>The following URL:</p>
    <p><label><%=Model.Original%></label></p>
    <p>has already been trimmed by someone before. You can try assigning a different custom alias again.
       But, if the following short link is OK for you, just copy it: 
    </p>    
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