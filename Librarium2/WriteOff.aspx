<%@ Page Title="Списание" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WriteOff.aspx.cs" Inherits="Librarium2.WriteOff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                <asp:Label ID="Label1" runat="server" Text="Номер списания:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbWriteOffID" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
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
                <asp:TextBox ID="tbWriteOffDate" runat="server" Width="280px" ReadOnly="True" TextMode="Date"></asp:TextBox>
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
                    <asp:BoundField DataField="QuantityWritedOffBooks" HeaderText="Количество" SortExpression="QuantityReceiptedBooks" />
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
