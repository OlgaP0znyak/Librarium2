<%@ Page Title="Поступление" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Receipt.aspx.cs" Inherits="Librarium2.Receipt" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <table class="nav-justified">
        <tr>
            <td style="height: 20px; width: 127px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 127px">
                <asp:Label ID="Label1" runat="server" Text="Номер поступления:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbReceiptID" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 127px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 127px">
                <asp:Label ID="Label2" runat="server" Text="Дата:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbReceiptDate" runat="server" Width="280px" ReadOnly="True" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 127px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px">
                    <Columns>
                    <asp:BoundField DataField="BookID" HeaderText=" Код книги" SortExpression="BookID" />
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="QuantityReceiptedBooks" HeaderText="Количество" SortExpression="QuantityReceiptedBooks" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 127px; text-align: left">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    

    
</asp:Content>