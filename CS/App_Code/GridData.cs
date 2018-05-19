using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class GridData {

    public GridData() {

    }
    public GridData(int employeeID, string firstName, string lastName, DateTime birthDate, string title, DateTime hireDate, int displayOrder) {
        EmployeeID = employeeID;
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Title = title;
        HireDate = hireDate;
        DisplayOrder = displayOrder;
    }
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Title { get; set; }
    public DateTime HireDate { get; set; }
    public int DisplayOrder { get; set; }
    public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

}