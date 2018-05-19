using DevExpress.Web;
using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page {

    GridDataHelper gridDataHelper = new GridDataHelper();
    Dictionary<string, object> valuesForRowCopy;
    string[] fieldsForRowCopy = new string[] { "FirstName", "LastName", "BirthDate", "Title",  "HireDate", "DisplayOrder" };

    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void ASPxGridView1_FillContextMenuItems(object sender, ASPxGridViewContextMenuEventArgs e) {
        if(e.MenuType == GridViewContextMenuType.Rows) {
            var item = e.CreateItem("Copy", "Copy");
            item.Image.Url = "~/Images/Copy_16x16.png";
            e.Items.Insert(e.Items.IndexOfCommand(GridViewContextMenuCommand.Refresh), item);
        }
    }
    protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e) {
        CreateValuesDictionary(e);
        gridDataHelper.InsertNextToGridDataSet(valuesForRowCopy);
        ASPxGridView1.DataBind();
    }
    private void CreateValuesDictionary(ASPxGridViewCustomCallbackEventArgs e) {
        valuesForRowCopy = new Dictionary<string, object>();
        foreach(string fieldName in fieldsForRowCopy) {
            object value = ASPxGridView1.GetRowValues(int.Parse(e.Parameters), fieldName);
            valuesForRowCopy.Add(fieldName, value);
        }
    }
}