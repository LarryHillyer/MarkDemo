<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Mobile.Master" CodeBehind="TaskSearch1.aspx.vb" Inherits="MarkDemo.TaskSearch1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    Displaying Results For:<br />

    <asp:Label ID="SearchTaskName1" runat="server" ><%:CStr(Session("TaskNameSearch")) %></asp:Label>
    <br />
    <asp:Label ID="SearchOwner1" runat="server" ><%:CStr(Session("OwnerSearch")) %></asp:Label>
    <br />
    <asp:Label ID="SearchAccount1" runat="server" ><%:CStr(Session("AccountSearch")) %></asp:Label>
    <br />
    <asp:Label ID="FoundTask1" runat="server" ></asp:Label>
    <br />

    <asp:RadioButtonList ID="RadioButtonList1" runat="server"  AutoPostBack="true" DataSourceId="LinqDataSource1" DataTextField="TaskName" DataValueField="TaskName">
    </asp:RadioButtonList>
    <br />
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="MarkDemo.TaskContactDbContext" EntityTypeName="" Select="new (TaskName)" TableName="MyTasks">
    </asp:LinqDataSource>

    <br />
</asp:Content>

