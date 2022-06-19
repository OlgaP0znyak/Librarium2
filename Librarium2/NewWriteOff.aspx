<%@ Page Title="Списание" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewWriteOff.aspx.cs" Inherits="Librarium2.NewWriteOff" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <table>
        <tr>
            <td style="height: 20px; width: 155px">
                &nbsp;</td>
            <td style="height: 20px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">
                <asp:Label ID="Label1" runat="server" Text="Номер списания:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbWriteOffID" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">
                <asp:Label ID="Label2" runat="server" Text="Дата:"></asp:Label>
            </td>
            <td style="height: 20px">
                <asp:TextBox ID="tbWriteOffDate" runat="server" Width="280px" TextMode="Date" ReadOnly="True"></asp:TextBox>                
            </td>
        </tr>
        <tr>
            <td style="height: 20px; width: 155px">&nbsp;</td>
            <td style="height: 20px">&nbsp;</td>
        </tr>
        </table>
    <table class="nav-justified">
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
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:ListBox ID="lbBooks" runat="server" Width="680px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbBooks_SelectedIndexChanged"></asp:ListBox>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="BookID">
            <Columns>
                    <asp:ButtonField DataTextField="BookID" HeaderText="Код книги" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" >
                    </asp:BoundField>
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="QuantityWritedOffBooks" HeaderText="Количество" SortExpression="QuantityWritedOffBooks" />
            </Columns>
        </asp:GridView>
<br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br />
</asp:Content>
