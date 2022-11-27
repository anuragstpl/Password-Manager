<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ManagePassword.aspx.cs" Inherits="PasswordManagerWeb.ManagePassword" %>

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
    <link href="Content/style.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery.passwordstrengthchecker-1.0.0.js"></script>
    <link href="Content/jquery.passwordstrengthchecker.css" rel="stylesheet" />
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add/Edit Password
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Password</a></li>
                    <li class="active">Update Master Password</li>
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
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Old Password</label>
                                    <asp:TextBox runat="server" ID="txtOldPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" data-toggle="password" required></asp:TextBox>

                                </div>

                            </div>
                            <!-- /.col -->
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Password*</label>
                                    <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Enter Password" data-toggle="password" required></asp:TextBox>

                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Confirm Password*</label>
                                    <asp:TextBox runat="server" ID="txtConfirmPAssword" TextMode="Password" CssClass="form-control" placeholder="Enter Confirm Password" data-toggle="password" required></asp:TextBox>
                                    <div id="pass-info"></div>
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
    <script type="text/javascript">

        var password = document.getElementById("ContentPlaceHolder1_txtPassword")
        var confirm_password = document.getElementById("ContentPlaceHolder1_txtConfirmPAssword");

        function validatePassword() {
            if (password.value != confirm_password.value) {
                confirm_password.setCustomValidity("Passwords Don't Match");
            } else {
                confirm_password.setCustomValidity('');
            }
        }

        password.onchange = validatePassword;
        confirm_password.onkeyup = validatePassword;

        jQuery(function () {

            // default, right
            jQuery(
                "#ContentPlaceHolder1_txtOldPassword"
            ).passwordstrengthchecker();

            jQuery(
               "#ContentPlaceHolder1_txtPassword"
           ).passwordstrengthchecker();

            jQuery(
               "#ContentPlaceHolder1_txtConfirmPAssword"
           ).passwordstrengthchecker();

            //// left
            //jQuery(
            //    ".mycustomclass-left"
            //).passwordstrengthchecker({
            //    position: 'left'
            //});

            //// top
            //jQuery(
            //    ".mycustomclass-top"
            //).passwordstrengthchecker({
            //    position: 'top'
            //});

            // bottom
            //jQuery(
            //    "#ContentPlaceHolder1_txtOldPassword"
            //).passwordstrengthchecker({
            //    position: 'bottom'
            //});

        });
    </script>
</asp:Content>
