<%@ Page Title="Возврат" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewRetract.aspx.cs" Inherits="Librarium2.NewRetract" %>
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
                <asp:Label ID="Label1" runat="server" Text="Номер возврата:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbRetractID" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
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
                <asp:TextBox ID="tbRetractDate" runat="server" Width="280px" ReadOnly="True" TextMode="Date"></asp:TextBox>
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
                <asp:TextBox ID="tbReader" runat="server" AutoPostBack="True" OnTextChanged="tbReader_TextChanged" Width="280px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">&nbsp;
            </td>
            <td style="height: 20px">
                <asp:ListBox ID="lbReaders" runat="server" Width="280px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbReaders_SelectedIndexChanged"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 107px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        </table>
    <table>
    <tr>
            <td style="width: 696px">Книга:</td>
            <td style="width: 87px">Количество:</td>
            <td>&nbsp;</td>
            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        </tr>
        <tr>
            <td style="width: 696px">
    <asp:TextBox ID="tbBook" runat="server" AutoPostBack="True" OnTextChanged="tbBook_TextChanged" Width="680px"></asp:TextBox>
            </td>
            <td style="width: 87px">
                <asp:TextBox ID="tbCount" runat="server" AutoPostBack="True" TextMode="Number" Width="77px" min="1"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Добавить" UseSubmitBehavior="False" />
            </td>
            <td>&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ListBox ID="lbBooks" runat="server" Width="680px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbBooks_SelectedIndexChanged"></asp:ListBox>
    <br />
    <br />
        <table>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px">
                    <Columns>
                    <asp:BoundField DataField="BookID" HeaderText=" Код книги" SortExpression="BookID" />
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="QuantityRetractedBooks" HeaderText="Количество" SortExpression="QuantityRetractedBooks" />
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
