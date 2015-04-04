<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Mobile.Master" CodeBehind="PeopleSearch1.aspx.vb" Inherits="MarkDemo.PeopleSearch1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    Displaying Results For:<br />
    <asp:Label ID="SearchFirstName1" runat="server" ><%:CStr(Session("FirstNameSearch")) %></asp:Label>
    <br />
    <asp:Label ID="SearchLastName1" runat="server" ><%:CStr(Session("LastNameSearch")) %></asp:Label>
    <br />
    <asp:Label ID="SearchPhoneNumber1" runat="server" ><%:CStr(Session("PhoneNumberSearch")) %></asp:Label>
    <br />
    
    <asp:Label ID="FoundContact1" runat="server" ></asp:Label>
    
    <br />
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="126px" AutoPostBack="true" DataSourceId="LinqDataSource1" DataTextField="PhoneNumber" DataValueField="PhoneNumber"></asp:RadioButtonList>
    <br />
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="MarkDemo.TaskContactDbContext" EntityTypeName="" Select="new (PhoneNumber)" TableName="MyContacts"></asp:LinqDataSource>
    <br />
    <br />

</asp:Content>
