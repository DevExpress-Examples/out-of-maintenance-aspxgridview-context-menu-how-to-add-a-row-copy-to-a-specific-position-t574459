Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class GridData

    Public Sub New()

    End Sub
    Public Sub New(ByVal employeeID As Integer, ByVal firstName As String, ByVal lastName As String, ByVal birthDate As Date, ByVal title As String, ByVal hireDate As Date, ByVal displayOrder As Integer)
        Me.EmployeeID = employeeID
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.BirthDate = birthDate
        Me.Title = title
        Me.HireDate = hireDate
        Me.DisplayOrder = displayOrder
    End Sub
    Public Property EmployeeID() As Integer
    Public Property FirstName() As String
    Public Property LastName() As String
    Public Property BirthDate() As Date
    Public Property Title() As String
    Public Property HireDate() As Date
    Public Property DisplayOrder() As Integer
    Public ReadOnly Property FullName() As String
        Get
            Return String.Format("{0} {1}", FirstName, LastName)
        End Get
    End Property

End Class