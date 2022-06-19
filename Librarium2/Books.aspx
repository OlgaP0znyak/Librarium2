<%@ Page Title="Книги" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Librarium2.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Добавить книгу" PostBackUrl="~/NewBook.aspx" />
    </p>
    
    <p>
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="BookID">
            <Columns>
                    <asp:ButtonField DataTextField="BookID" HeaderText="Код книги" CommandName="Select" />
                    <asp:BoundField DataField="Author" HeaderText="Автор" SortExpression="Author" />
                    <asp:BoundField DataField="BookName" HeaderText="Название" SortExpression="BookName" />                    
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
