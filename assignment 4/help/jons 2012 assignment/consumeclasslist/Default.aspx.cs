using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using localhost;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      ClassListServiceClient client = new ClassListServiceClient();

      Student[] students = client.GetData();

      foreach (Student S in students)
      {
        lstStudents.Items.Add(S.FullInfo);
      }

      gvStudents.DataSource = students;
      gvStudents.DataBind(); 
    }
}