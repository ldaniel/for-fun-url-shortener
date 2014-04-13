<%@ Page Language="C#" MasterPageFile="~/Views/Master/DefaultViewMasterPage.Master" Inherits="System.Web.Mvc.ViewPage<RaboURLShortner.Models.URL>"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RaboTrim(url)! - Preview
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Preview</h2>
    <br />
    <p>This RaboTrim URL redirects to:</p>
    <p><label><%=Model.Original%><br /></label></p>
    <p><a href="<%=Model.Original%>" target="_self">Ok, proceed to this site</a>.</p>
    <br />
    <input type="submit" value="Back to RaboTrim(url)!" onclick="window.history.back(-1);" class="btn btn-lg btn-primary" />
</asp:Content>