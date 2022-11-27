<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="PasswordManager.aspx.cs" Inherits="PasswordManagerWeb.PasswordManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="Scripts/jquery-1.9.0.js"></script>
      <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="/plugins/select2/select2.min.css">
    <script src="Scripts/jquery.dynDateTime.min.js"></script>
    <script src="Scripts/calendar-en.min.js"></script>
    <script src="Scripts/bootstrap-show-password.min.js"></script>
    <link href="Content/calendar-blue.css" rel="stylesheet" />
    
     <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add/Edit Password
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Password</a></li>
                    <li class="active">Add/Edit Password</li>
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
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Type</label>
                                    
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblType" CssClass="form-control" ></asp:Label>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Password*</label>
                                    <asp:TextBox runat="server" ID="txtPassword"  TextMode="Password" CssClass="form-control" placeholder="Enter Password" data-toggle="password"  required ></asp:TextBox>
                                   
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Confirm Password*</label>
                                    <asp:TextBox runat="server" ID="txtConfirmPAssword" TextMode="Password" CssClass="form-control" placeholder="Enter Confirm Password" data-toggle="password" required ></asp:TextBox>
                                   
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            
                            <div class="col-md-6">
                                <div class="form-group">
                                   <label></label>
                                </div>
                                <div class="form-group">
             
                                    <asp:Button runat="server" ID="btnSaveEditPwd" Text="Save/Edit Password" CssClass="btn btn-block btn-success" OnClick="btnSaveEditPwd_Click" />
                                </div>
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
