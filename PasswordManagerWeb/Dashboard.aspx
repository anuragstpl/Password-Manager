<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PasswordManagerWeb.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 20px; margin-left: 270px;">
        <div class="row">
            <div class="col-md-12">
                <asp:Literal runat="server" ID="ltrNotification">
                     
                </asp:Literal>

            </div>
        </div>
        <div class="row" style="margin-left:-66px;">

            <div class="col-md-12" style="width: 100%;">
                <asp:ListView ID="lstAccount" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemEditing="lstAccount_ItemEditing" OnItemDeleting="lstAccount_ItemDeleting" OnItemCommand="lstAccount_ItemCommand" OnPagePropertiesChanging="lstAccount_PagePropertiesChanging">
                    <LayoutTemplate>
                        <section class="content">
                            <div class="row">
                                <div class="col-xs-12" style="width: 100%">
                                    <div class="box">
                                        <div class="box-header">
                                            <h3 class="box-title">Accounts</h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>Account ID</th>
                                                        <th>Name</th>
                                                        <th>Description</th>
                                                        <th>Added On</th>
                                                        <th>Actions</th>
                                                    </tr>
                                                </thead>
                                                <tbody>

                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstAccount" PageSize="10">
                                                                <Fields>
                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                                        ShowNextPageButton="false" />
                                                                    <asp:NumericPagerField ButtonType="Link" />
                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                                                </Fields>
                                                            </asp:DataPager>
                                                        </td>
                                                    </tr>
                                                </tfoot>
                                            </table>

                                        </div>
                                        <!-- /.box-body -->
                                    </div>
                                </div>
                            </div>
                        </section>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("AccountID") %></td>
                            <td><%# Eval("Name") %></td>
                            <td><%# Eval("Description") %></td>
                            <td><%# Eval("AddedOn") %></td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkEdit" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("AccountID") %>' ToolTip="Manage Password For Account" CommandName="ManagePwd"></asp:LinkButton>

                            </td>

                        </tr>
                    </ItemTemplate>


                </asp:ListView>
            </div>


        </div>
    </div>
</asp:Content>
