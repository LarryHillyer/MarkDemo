Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema


Public Class Task11

    <Key>
    Public Property TaskId As Int32

    <Required>
    Public Property TaskName As String

    Public Property Team As String

    Public Property Owner As String

    Public Property DueDate As String

    Public Property DueTime As String

    Public Property AssignedDate As String

    Public Property AssignedTime As String

    <Required>
    Public Property Account As String

    Public Property OverrideRate As String

    <Required>
    Public Property Description As String

    Public Property Rate As Double


End Class
