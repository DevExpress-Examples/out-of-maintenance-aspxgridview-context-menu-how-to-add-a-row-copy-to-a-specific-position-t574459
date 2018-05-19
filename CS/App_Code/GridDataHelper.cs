using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

[DataObject(true)]
public class GridDataHelper {

    List<GridData> gridDataSet;

    public List<GridData> GridDataSet {
        get {
            if((HttpContext.Current.Session["DataSet"] == null)) {
                HttpContext.Current.Session["DataSet"] = CreateDataset();
                return gridDataSet;
            } else {
                return (List<GridData>)HttpContext.Current.Session["DataSet"];
            }
        }
    }

    public List<GridData> CreateDataset() {
        gridDataSet = new List<GridData>();
        gridDataSet.Add(new GridData(1, "Nancy", "Davolio", new DateTime(1968, 12, 08), "Sales Representative", new DateTime(2012, 05, 01), 1));
        gridDataSet.Add(new GridData(2, "Andrew", "Fuller", new DateTime(1972, 02, 19), "Vice President, Sales", new DateTime(2012, 08, 14), 2));
        gridDataSet.Add(new GridData(3, "Janet", "Leverling", new DateTime(1972, 02, 19), "Sales Representative", new DateTime(2012, 04, 01), 3));
        gridDataSet.Add(new GridData(4, "Margaret", "Peacock", new DateTime(1957, 09, 19), "Sales Representative", new DateTime(2013, 05, 03), 4));
        gridDataSet.Add(new GridData(5, "Steven", "Buchanan", new DateTime(1975, 03, 04), "Sales Manager", new DateTime(2013, 10, 17), 5));

        return gridDataSet;
    }

    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public List<GridData> GetGridDataSet() {
        return GridDataSet;
    }

    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public void DeleteFromGridDataSet(GridData gridData) {
        int employeeID = gridData.EmployeeID;
        List<GridData> tmp = new List<GridData>(GridDataSet);
        foreach(var item in tmp) {
            if(item.EmployeeID == employeeID)
                GridDataSet.Remove(item);
        }
    }

    public void InsertNextToGridDataSet(Dictionary<string, object> dictionary) {
        GridData last = GridDataSet.ElementAt(GridDataSet.Count - 1);
        int employeeID = last.EmployeeID + 1;
        string firstName = dictionary["FirstName"].ToString();
        string lastName = dictionary["LastName"].ToString();
        DateTime birthDate = DateTime.Parse(dictionary["BirthDate"].ToString());
        string title = dictionary["Title"].ToString();
        DateTime hireDate = DateTime.Parse(dictionary["HireDate"].ToString());
        int displayOrder = int.Parse(dictionary["DisplayOrder"].ToString());
        GridData newEmployee = new GridData(employeeID, firstName, lastName, birthDate, title, hireDate, displayOrder + 1);
        foreach(var item in GridDataSet) {
            if(item.DisplayOrder > displayOrder) {
                int index = GridDataSet.IndexOf(item);
                GridDataSet[index].DisplayOrder = item.DisplayOrder + 1;
            }
        }
        GridDataSet.Add(newEmployee);
    }
}