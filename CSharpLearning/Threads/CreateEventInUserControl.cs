using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpLearning.Threads
{
    public partial class MyUserControl //: System.Web.UI.UserControl
    {
        // Declare an event
        public event EventHandler ActionOccurred;

        protected void btnDoSomething_Click(object sender, EventArgs e)
        {
            // Perform your action here...

            // Raise the event to notify the parent page
            ActionOccurred?.Invoke(this, EventArgs.Empty);
        }
    }

    public partial class ParentPage //: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            {
                LoadGridView(); // Initial load of the GridView
            }

            // Attach the event handler to the user control's event
            MyUserControl.ActionOccurred += new EventHandler(UserControl_ActionOccurred);
        }

        // Event handler method
        protected void UserControl_ActionOccurred(object sender, EventArgs e)
        {
            // Reload the GridView
            LoadGridView();
        }

        // Method to load or reload the GridView data
        private void LoadGridView()
        {
            // Code to bind data to the GridView
            //GridView1.DataSource = GetData();
            //GridView1.DataBind();
        }

        // Sample method to get data (replace with actual data source)
        //private DataTable GetData()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Column1");
        //    dt.Columns.Add("Column2");

        //    dt.Rows.Add("Data 1", "Data 2");
        //    dt.Rows.Add("Data 3", "Data 4");

        //    return dt;
        //}
    }

    public partial class ParentPage //: System.Web.UI.Page  // Desing
    {
        MyUserControl MyUserControl = new MyUserControl();
    }
    class CreateEventInUserControl
    {
    }
}
