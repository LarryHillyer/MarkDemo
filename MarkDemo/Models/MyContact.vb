Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

Public Class MyContact

    <Key>
    Public Property MyContactId As Int32

    Public Property ContactId As Int32

    Public Property Title As String

    <Required>
    Public Property FirstName As String

    Public Property LastName As String

    Public Property Address As String

    Public Property City As String

    Public Property State As String

    <Required>
    Public Property PhoneNumber As String


End Class
