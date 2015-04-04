Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure


Public Class TaskContactDbContext
    Inherits DbContext

    Public Property Task1s As DbSet(Of Task11)
    Public Property Contact1s As DbSet(Of Contact1)
    Public Property MyContacts As DbSet(Of MyContact)
    Public Property MyTasks As DbSet(Of MyTask)
End Class
