<%@ Page Title="Списания книг" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WriteOffs.aspx.cs" Inherits="Librarium2.WriteOffs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    
    <p>
        <asp:Button ID="btnAdd" runat="server" Text="Создать списание" OnClick="btnAdd_Click" />
    </p>
    
    <p class="text-left">
        <asp:GridView ID="GridView1" runat="server" Width="785px" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="WriteOffID">
            <Columns>
                    <asp:ButtonField DataTextField="WriteOffID" HeaderText="Номер списания" CommandName="Select" >
                    </asp:ButtonField>
                    <asp:BoundField DataField="WriteOffDate" HeaderText="Дата" SortExpression="WriteOffDate" DataFormatString="{0:d}" >
                    </asp:BoundField>                    
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
