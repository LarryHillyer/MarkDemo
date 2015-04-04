Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.ModelBinding
Imports System.Data

Public Class TaskSearch1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("TimeOut") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If

        If CStr(Session("TaskNameSearch")) = "" Or Session("TaskNameSearch") Is Nothing Then
            SearchTaskName1.Visible = False
        Else
            SearchTaskName1.Visible = True
        End If

        If CStr(Session("OwnerSearch")) = "" Or Session("OwnerSearch") Is Nothing Then
            SearchOwner1.Visible = False
        Else
            SearchOwner1.Visible = True
        End If

        If CStr(Session("AccountSearch")) = "" Or Session("AccountSearch") Is Nothing Then
            SearchAccount1.Visible = False
        Else
            SearchAccount1.Visible = True
        End If

        If CBool(Session("FoundTask")) Then
            FoundTask1.Visible = False
        Else
            FoundTask1.Text = "No Results Found"
            FoundTask1.Visible = True
        End If

    End Sub



    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim _dbMarkContext As New TaskContactDbContext

        Try
            If RadioButtonList1.SelectedIndex > -1 Then
                Dim userPick1 = RadioButtonList1.SelectedItem.Text

                Dim queryMyTask = (From c1 In _dbMarkContext.MyTasks
                                      Where Not (c1.TaskName = userPick1)
                                      Select c1).ToList

                For Each c1 In queryMyTask
                    _dbMarkContext.MyTasks.Remove(c1)
                Next
                _dbMarkContext.SaveChanges()
            End If

        Catch ex As Exception

        End Try


        Response.Redirect("~/ToDoList.aspx")

    End Sub
End Class