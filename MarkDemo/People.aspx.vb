Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.ModelBinding
Imports System.Data



Public Class People
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("TimeOut") Is Nothing Then
            Response.Redirect("~/Default.aspx")
        End If


        Dim _dbMarkContext As New TaskContactDbContext

        Try
            Using (_dbMarkContext)


                If Session("SearchReturn") Is Nothing Then

                ElseIf CBool(Session("SearchReturn")) = True Then
                    Session("SearchReturn") = False

                    Dim myContact1 = (From c1 In _dbMarkContext.MyContacts).ToList

                    For Each c1 In myContact1
                        Title1.Text = c1.Title
                        FirstName1.Text = c1.FirstName
                        LastName1.Text = c1.LastName
                        Address1.Text = c1.Address
                        PhoneNumber1.Text = c1.PhoneNumber
                    Next
                End If

            End Using
        Catch ex As Exception

        End Try

        Session("FoundContact") = False
        Session("FirstNameSearch") = ""
        Session("LastNameSearch") = ""
        Session("PhoneNumberSearch") = ""


    End Sub

    Protected Sub Add2_Click(sender As Object, e As EventArgs) Handles Add2.Click

        Dim _dbMarkContext As New TaskContactDbContext

        Dim ErrorMessage1 = "First Name Required"
        Dim ErrorMessage2 = "Phone Number Required"

        ErrorLabel1.Visible = False
        ErrorLabel2.Visible = False

        ViewState("FirstNameRequired") = ""
        ViewState("PhoneNumberRequired") = ""

        If FirstName1.Text = "" Then
            ViewState("FirstNameRequired") = ErrorMessage1
            ErrorLabel1.Visible = True
            ErrorLabel1.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If PhoneNumber1.Text = "" Then
            ViewState("PhoneNumberRequired") = ErrorMessage2
            ErrorLabel2.Visible = True
            ErrorLabel2.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Try
            Using (_dbMarkContext)

                Dim newContact1 As New Contact1

                newContact1.Title = Title1.Text
                newContact1.FirstName = FirstName1.Text
                newContact1.LastName = LastName1.Text
                newContact1.Address = Address1.Text
                newContact1.PhoneNumber = PhoneNumber1.Text

                _dbMarkContext.Contact1s.Add(newContact1)
                _dbMarkContext.SaveChanges()

            End Using
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Search2_Click(sender As Object, e As EventArgs) Handles Search2.Click

        Dim _dbMarkContext As New TaskContactDbContext

        Try
            Using (_dbMarkContext)

                Dim contacts1 As New List(Of MyContact)
                contacts1 = _dbMarkContext.MyContacts.ToList

                If _dbMarkContext.MyContacts.Count > 0 Then
                    For Each c1 In contacts1
                        _dbMarkContext.MyContacts.Remove(c1)
                    Next
                End If

                _dbMarkContext.SaveChanges()

                If FirstName1.Text <> "" Or LastName1.Text <> "" Or PhoneNumber1.Text <> "" Then
                    If FirstName1.Text <> "" Then
                        If LastName1.Text <> "" Then
                            If PhoneNumber1.Text <> "" Then
                                Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                    Where contact.FirstName.Contains(FirstName1.Text) And contact.LastName.Contains(LastName1.Text) And contact.PhoneNumber.Contains(PhoneNumber1.Text)
                                                    Select contact).ToList

                                If queryContact.Count > 0 Then
                                    queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                                    Session("FoundContact") = True
                                    Exit Try
                                Else
                                    Session("FoundContact") = False
                                    Exit Try
                                End If
                            Else
                                Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                    Where contact.FirstName.Contains(FirstName1.Text) And contact.LastName.Contains(LastName1.Text)
                                                    Select contact).ToList
                                If queryContact.Count > 0 Then
                                    queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                                    Session("FoundContact") = True
                                    Exit Try
                                Else
                                    Session("FoundContact") = False
                                    Exit Try
                                End If
                            End If
                        ElseIf PhoneNumber1.Text <> "" Then
                            Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                Where contact.FirstName.Contains(FirstName1.Text) And contact.PhoneNumber.Contains(PhoneNumber1.Text)
                                                Select contact).ToList
                            queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                            Exit Try
                        Else
                            Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                Where contact.FirstName.Contains(FirstName1.Text)
                                                Select contact).ToList
                            If queryContact.Count > 0 Then
                                queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                                Session("FoundContact") = True
                                Exit Try
                            Else
                                Session("FoundContact") = False
                                Exit Try
                            End If
                        End If
                    ElseIf LastName1.Text <> "" Then
                        If PhoneNumber1.Text <> "" Then
                            Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                Where contact.LastName.Contains(LastName1.Text) And contact.PhoneNumber.Contains(PhoneNumber1.Text)
                                                Select contact).ToList
                            If queryContact.Count > 0 Then
                                queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                                Session("FoundContact") = True
                                Exit Try
                            Else
                                Session("FoundContact") = False
                                Exit Try
                            End If
                        Else
                            Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                                Where contact.LastName.Contains(LastName1.Text)
                                                Select contact).ToList
                            If queryContact.Count > 0 Then
                                queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                                Session("FoundContact") = True
                                Exit Try
                            Else
                                Session("FoundContact") = False
                                Exit Try
                            End If
                        End If

                    ElseIf PhoneNumber1.Text <> "" Then
                        Dim queryContact = (From contact In _dbMarkContext.Contact1s
                                            Where contact.PhoneNumber.Contains(PhoneNumber1.Text)
                                            Select contact).ToList
                        If queryContact.Count > 0 Then
                            queryContact = CreateMyContacts(queryContact, _dbMarkContext)
                            Session("FoundContact") = True
                            Exit Try
                        Else
                            Session("FoundContact") = False
                            Exit Try
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception

        End Try

        Session("SearchReturn") = True
        Session("FirstNameSearch") = FirstName1.Text
        Session("LastNameSearch") = LastName1.Text
        Session("PhoneNumberSearch") = PhoneNumber1.Text

        Response.Redirect("~/PeopleSearch1.aspx")

    End Sub

    Public Shared Function CreateMyContacts(queryContact As List(Of Contact1), _dbMarkContext As TaskContactDbContext) As List(Of Contact1)

        For Each c1 In queryContact
            Dim newMyContact As New MyContact
            newMyContact.ContactId = c1.ContactId
            newMyContact.Title = c1.Title
            newMyContact.FirstName = c1.FirstName
            newMyContact.LastName = c1.LastName
            newMyContact.Address = c1.Address
            newMyContact.PhoneNumber = c1.PhoneNumber

            _dbMarkContext.MyContacts.Add(newMyContact)
            _dbMarkContext.SaveChanges()
        Next

        Return queryContact
    End Function

    Protected Sub Clear_Click(sender As Object, e As EventArgs) Handles Clear.Click
        Title1.Text = ""
        FirstName1.Text = ""
        LastName1.Text = ""
        Address1.Text = ""
        PhoneNumber1.Text = ""
    End Sub
End Class