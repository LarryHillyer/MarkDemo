<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Mobile.Master" CodeBehind="People.aspx.vb" Inherits="MarkDemo.People" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <h4>Contacts&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   </h4>
    Title<br />

    <asp:TextBox ID="Title1" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ErrorLabel1" runat="server"><%:CStr(ViewState("FirstNameRequired")) %></asp:Label>
    <br />
    First Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Last Name<br />

    <asp:TextBox ID="FirstName1" runat="server" Width="85px"></asp:TextBox>&nbsp;&nbsp;<asp:TextBox ID="LastName1" runat="server" Width="87px"></asp:TextBox>
    
    <br />Address<br />

    <asp:TextBox ID="Address1" runat="server" Height="67px" Width="185px"></asp:TextBox>
    
    <br />
    <asp:Label ID="ErrorLabel2" runat="server" ><%:CStr(ViewState("PhoneNumberRequired")) %></asp:Label>
    
    <br />
    Phone Number<br />
    <asp:TextBox ID="PhoneNumber1" runat="server"></asp:TextBox>
    
    <br /><br />

    <asp:Button ID="Add2" runat="server" Text="Add" />
    &nbsp;&nbsp;
    <asp:Button ID="Search2" runat="server" Text="Search" />
    &nbsp;
    <asp:Button ID="Clear" runat="server" Text="Clear" />
    <br />

</asp:Content>
