<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Mobile.Master" CodeBehind="ToDoList.aspx.vb" Inherits="MarkDemo.ToDoList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Tasks    </h3>

    <asp:Label ID="ErrorLabel1" runat="server" ></asp:Label>
    <br />

    Task Name<br />

    <asp:TextBox ID="TaskName1" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="ErrorLabel2" runat="server" ></asp:Label>

    <br />Owner<br />

    <asp:TextBox ID="Owner1" runat="server"></asp:TextBox>

    <br />Due Date<br />

    <asp:TextBox ID="DueDate1" runat="server"></asp:TextBox>

    <br />
    <asp:Label ID="ErrorLabel3" runat="server" ></asp:Label>

    <br />Account<br />

    <asp:TextBox ID="Account1" runat="server"></asp:TextBox>

    <br />
    Override Rate<br />
    <asp:TextBox ID="OverrideRate1" runat="server"></asp:TextBox>

    <br />Description<br />

    <asp:TextBox ID="Description1" runat="server" Height="74px" Width="275px"></asp:TextBox>
    
    <br />
    <br />

    <asp:Button ID="Add1" runat="server" Text="Add" />
        &nbsp;&nbsp;
    <asp:Button ID="Search1" runat="server" Text="Search" />

    &nbsp;
    <asp:Button ID="Clear1" runat="server" Text="Clear" />

    <br />
    <br />
</asp:Content>
