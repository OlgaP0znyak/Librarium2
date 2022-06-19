<%@ Page Title="Книги на руках у читателей" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookOnHand.aspx.cs" Inherits="Librarium2.BookOnHand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <table class="nav-justified">
        <tr>
            <td style="height: 20px; width: 689px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
                <asp:Label ID="Label3" runat="server" Text="Читатель:"></asp:Label>
            </td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
                <asp:TextBox ID="tbReader" runat="server" AutoPostBack="True" OnTextChanged="tbReader_TextChanged" Width="680px"></asp:TextBox>
            </td>
            <td style="height: 20px">
                <asp:CheckBox ID="cbReader" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
                <asp:ListBox ID="lbReaders" runat="server" Width="680px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbReaders_SelectedIndexChanged"></asp:ListBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">Книга:</td>
            <td style="height: 20px"></td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
    <asp:TextBox ID="tbBook" runat="server" AutoPostBack="True" OnTextChanged="tbBook_TextChanged" Width="680px"></asp:TextBox>
            </td>
            <td style="height: 20px">
                <asp:CheckBox ID="cbBook" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
    <asp:ListBox ID="lbBooks" runat="server" Width="680px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbBooks_SelectedIndexChanged"></asp:ListBox>
                <br />
                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 689px">
                &nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        </table>
    <table>
        <tr>
            <td style="width: 696px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Найти" UseSubmitBehavior="False" Width="155px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Отменить поиск" UseSubmitBehavior="False" Width="155px" />
            </td>
            <td style="width: 107px">
                &nbsp;</td>
            <td>&nbsp;&nbsp;
                </td>
        </tr>
    </table>
    <br />
        <table>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="800px">
                    <Columns>
                    <asp:BoundField DataField="BookID" HeaderText=" Код книги" SortExpression="BookID" />
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" />
                    <asp:BoundField DataField="ReaderID" HeaderText=" Код читателя" SortExpression="ReaderID" />
                    <asp:BoundField DataField="ReaderSurname" HeaderText="Фамилия" SortExpression="ReaderSurname" />
                    <asp:BoundField DataField="ReaderName" HeaderText="Имя" SortExpression="ReaderName" />
                    <asp:BoundField DataField="ReaderPatronymic" HeaderText="Отчество" SortExpression="ReaderPatronymic" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 107px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        </table>
</asp:Content>
