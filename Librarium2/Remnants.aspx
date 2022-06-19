<%@ Page Title="Остатки книг в библиотеке" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Remnants.aspx.cs" Inherits="Librarium2.Remnants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>   

    <table style="width: 1110px">
    <tr>
            <td style="width: 696px">Книга:</td>
            
            <td style="width: 64px">&nbsp;</td>
            
        </tr>
        <tr>
            <td style="width: 696px">
    <asp:TextBox ID="tbBook" runat="server" AutoPostBack="True" OnTextChanged="tbBook_TextChanged" Width="680px"></asp:TextBox>
            </td>
            
            <td style="width: 64px">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Найти" UseSubmitBehavior="False" />
            </td>
            <td>&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            
        </tr>
    </table>
    <asp:ListBox ID="lbBooks" runat="server" Width="680px" Visible="False" AutoPostBack="True" OnSelectedIndexChanged="lbBooks_SelectedIndexChanged"></asp:ListBox>
    <br />
    <br />
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False">
            <Columns>
                    <asp:BoundField DataField="BookID" HeaderText="Код книги" SortExpression="BookID" />                    
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Количество" SortExpression="Quantity" />                  
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
