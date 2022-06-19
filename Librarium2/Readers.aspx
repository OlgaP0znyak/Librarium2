<%@ Page Title="Читатели" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Readers.aspx.cs" Inherits="Librarium2.Readers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Добавить читателя" PostBackUrl="~/NewReader.aspx" />
    </p>
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ReaderID">
            <Columns>
                    <asp:ButtonField DataTextField="ReaderID" HeaderText="Код читателя" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="ReaderSurname" HeaderText="Фамилия" SortExpression="ReaderSurname" >
                    </asp:BoundField>
                    <asp:BoundField DataField="ReaderName" HeaderText="Имя" SortExpression="ReaderName" />
                    <asp:BoundField DataField="ReaderPatronymic" HeaderText="Отчество" SortExpression="ReaderPatronymic" />
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
