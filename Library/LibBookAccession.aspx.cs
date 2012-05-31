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

public partial class LibBookAccession : System.Web.UI.Page
{
    DataSet ds;
    BusinessLayer.LibraryBL objLibrary = new LibraryBL();
    BusinessLayer.CommonDataBL objComm = new CommonDataBL();
    int BookID;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds = new DataSet();
        btnSave.Attributes.Add("onclick", "javascript:return RequiredValidate();");
        if (!IsPostBack)
        {
            ds = objComm.GetMedium();
            ddlMediumOfBook.DataSource = ds.Tables[0];
            ddlMediumOfBook.DataTextField = "Language";
            ddlMediumOfBook.DataValueField = "MediumID";
            ddlMediumOfBook.DataBind();
            ddlMediumOfBook.Items.Insert(0, new ListItem("---Select---", "0"));
            ds = objLibrary.GetLibBookCategory();
            ddlBookCategory.DataSource = ds.Tables[0];
            ddlBookCategory.DataTextField = "Category";
            ddlBookCategory.DataValueField = "CategoryID";
            ddlBookCategory.DataBind();
            ddlBookCategory.Items.Insert(0, new ListItem("---Select---", "0"));

            for (int i = 1979; i < 2050; i++)
            {
                ddlYearofPublication.Items.Add(new ListItem(i.ToString(), i.ToString()));

            }
            ddlYearofPublication.Items.Insert(0, new ListItem("---Select---", "0"));

            ds = objComm.GetSubject();
            ddlSubject.DataSource = ds.Tables[0];
            ddlSubject.DataTextField = "SubjectName";
            ddlSubject.DataValueField = "SubjectID";
            ddlSubject.DataBind();
            ddlSubject.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlSubCategory.Items.Insert(0, new ListItem("---Select---", "0"));


            if (Request.QueryString["ID"] != null)
            {
                 BookID = Convert.ToInt32(Request.QueryString["ID"].ToString());
                ds = objLibrary.GetLibBookData(BookID);
                txtBookno.Text = ds.Tables[0].Rows[0]["AccessionNo"].ToString();
                txtClassification.Text = ds.Tables[0].Rows[0]["Classification"].ToString();
                txtTitle.Text = ds.Tables[0].Rows[0]["Title"].ToString();
                ddlBookCategory.SelectedValue = ds.Tables[0].Rows[0]["CategoryID"].ToString();
                txtDate.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofAccession"].ToString()).ToShortDateString());
                ddlSubCategory.SelectedValue = ds.Tables[0].Rows[0]["SubCategoryID"].ToString();
                ddlMediumOfBook.SelectedValue = ds.Tables[0].Rows[0]["MediumID"].ToString();
                txtPhysicalDescription.Text = ds.Tables[0].Rows[0]["PhysicalDesc"].ToString();
                txtAuthors.Text = ds.Tables[0].Rows[0]["Author"].ToString();
                txtEdition.Text = ds.Tables[0].Rows[0]["Edition"].ToString();
                txtPublisher.Text = ds.Tables[0].Rows[0]["Publisher"].ToString();
                ddlYearofPublication.SelectedValue = ds.Tables[0].Rows[0]["YearofPublication"].ToString();
                txtPlaceofPublication.Text = ds.Tables[0].Rows[0]["PlaceofPublication"].ToString();
                ddlTypeOfBook.SelectedValue = ds.Tables[0].Rows[0]["TypeofBook"].ToString();
                txtIsbnNo.Text = ds.Tables[0].Rows[0]["ISBNNO"].ToString();
                ddlSubject.SelectedValue = ds.Tables[0].Rows[0]["SubjectId"].ToString();
                txtCost.Text = ds.Tables[0].Rows[0]["Cost"].ToString();
                ddlTypeOfCurrency.SelectedValue = ds.Tables[0].Rows[0]["TypeofCurrency"].ToString();
                txtVolume.Text = ds.Tables[0].Rows[0]["Volume"].ToString();
                //txtInvoiceNo.Text = ds.Tables[0].Rows[0]["Volume"].ToString();
                txtDateOfInvoice.Text =ChangeDateFormat(Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofInvoice"].ToString()).ToShortDateString());
                ddlBookStatus.SelectedValue = ds.Tables[0].Rows[0]["BookStatus"].ToString();
                txtVendor.Text = ds.Tables[0].Rows[0]["Vendor"].ToString();
                txtClassNumber.Text = ds.Tables[0].Rows[0]["ClassNo"].ToString();
                txtBookNumber.Text = ds.Tables[0].Rows[0]["BookNO"].ToString();
                txtNoPgs.Text =ds.Tables[0].Rows[0]["Pagination"].ToString();
                ddlSrc.SelectedValue = ds.Tables[0].Rows[0]["Source"].ToString();

                btnSave.Text = "Update";
            }

        }
    }
    protected void ddlBookCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = objLibrary.GetLibBookSubCategory(Convert.ToInt32(ddlBookCategory.Items[ddlBookCategory.SelectedIndex].Value));
        ddlSubCategory.DataSource = ds.Tables[0];
        ddlSubCategory.DataTextField = "SubCategory";
        ddlSubCategory.DataValueField = "SubCategoryID";
        ddlSubCategory.DataBind();
        ddlSubCategory.Items.Insert(0, new ListItem("---Select---", "0"));

    }
    protected void ddlSrc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSrc.SelectedIndex == 5)
        {
            trOtherSrc.Visible = true;
        }
        else
        {
            trOtherSrc.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //int BookID;
        
        string DateofAccession = String.Empty, DateofInvoice = String.Empty;
        string AccessionNo, Title, Authors, Publisher, PlaceofPublication, ISBN,Volume,InvoiceNo,ClassNo,Classification,PhyDesc,Edition,YearofPubl,Vendor,BookNo,OtherSrc;
        decimal Cost;
        int BookStatus,Pagination=0,TypeofBook,Subject,TypeofCurrency,Collections=0,Source,Medium,Category=0,SubCategory=0;
        if (txtDateOfInvoice.Text != "")
            DateofAccession = ChangeDateFormat(txtDate.Text);
        if (txtDateOfInvoice.Text != "")
            DateofInvoice = ChangeDateFormat(txtDateOfInvoice.Text);
        AccessionNo = txtBookno.Text;
        Title = txtTitle.Text;
        Authors = txtAuthors.Text;
        Publisher = txtPublisher.Text;
        PlaceofPublication = txtPlaceofPublication.Text;
        ISBN = txtIsbnNo.Text;
        Volume = txtVolume.Text;
        InvoiceNo = txtInvoiceNo.Text;
        ClassNo = txtClassNumber.Text;
        Classification = txtClassification.Text;
        PhyDesc = txtPhysicalDescription.Text;
        Edition = txtEdition.Text;
        YearofPubl = ddlYearofPublication.Items[ddlYearofPublication.SelectedIndex].Value;
        Vendor = txtVendor.Text;
        BookNo = txtBookno.Text;
        OtherSrc = txtOthers.Text;
        Cost = Convert.ToDecimal(txtCost.Text);
        Category = Convert.ToInt32(ddlBookCategory.Items[ddlBookCategory.SelectedIndex].Value);
        SubCategory = Convert.ToInt32(ddlSubCategory.Items[ddlSubCategory.SelectedIndex].Value);
        BookStatus = Convert.ToInt32(ddlBookStatus.Items[ddlBookStatus.SelectedIndex].Value);
        if (txtNoPgs.Text != "")
            Pagination = Convert.ToInt32(txtNoPgs.Text);
        TypeofBook = Convert.ToInt32(ddlTypeOfBook.Items[ddlTypeOfBook.SelectedIndex].Value);
        Subject = Convert.ToInt32(ddlSubject.Items[ddlSubject.SelectedIndex].Value);
        TypeofCurrency = Convert.ToInt32(ddlTypeOfCurrency.Items[ddlTypeOfCurrency.SelectedIndex].Value);
        if (rbCirculation.Checked) Collections = 1;
        if (rbReference.Checked) Collections = 2;
        Source = Convert.ToInt32(ddlSrc.Items[ddlSrc.SelectedIndex].Value);
        Medium = Convert.ToInt32(ddlMediumOfBook.Items[ddlMediumOfBook.SelectedIndex].Value);
        int i;

        if (Request.QueryString["ID"] == null)
        {
          i= objLibrary.AddLibraryBooks(AccessionNo, Title, Convert.ToDateTime(DateofAccession), Medium, Authors, Publisher, PlaceofPublication, ISBN, Cost, Volume, BookStatus, ClassNo, Pagination, Classification, Category, SubCategory, TypeofBook, PhyDesc, Edition, YearofPubl, Subject, TypeofCurrency, Collections, Convert.ToDateTime(DateofInvoice), Vendor, BookNo, Source, OtherSrc);
          lblMessage1.Attributes.Add("style", "color:red;font-weight:bold;");
          lblMessage1.Text = "Book Add Successfully";     
        }
        else
        {
            BookID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            i= objLibrary.UpdateLibraryBooks(BookID, AccessionNo, Title, Convert.ToDateTime(DateofAccession), Medium, Authors, Publisher, PlaceofPublication, ISBN, Cost, Volume, BookStatus, ClassNo, Pagination, Classification, Category, SubCategory, TypeofBook, PhyDesc, Edition, YearofPubl, Subject, TypeofCurrency, Collections, Convert.ToDateTime(DateofInvoice), Vendor, BookNo, Source, OtherSrc);
            lblMessage1.Attributes.Add("style", "color:red;font-weight:bold;");
            lblMessage1.Text = "Book Updated Successfully";
            Response.Redirect("LibraryBookDetails.aspx?ID=" + BookID.ToString());
        }

        if (Request.QueryString["ID"] == null)
        {
            Response.Redirect("LibraryBookDetails.aspx?ID=" + i.ToString());
        }
        else
        {
            Response.Redirect("LibraryBookDetails.aspx?ID=" + BookID.ToString());
        }
        

    }
    public string ChangeDateFormat(string Date)
    {
        return Date.Split('/')[1].ToString() + "/" + Date.Split('/')[0].ToString() + "/" + Date.Split('/')[2].ToString();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtBookno.Text = "";
        ddlMediumOfBook.SelectedIndex = 0;
        txtIsbnNo.Text = "";
        txtCost.Text = "";
        ddlBookStatus.SelectedIndex = 0;
        txtClassNumber.Text = "";
        ddlBookCategory.SelectedIndex = 0;
        txtPhysicalDescription.Text = "";
        ddlTypeOfBook.SelectedIndex = 0;
        txtDateOfInvoice.Text = "";
        txtBookNumber.Text = "";
    }
}
