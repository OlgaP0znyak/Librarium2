<%@ Page Title="Выдача" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issuance.aspx.cs" Inherits="Librarium2.Issuance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <table class="nav-justified">
        <tr>
            <td style="height: 20px; width: 107px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">
                <asp:Label ID="Label1" runat="server" Text="Номер выдачи:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbIssuanceID" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">&nbsp;</td>
            <td style="height: 20px">   &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">
                <asp:Label ID="Label2" runat="server" Text="Дата:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbIssuanceDate" runat="server" Width="280px" ReadOnly="True" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">
                <asp:Label ID="Label3" runat="server" Text="Читатель:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbReader" runat="server" AutoPostBack="True" Width="280px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px">
                    <Columns>
                    <asp:BoundField DataField="BookID" HeaderText=" Код книги" SortExpression="BookID" />
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="QuantityIssuedBooks" HeaderText="Количество" SortExpression="QuantityIssuedBooks" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px; text-align: left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
