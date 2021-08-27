<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134059448/17.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T574459)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GridData.cs](./CS/App_Code/GridData.cs) (VB: [GridDataHelper.vb](./VB/App_Code/GridDataHelper.vb))
* [GridDataHelper.cs](./CS/App_Code/GridDataHelper.cs) (VB: [GridDataHelper.vb](./VB/App_Code/GridDataHelper.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView Context menu - How to add a row copy to a specific position
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t574459/)**
<!-- run online end -->


<p>This example demonstrates how to add a row copy to a specific position of <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridView.class">ASPxGridView</a>. The <a href="https://documentation.devexpress.com/AspNet/DevExpress.Web.ASPxGridViewFillContextMenuItemsEventHandler.delegate">FillContextMenuItems</a> event handler is used to add a copy item to the context menu. When a user clicks the copy item, the <strong>CreateValuesDictionary</strong> method creates a copy of fields of the current row. Then, this copy is used to populate fields of the new row in the <strong>InsertNextToGridDataSet</strong> method. To keep the order of rows, it is necessary to set up an extra column to store order indexes; and then sort the ASPxGridView by this column.</p>

<br/>


