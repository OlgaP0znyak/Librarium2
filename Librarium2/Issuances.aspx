<%@ Page Title="Выдачи книг читателям" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Issuances.aspx.cs" Inherits="Librarium2.Issuances" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Создать выдачу" OnClick="btnAdd_Click" />
    </p>
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="IssuanceID">
            <Columns>
                    <asp:ButtonField DataTextField="IssuanceID" HeaderText="Номер выдачи" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="IssuanceDate" HeaderText="&nbsp;&nbsp;Дата" SortExpression="IssuanceDate" DataFormatString="{0:d}" >
                    </asp:BoundField>                    
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
