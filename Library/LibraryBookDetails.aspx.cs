using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLayer;

public partial class Library_LibraryBookDetails : System.Web.UI.Page
{
    BusinessLayer.LibraryBL objLib = new LibraryBL();
    DataSet ds;
    int BookID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = new DataSet();
        if (Request.QueryString["ID"] != null)
        {
            BookID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            ds = objLib.GetLibBookData(BookID);
            if(ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count > 0)
               {
                  
                       lblAccessionNo.Text = ds.Tables[0].Rows[0]["AccessionNo"].ToString();
                       lblClassification.Text = ds.Tables[0].Rows[0]["Classification"].ToString();
                       lblTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                       lblCategory.Text = ds.Tables[0].Rows[0]["BookCategory"].ToString();
                       lblDateOfAccession.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofAccession"].ToString()).ToShortDateString());
                       lblSubCategory.Text = ds.Tables[0].Rows[0]["SubCategory"].ToString();
                       lblMEdiumOfBook.Text = ds.Tables[0].Rows[0]["Medium"].ToString();
                       lblPhysicalDesc.Text = ds.Tables[0].Rows[0]["PhysicalDesc"].ToString();
                       lblAuthor.Text = ds.Tables[0].Rows[0]["Author"].ToString();
                       lblEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                       lblPublisher.Text = ds.Tables[0].Rows[0]["Publisher"].ToString();
                       lblYearOfPublication.Text = ds.Tables[0].Rows[0]["YearofPublication"].ToString();
                       lblPlaceOfPublication.Text = ds.Tables[0].Rows[0]["PlaceofPublication"].ToString();

                       if (ds.Tables[0].Rows[0]["TypeofBook"].ToString() == "1")
                           lblTypeOfBook.Text = "Hard Bound";
                       if (ds.Tables[0].Rows[0]["TypeofBook"].ToString() == "2")
                           lblTypeOfBook.Text = "Paper Bound";
                       lblISBN.Text = ds.Tables[0].Rows[0]["ISBNNO"].ToString();
                       lblSubject.Text = ds.Tables[0].Rows[0]["BookSubject"].ToString();
                       lblCost.Text = ds.Tables[0].Rows[0]["Cost"].ToString();
                       if (ds.Tables[0].Rows[0]["TypeofCurrency"].ToString() == "1")
                           lblTypeOfCurrency.Text = "Indian Rupee";
                       if (ds.Tables[0].Rows[0]["TypeofCurrency"].ToString() == "2")
                           lblTypeOfCurrency.Text = "US Dollar";
                       if (ds.Tables[0].Rows[0]["TypeofCurrency"].ToString() == "3")
                           lblTypeOfCurrency.Text = "Euro";
                       if (ds.Tables[0].Rows[0]["TypeofCurrency"].ToString() == "4")
                           lblTypeOfCurrency.Text = "Pound";
                       lblVolume.Text = ds.Tables[0].Rows[0]["Volume"].ToString();
                       if (ds.Tables[0].Rows[0]["Collections"].ToString() == "1")
                           lblCollections.Text = "Circullar";
                       if (ds.Tables[0].Rows[0]["Collections"].ToString() == "2")
                           lblCollections.Text = "Reference";

                       lblDateOfInvoice.Text = ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofInvoice"].ToString()).ToShortDateString());
                       if (ds.Tables[0].Rows[0]["BookStatus"].ToString() == "1")
                           lblBookStatus.Text = "In Library";
                       if (ds.Tables[0].Rows[0]["BookStatus"].ToString() == "2")
                           lblBookStatus.Text = "Out Library";

                       lblVendor.Text = ds.Tables[0].Rows[0]["Vendor"].ToString();
                       lblClassNo.Text = ds.Tables[0].Rows[0]["ClassNo"].ToString();
                       lblBookNo.Text = ds.Tables[0].Rows[0]["BookNO"].ToString();
                       lblPagination.Text = ds.Tables[0].Rows[0]["Pagination"].ToString();
                       if (ds.Tables[0].Rows[0]["Source"].ToString() == "1")
                           lblSource.Text = "NVS HO";
                       if (ds.Tables[0].Rows[0]["Source"].ToString() == "2")
                           lblSource.Text = "NVS RO";
                       if (ds.Tables[0].Rows[0]["Source"].ToString() == "3")
                           lblSource.Text = "Local Purchase";
                       if (ds.Tables[0].Rows[0]["Source"].ToString() == "4")
                           lblSource.Text = "Gift";
                       if (ds.Tables[0].Rows[0]["Source"].ToString() == "5")
                           lblSource.Text = "Others";
                  
                }


            }
        }
    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        Response.Redirect("LibBookAccession.aspx?ID=" + BookID + "");
    }
}
