<%@ Page Title="Карточка книги" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBook.aspx.cs" Inherits="Librarium2.NewBook" %>

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
                <asp:Label ID="Label1" runat="server" Text="Автор*:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbAuthor" runat="server" Width="362px" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">
                <asp:Label ID="Label2" runat="server" Text="Список авторов:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbListAuthors" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label3" runat="server" Text="Название*:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbBookName" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label4" runat="server" Text="ISBN:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbISBN" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label5" runat="server" Text="Количество страниц:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPages" runat="server" Width="362px" TextMode="Number" min="1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label6" runat="server" Text="Издательство:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbPublisher" runat="server" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">
                <asp:Label ID="Label7" runat="server" Text="Год издания:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbYear" runat="server" Width="362px" TextMode="Number" min="1600" max="2022"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px; text-align: left">
                <asp:Label ID="Label8" runat="server" Text="Краткое содержание:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbAnnotation" runat="server" Height="124px" TextMode="MultiLine" Width="362px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 155px; text-align: left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
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
