<%@ Page Title="Возвраты книг от читателей" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Retracts.aspx.cs" Inherits="Librarium2.Retracts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Создать возврат" OnClick="btnAdd_Click" />
    </p>
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="RetractID">
            <Columns>
                    <asp:ButtonField DataTextField="RetractID" HeaderText="Номер возврата" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="RetractDate" HeaderText="&nbsp;&nbsp;Дата" SortExpression="RetractDate" DataFormatString="{0:d}" >
                    </asp:BoundField>                    
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
