<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PasswordManagerWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <title>Password Manager Registration</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
    <script src="Scripts/jquery-3.1.1.js" type="text/javascript"></script>
    <script src="Scripts/1jquery.passwordstrengthchecker-1.0.0.js"></script>
    <link href="Content/jquery.passwordstrengthchecker.css" rel="stylesheet" />
</head>
<body class="hold-transition skin-blue sidebar-mini" style="background-color: #ecf0f5; margin-top: 150px; margin-left: 150px;">
    <div>
        <form id="form1" runat="server">
            <div class="content-wrapper">
                <section class="content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Password Manager</h3>
                                </div>
                                <!-- /.box-header -->

                                <div class="box-body">
                                    <div class="form-group">

                                        <label for="txtName" class="col-sm-2 control-label"></label>
                                        <div class="col-sm-10">
                                            <img src="dist/SocialMedia/secrecy-icon.png" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="txtName" class="col-sm-2 control-label">First Name</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" ID="txtFName" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="txtName" class="col-sm-2 control-label">Last Name</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" ID="txtLName" CssClass="form-control" placeholder="Last Name" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="inputEmail3" class="col-sm-2 control-label">Username</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" placeholder="Username" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="inputEmail3" class="col-sm-2 control-label">Email</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email" type="email" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="inputPassword3" class="col-sm-2 control-label">Password</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" CssClass="form-control" required placeholder="Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <label for="inputPassword3" class="col-sm-2 control-label">Confirm Password</label>

                                            <div class="col-sm-10">
                                                <asp:TextBox runat="server" TextMode="Password" ID="txtConfirmPassword" CssClass="form-control" required placeholder="Repeat Password"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>



                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer">
                                    <a href="Login.aspx">Sign In</a>
                                    <asp:Button Visible="false" runat="server" ID="btnSignin" CssClass="btn btn-default" Text="Sign In" OnClick="btnSignin_Click" />
                                    <asp:Button runat="server" ID="btnSignUp" CssClass="btn btn-info pull-right" Text="Sign Up" OnClick="btnSignUp_Click" />
                                </div>
                                <!-- /.box-footer -->
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </form>
    </div>
</body>
<script type="text/javascript">
    $('input[type=text]').focus(function () {
        $('#btnSignUp').click();
    });

    var password = document.getElementById("txtPassword")
    var confirm_password = document.getElementById("txtConfirmPassword");

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
            "#txtPassword"
        ).passwordstrengthchecker();

        jQuery(
            "#txtConfirmPassword"
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
</html>
