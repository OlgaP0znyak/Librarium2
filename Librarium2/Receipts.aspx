<%@ Page Title="Поступления книг в библиотеку" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipts.aspx.cs" Inherits="Librarium2.Receipts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Создать поступление" OnClick="btnAdd_Click" />
    </p>
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="ReceiptID">
            <Columns>
                    <asp:ButtonField DataTextField="ReceiptID" HeaderText="Номер поступления" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="ReceiptDate" HeaderText="Дата" SortExpression="ReceiptDate" DataFormatString="{0:d}" >
                    </asp:BoundField>                    
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
