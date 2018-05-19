Option Infer On

Imports DevExpress.Web
Imports System
Imports System.Collections.Generic

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private gridDataHelper As New GridDataHelper()
    Private valuesForRowCopy As Dictionary(Of String, Object)
    Private fieldsForRowCopy() As String = { "FirstName", "LastName", "BirthDate", "Title", "HireDate", "DisplayOrder" }

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    Protected Sub ASPxGridView1_FillContextMenuItems(ByVal sender As Object, ByVal e As ASPxGridViewContextMenuEventArgs)
        If e.MenuType = GridViewContextMenuType.Rows Then
            Dim item = e.CreateItem("Copy", "Copy")
            item.Image.Url = "~/Images/Copy_16x16.png"
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item)
        End If
    End Sub
    Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
        CreateValuesDictionary(e)
        gridDataHelper.InsertNextToGridDataSet(valuesForRowCopy)
        ASPxGridView1.DataBind()
    End Sub
    Private Sub CreateValuesDictionary(ByVal e As ASPxGridViewCustomCallbackEventArgs)
        valuesForRowCopy = New Dictionary(Of String, Object)()
        For Each fieldName As String In fieldsForRowCopy
            Dim value As Object = ASPxGridView1.GetRowValues(Integer.Parse(e.Parameters), fieldName)
            valuesForRowCopy.Add(fieldName, value)
        Next fieldName
    End Sub
End Class