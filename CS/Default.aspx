<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.18.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPXGridView Context menu - Add a copy of a row into the required position</title>
    <script type="text/javascript">
        function OnContextMenuItemClick(s, e) {
            if (e.item.name == "Copy") {
                ASPxGridView1.PerformCallback(e.elementIndex);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="ASPxGridView1" ClientInstanceName="ASPxGridView1" runat="server" AutoGenerateColumns="False"
                DataSourceID="ObjectDataSource1" KeyFieldName="EmployeeID"
                OnFillContextMenuItems="ASPxGridView1_FillContextMenuItems"
                OnCustomCallback="ASPxGridView1_CustomCallback">
                <ClientSideEvents ContextMenuItemClick="OnContextMenuItemClick" />
                <Columns>
                    <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="1"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="BirthDate" VisibleIndex="2"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3"></dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="HireDate" VisibleIndex="4"></dx:GridViewDataDateColumn>
                    <dx:GridViewDataTextColumn FieldName="EmployeeID" VisibleIndex="5" ReadOnly="True">
                        <EditFormSettings Visible="False"></EditFormSettings>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DisplayOrder" VisibleIndex="6" SortIndex="0" SortOrder="Ascending" Visible="false">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <SettingsContextMenu EnableRowMenu="True">
                    <RowMenuItemVisibility NewRow="false" Refresh="false" EditRow="false"></RowMenuItemVisibility>
                </SettingsContextMenu>
            </dx:ASPxGridView>
            <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" DataObjectTypeName="GridData" OldValuesParameterFormatString="original_{0}" 
                SelectMethod="GetGridDataSet" TypeName="GridDataHelper" 
                DeleteMethod="DeleteFromGridDataSet"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
