<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Librarium2.LogIn" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Войти в систему</title>
    <style>
        .center {
            margin: 0 auto;
            margin-top:15px;
        }
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 490px;
            margin-left: 55px;
        }
    </style>
</head>
<body style="background-image: url('/Content/Hardback-books-blue-color_1366x768.jpg'); background-repeat: no-repeat; background-attachment: fixed; background-position: center center; width: 525px; height: 510px;">
    <br>
    <br>
    <br>
    <br>
    <h1 style="font-style: italic; color: #FFFFFF; font-size: 56px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Либрариум</h1>
    
  
    <form id="form1" runat="server">
        
        <div class="auto-style2">
            <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Для работы с приложением введите логин и пароль</b><br />
            <br>
            <asp:Panel ID="MainPanel" runat="server" Width="440px" 
                BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px">
                <br />
                <table style="width:100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="height: 43px; width:30%; vertical-align:top">&nbsp; Логин:</td>
                        <td style="height: 43px; width: 70%">
                            <asp:TextBox ID="UsernameText" runat="server" Width="80%" />
                            <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server"
                                ErrorMessage="* Некорректное имя пользователя" ControlToValidate="UsernameText" ForeColor="Red" />
                            &nbsp;<asp:RegularExpressionValidator
                                ID="UsernameValidator" runat="server"
                                ControlToValidate="UsernameText"
                                
                                ValidationExpression="[\w| .]*"
                                ForeColor="Red" />
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 26px; width: 30%; vertical-align: top">&nbsp; Пароль:</td>
                        <td style="height: 26px; width: 70%">
                            <asp:TextBox ID="PasswordText" runat="server" Width="80%" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="PwdRequiredValidator"
                                runat="server" ErrorMessage="* Некорректный пароль"
                                ControlToValidate="PasswordText" ForeColor="Red" />
                            <br />
                            <asp:RegularExpressionValidator ID="PwdValidator"
                                runat="server" ControlToValidate="PasswordText"
                               
                                ValidationExpression='[\w| !"§$%&amp;/()=\-?\*]*'
                                ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <p class="auto-style1">
                <asp:Button ID="LoginAction" runat="server" OnClick="LoginAction_Click" Text="Войти" CssClass="center" Height="37px" Width="85px" /><br />
           </p>
                    </asp:Panel>
        </div>
    </form>
</body>
</html>
