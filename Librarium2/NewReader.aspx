<%@ Page Title="Карточка читателя" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewReader.aspx.cs" Inherits="Librarium2.NewReader" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <table class="nav-justified">
        <tr>
            <td style="height: 20px; width: 155px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">
                <asp:Label ID="Label1" runat="server" Text="Фамилия*:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbSurname" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">
                <asp:Label ID="Label2" runat="server" Text="Имя*:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbName" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label3" runat="server" Text="Отчество:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPatronymic" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label4" runat="server" Text="Адрес:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAdress" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label5" runat="server" Text="Номер телефона:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPhone" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label6" runat="server" Text="Дата рождения:"></asp:Label>
            </td>
            <td>
                
                <asp:TextBox ID="tbBirthDate" runat="server" Width="362px" TextMode="Date" OnLoad="tbBirthDate_Load"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px; text-align: left">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Сохранить" />
            </td>
        </tr>
    </table>
    

    
</asp:Content>