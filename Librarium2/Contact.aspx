<%@ Page Title="Контакты" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Librarium2.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <br>
    <address>
        
        <p><strong>Телефон:</strong> +375291111111</p>
        
    </address>

    <address>
        <strong>По вопросам технической поддержки <br> обращайтесь по электронному адресу:</strong>   <a href="mailto:Support_librarium@gmail.com">Support_librarium@gmail.com</a><br />
    </address>
    <br>
    <address>
        <strong>По вопросам маркетинга<br> обращайтесь по электронному адресу:</strong>   <a href="mailto:Marketing_librarium@gmail.com">Marketing_librarium@gmail.com</a><br />
    </address>
</asp:Content>
