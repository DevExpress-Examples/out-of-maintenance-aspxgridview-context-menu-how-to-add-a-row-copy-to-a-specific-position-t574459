Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Web

<DataObject(True)> _
Public Class GridDataHelper


    Private gridDataSet_Renamed As List(Of GridData)

    Public ReadOnly Property GridDataSet() As List(Of GridData)
        Get
            If (HttpContext.Current.Session("DataSet") Is Nothing) Then
                HttpContext.Current.Session("DataSet") = CreateDataset()
                Return gridDataSet_Renamed
            Else
                Return DirectCast(HttpContext.Current.Session("DataSet"), List(Of GridData))
            End If
        End Get
    End Property

    Public Function CreateDataset() As List(Of GridData)
        gridDataSet_Renamed = New List(Of GridData)()
        gridDataSet_Renamed.Add(New GridData(1, "Nancy", "Davolio", New Date(1968, 12, 08), "Sales Representative", New Date(2012, 05, 01), 1))
        gridDataSet_Renamed.Add(New GridData(2, "Andrew", "Fuller", New Date(1972, 02, 19), "Vice President, Sales", New Date(2012, 08, 14), 2))
        gridDataSet_Renamed.Add(New GridData(3, "Janet", "Leverling", New Date(1972, 02, 19), "Sales Representative", New Date(2012, 04, 01), 3))
        gridDataSet_Renamed.Add(New GridData(4, "Margaret", "Peacock", New Date(1957, 09, 19), "Sales Representative", New Date(2013, 05, 03), 4))
        gridDataSet_Renamed.Add(New GridData(5, "Steven", "Buchanan", New Date(1975, 03, 04), "Sales Manager", New Date(2013, 10, 17), 5))

        Return gridDataSet_Renamed
    End Function

    <DataObjectMethod(DataObjectMethodType.Select, True)> _
    Public Function GetGridDataSet() As List(Of GridData)
        Return GridDataSet
    End Function

    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Sub DeleteFromGridDataSet(ByVal gridData As GridData)
        Dim employeeID As Integer = gridData.EmployeeID
        Dim tmp As New List(Of GridData)(GridDataSet)
        For Each item In tmp
            If item.EmployeeID = employeeID Then
                GridDataSet.Remove(item)
            End If
        Next item
    End Sub

    Public Sub InsertNextToGridDataSet(ByVal dictionary As Dictionary(Of String, Object))
        Dim last As GridData = GridDataSet.ElementAt(GridDataSet.Count - 1)
        Dim employeeID As Integer = last.EmployeeID + 1
        Dim firstName As String = dictionary("FirstName").ToString()
        Dim lastName As String = dictionary("LastName").ToString()
        Dim birthDate As Date = Date.Parse(dictionary("BirthDate").ToString())
        Dim title As String = dictionary("Title").ToString()
        Dim hireDate As Date = Date.Parse(dictionary("HireDate").ToString())
        Dim displayOrder As Integer = Integer.Parse(dictionary("DisplayOrder").ToString())
        Dim newEmployee As New GridData(employeeID, firstName, lastName, birthDate, title, hireDate, displayOrder + 1)
        For Each item In GridDataSet
            If item.DisplayOrder > displayOrder Then
                Dim index As Integer = GridDataSet.IndexOf(item)
                GridDataSet(index).DisplayOrder = item.DisplayOrder + 1
            End If
        Next item
        GridDataSet.Add(newEmployee)
    End Sub
End Class