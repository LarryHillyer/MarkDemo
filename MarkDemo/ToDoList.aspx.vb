Public Class ToDoList
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

                    Dim myContact1 = (From c1 In _dbMarkContext.MyTasks).ToList

                    For Each c1 In myContact1
                        TaskName1.Text = c1.TaskName
                        Owner1.Text = c1.Owner
                        DueDate1.Text = c1.DueDate
                        Description1.Text = c1.Description
                        Account1.Text = c1.Account
                        OverrideRate1.Text = c1.OverrideRate
                    Next
                End If

            End Using
        Catch ex As Exception

        End Try

        Session("FoundTask") = False
        Session("TaskNameSearch") = ""
        Session("TaskOwnerSearch") = ""
        Session("TaskAccountSearch") = ""

    End Sub

    Protected Sub Clear1_Click(sender As Object, e As EventArgs) Handles Clear1.Click
        TaskName1.Text = ""
        Owner1.Text = ""
        DueDate1.Text = ""
        Account1.Text = ""
        Description1.Text = ""
        OverrideRate1.Text = ""

    End Sub

    Protected Sub Add1_Click(sender As Object, e As EventArgs) Handles Add1.Click
        Dim _dbMarkContext As New TaskContactDbContext

        Dim ErrorMessage1 = "Task Name Required"
        Dim ErrorMessage2 = "Task Owner Required"
        Dim ErrorMessage3 = "Account Required"

        ErrorLabel1.Visible = False
        ErrorLabel2.Visible = False
        ErrorLabel3.Visible = False

        ViewState("TaskNameRequired") = ""
        ViewState("TaskOwnerRequired") = ""
        ViewState("TaskAccountRequired") = ""

        If TaskName1.Text = "" Then
            ViewState("TaskNameRequired") = ErrorMessage1
            ErrorLabel1.Visible = True
            ErrorLabel1.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If Owner1.Text = "" Then
            ViewState("TaskOwnerRequired") = ErrorMessage2
            ErrorLabel2.Visible = True
            ErrorLabel2.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        If Account1.Text = "" Then
            ViewState("TaskAccountRequired") = ErrorMessage3
            ErrorLabel3.Visible = True
            ErrorLabel3.ForeColor = Drawing.Color.Red
            Exit Sub
        End If


        Try
            Using (_dbMarkContext)

                Dim newTask1 As New Task11

                newTask1.TaskName = TaskName1.Text
                newTask1.Owner = Owner1.Text
                newTask1.DueDate = DueDate1.Text
                newTask1.Account = Account1.Text
                newTask1.Description = Description1.Text
                newTask1.OverrideRate = OverrideRate1.Text

                _dbMarkContext.Task1s.Add(newTask1)
                _dbMarkContext.SaveChanges()

            End Using
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Search1_Click(sender As Object, e As EventArgs) Handles Search1.Click
        Dim _dbMarkContext As New TaskContactDbContext

        Try
            Using (_dbMarkContext)

                Dim tasks1 As New List(Of MyTask)
                tasks1 = _dbMarkContext.MyTasks.ToList

                If _dbMarkContext.MyTasks.Count > 0 Then
                    For Each c1 In tasks1
                        _dbMarkContext.MyTasks.Remove(c1)
                    Next
                End If

                _dbMarkContext.SaveChanges()

                If TaskName1.Text <> "" Or Owner1.Text <> "" Or Account1.Text <> "" Then
                    If TaskName1.Text <> "" Then
                        If Owner1.Text <> "" Then
                            If Account1.Text <> "" Then
                                Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                    Where t1.TaskName.Contains(TaskName1.Text) And t1.Owner.Contains(Owner1.Text) And t1.Account.Contains(Account1.Text)
                                                    Select t1).ToList

                                If queryTask.Count > 0 Then
                                    queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                    Session("FoundTask") = True
                                    Exit Try
                                Else
                                    Session("FoundTask") = False
                                    Exit Try
                                End If

                            Else
                                Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                    Where t1.TaskName.Contains(TaskName1.Text) And t1.Owner.Contains(Owner1.Text)
                                                    Select t1).ToList

                                If queryTask.Count > 0 Then
                                    queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                    Session("FoundTask") = True
                                    Exit Try
                                Else
                                    Session("FoundTask") = False
                                    Exit Try
                                End If

                            End If
                        ElseIf Account1.Text <> "" Then
                            Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                Where t1.TaskName.Contains(TaskName1.Text) And t1.Account.Contains(Account1.Text)
                                                Select t1).ToList

                            If queryTask.Count > 0 Then
                                queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                Session("FoundTask") = True
                                Exit Try
                            Else
                                Session("FoundTask") = False
                                Exit Try
                            End If

                        Else
                            Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                Where t1.TaskName.Contains(TaskName1.Text)
                                                Select t1).ToList

                            If queryTask.Count > 0 Then
                                queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                Session("FoundTask") = True
                                Exit Try
                            Else
                                Session("FoundTask") = False
                                Exit Try
                            End If

                        End If
                    ElseIf Owner1.Text <> "" Then
                        If Account1.Text <> "" Then
                            Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                Where t1.Owner.Contains(Owner1.Text) And t1.Account.Contains(Account1.Text)
                                                Select t1).ToList

                            If queryTask.Count > 0 Then
                                queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                Session("FoundTask") = True
                                Exit Try
                            Else
                                Session("FoundTask") = False
                                Exit Try
                            End If

                        Else
                            Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                                Where t1.Owner.Contains(Owner1.Text)
                                                Select t1).ToList

                            If queryTask.Count > 0 Then
                                queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                                Session("FoundTask") = True
                                Exit Try
                            Else
                                Session("FoundTask") = False
                                Exit Try
                            End If
                        End If

                    ElseIf Account1.Text <> "" Then
                        Dim queryTask = (From t1 In _dbMarkContext.Task1s
                                            Where t1.Account.Contains(Account1.Text)
                                            Select t1).ToList
                        If queryTask.Count > 0 Then
                            queryTask = CreateMyTasks(queryTask, _dbMarkContext)
                            Session("FoundTask") = True
                            Exit Try
                        Else
                            Session("FoundTask") = False
                            Exit Try
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception

        End Try

        Session("SearchReturn") = True
        Session("TaskNameSearch") = TaskName1.Text
        Session("OwnerSearch") = Owner1.Text
        Session("AccountSearch") = Account1.Text

        Response.Redirect("~/TaskSearch1.aspx")

    End Sub

    Public Shared Function CreateMyTasks(queryTask As List(Of Task11), _dbMarkContext As TaskContactDbContext) As List(Of Task11)


        For Each c1 In queryTask
            Dim newMyTask As New MyTask
            newMyTask.MyTaskId = c1.TaskId
            newMyTask.TaskName = c1.TaskName
            newMyTask.Owner = c1.Owner
            newMyTask.DueDate = c1.DueDate
            newMyTask.Account = c1.Account
            newMyTask.Description = c1.Description
            newMyTask.OverrideRate = c1.OverrideRate

            _dbMarkContext.MyTasks.Add(newMyTask)
            _dbMarkContext.SaveChanges()
        Next

        Return queryTask
    End Function


End Class