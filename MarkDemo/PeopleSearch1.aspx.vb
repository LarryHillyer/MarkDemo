Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.ModelBinding
Imports System.Data


Public Class PeopleSearch1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("TimeOut") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If

        If CStr(Session("FirstNameSearch")) = "" Or Session("FirstNameSearch") Is Nothing Then
            SearchFirstName1.Visible = False
        Else
            SearchFirstName1.Visible = True
        End If

        If CStr(Session("LastNameSearch")) = "" Or Session("LastNameSearch") Is Nothing Then
            SearchLastName1.Visible = False
        Else
            SearchLastName1.Visible = True
        End If

        If CStr(Session("PhoneNumberSearch")) = "" Or Session("PhoneNumberSearch") Is Nothing Then
            SearchPhoneNumber1.Visible = False
        Else
            SearchPhoneNumber1.Visible = True
        End If

        If CBool(Session("FoundContact")) Then
            FoundContact1.Visible = False
        Else
            FoundContact1.Text = "No Results Found"
            FoundContact1.Visible = True
        End If




    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged

        Dim _dbMarkContext As New TaskContactDbContext

        Try
            If RadioButtonList1.SelectedIndex > -1 Then
                Dim userPick1 = RadioButtonList1.SelectedItem.Text

                Dim queryMyContact = (From c1 In _dbMarkContext.MyContacts
                                      Where Not (c1.PhoneNumber = userPick1)
                                      Select c1).ToList

                For Each c1 In queryMyContact
                    _dbMarkContext.MyContacts.Remove(c1)
                Next
                _dbMarkContext.SaveChanges()
            End If

        Catch ex As Exception

        End Try


        Response.Redirect("~/People.aspx")
    End Sub
End Class