using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FurnitureStore
{
    public partial class SearchFilter : System.Web.UI.UserControl
    {

        int furnitureId;
        string searchTerm;
        string filterDdl;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
                filterDdl = DropDownList1.SelectedItem.Value;
                searchTerm = txtSearch.Text;
        //    }
        }

        [Category("Misc")]
        public int FurnitureId
        {
            get { return furnitureId; }
            set { furnitureId = value; }
        }

        [Category("Misc")]
        public string SearchTerm
        {
            get { return searchTerm; }
            set { searchTerm = value; }
        }

        [Category("Misc")]
        public string FilterDdl
        {
            get { return filterDdl; }
            set { filterDdl = value; }
        }
        [Category("Misc")]
        public string getFilter()
        {
            return DropDownList1.SelectedItem.Value;
        }
        [Category("Misc")]
        public string getSearch()
        {
            return txtSearch.Text;
        }

        [Category("Misc")]
        public void setFilter(string filt)
        {
            DropDownList1.SelectedItem.Value = filt;
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterDdl = DropDownList1.SelectedItem.Value;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchTerm = txtSearch.Text;
        }
    }
}