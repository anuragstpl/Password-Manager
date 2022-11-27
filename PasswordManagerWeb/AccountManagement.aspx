<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="AccountManagement.aspx.cs" Inherits="PasswordManagerWeb.AccountManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Manage Accounts
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Accounts</a></li>
                    <li class="active">Manage Accounts</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">General Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <div class="box-header with-border">
                        <h3 class="box-title">
                            <asp:Label runat="server" ID="lblMessage"></asp:Label></h3>


                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Enter Account Name*</label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Enter Description*</label>
                                    <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->

                            <!-- /.col -->
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddAccount" Text="Add Account" CssClass="btn btn-block btn-success" OnClick="btnAddAccount_Click" />
                                </div>
                            </div>
                            <div class="col-md-6" style="width: 100%;">
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
                                                <asp:LinkButton runat="server" ID="lnkDelete" CssClass="fa fa-fw fa-remove" OnClientClick="javascript:return confirm('Are you sure you want to delete this item?');" CommandArgument='<%# Eval("AccountID") %>' ToolTip="Delete Account" CommandName="Delete"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" ID="lnkEdit" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("AccountID") %>' ToolTip="Edit Account" CommandName="Edit"></asp:LinkButton>
                                                
                                            </td>

                                        </tr>
                                    </ItemTemplate>


                                </asp:ListView>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>
            <!-- /.content -->
            <!-- General Info -->

            <!-- /.content -->
        </div>

    </div>
</asp:Content>
