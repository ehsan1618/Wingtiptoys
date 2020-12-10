<%@ Page Title="Cars - Wingtip Toys" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Wingtiptoy.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        
        <asp:UpdatePanel ID="updatepnl" runat="server">
            <ContentTemplate>
                <div id="body">
                    <section class="featured">
                        <div class="content-wrapper">
                            <hgroup class="title">
                                <h1>Products</h1>
                            </hgroup>

                            <section class="featured">
                                <div style="margin-left: 2em">

                                    <table>
                                        <tr>
                                            <td style="width: 30%; vertical-align: top;">
                                                <hgroup class="title">
                                                    <h1>Wingtip Toys</h1>
                                                    <h2>Wingtip Toys can help you find the perfect gift</h2>
                                                </hgroup>
                                                <p>
                                                    We're all about transportation toys. You can order 
                                    any of our toys today. Each toy listing has detailed 
                                    information to help you choose the right toy.
                                                </p>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="txtSearch" Width="100%"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click"></asp:Button>
                                                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="txtSearch" ValidationExpression="^[\s\S]{2,}$" ForeColor="Red" ErrorMessage="Minimum 2 characters required"></asp:RegularExpressionValidator><input type="hidden" id="_ispostback" value="<%=Page.IsPostBack.ToString().ToLower()%>" /></td>
                                                    </tr>
                                                </table>
                                                <table id="Products">
                                                    <%--Products By Category will load here--%>
                                                    <asp:Literal ID="tblSearchResult" runat="server" />
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </section>
                        </div>
                    </section>

                    <section class="content-wrapper main-content clear-fix"></section>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
