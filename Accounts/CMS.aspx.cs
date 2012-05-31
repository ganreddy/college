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

public partial class Accounts_CMS : System.Web.UI.Page
{
    CommonDataBL objComm = new CommonDataBL();
    AccountsBL objAcc = new AccountsBL();
    DataSet ds = new DataSet();
    DataSet dsHead = new DataSet();
    DataSet dsSubHead = new DataSet();
    DataSet dsTemp = new DataSet();
    HtmlTable tblBA, tblAE;
    HtmlTableRow tblRow, trBA,trAE;
    HtmlTableCell  tcSrNo, tcHead, tcBANplan, tcBAPlan, tcAENplan, tcAEPlan, tcAETotal, tcAERemarks,tcTemp;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnPrint.Attributes.Add("onclick","javascript:return PrintWin();");
        btnSave.Attributes.Add("onclick", "javascript:return validations();");
        if (!IsPostBack)
        {
             for (int i = 2005; i < 2050; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlYear.Items.Insert(0, new ListItem("---Select---", "0"));
           
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ds = objComm.GetAccFundsI();
        char Sr = 'A';
        decimal CumTot = 0, MonTot = 0;
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    
                    tblRow = new HtmlTableRow();
                    tcSrNo=new HtmlTableCell();
                    tcSrNo.Style.Add("width","5%");
                    tcSrNo.InnerText = "( "+Sr.ToString()+" )";
                    tblRow.Cells.Add(tcSrNo);
                    tcHead = new HtmlTableCell();
                    tcHead.Style.Add("width", "35%");
                    tcHead.Style.Add("FONT-WEIGHT", "bold");
                    tcHead.InnerText = ds.Tables[0].Rows[i][1].ToString();
                    tblRow.Cells.Add(tcHead);

                    
                    tblBA = new HtmlTable();
                    //tblBA.Border = 1;
                    //tblBA.Attributes.Add("style","font-size:12px");
                    trBA = new HtmlTableRow();
                    tcBANplan = new HtmlTableCell();
                    tcBANplan.Style.Add("width", "10%");
                    trBA.Cells.Add(tcBANplan);
                    tcBAPlan = new HtmlTableCell();
                    tcBAPlan.Style.Add("width", "10%");
                    tcBAPlan.InnerHtml = "&nbsp;";
                    trBA.Cells.Add(tcBAPlan);
                    tblBA.Rows.Add(trBA);
                    tcTemp = new HtmlTableCell();
                    tcTemp.Controls.Add(tblBA);
                    tblRow.Cells.Add(tcTemp);

                    tblAE = new HtmlTable();
                    tblAE.Style.Add("width", "100%");
                    //tblAE.Attributes.Add("style", "font-size:12px");
                    trAE = new HtmlTableRow();
                    tcAENplan = new HtmlTableCell();
                    tcAENplan.Style.Add("width", "25%");
                    tcAENplan.InnerHtml = "&nbsp;";
                    trAE.Cells.Add(tcAENplan);
                    tcAEPlan = new HtmlTableCell();
                    tcAEPlan.Style.Add("width", "25%");
                    tcAEPlan.InnerHtml = "&nbsp;";
                    trAE.Cells.Add(tcAEPlan);
                    tcAETotal = new HtmlTableCell();
                    tcAETotal.Style.Add("width", "25%");
                    tcAETotal.InnerHtml = "&nbsp;";
                    trAE.Cells.Add(tcAETotal);
                    tcAERemarks = new HtmlTableCell();
                    tcAERemarks.Style.Add("width", "25%");
                    tcAERemarks.InnerHtml = "&nbsp;";
                    trAE.Cells.Add(tcAERemarks);
                    tblAE.Rows.Add(trAE);
                    tcTemp = new HtmlTableCell();
                    tcTemp.Controls.Add(tblAE);
                    tblRow.Cells.Add(tcTemp);
                    tblCMS.Rows.Add(tblRow);
                    
                    Sr++;
                    dsHead = objComm.GetAccountHead(Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString()));
                    if (dsHead.Tables.Count > 0)
                    {
                        if (dsHead.Tables[0].Rows.Count > 0)
                        {
                            for (int HC = 0; HC < dsHead.Tables[0].Rows.Count; HC++)
                            {
                                dsSubHead = objComm.GetAccountSubHead(Convert.ToInt32(dsHead.Tables[0].Rows[HC][0].ToString()));
                                char SSr = 'a';
                                if (dsSubHead.Tables.Count > 0)
                                {
                                    if (dsSubHead.Tables[0].Rows.Count > 0)
                                    {
                                        tblRow = new HtmlTableRow();
                                        tcSrNo = new HtmlTableCell();
                                        tcSrNo.Style.Add("width", "5%");
                                        tcSrNo.InnerText = Convert.ToString(HC + 1);
                                        tblRow.Cells.Add(tcSrNo);
                                        tcHead = new HtmlTableCell();
                                        tcHead.Style.Add("width", "35%");
                                        tcHead.Style.Add("FONT-WEIGHT", "bold");
                                        tcHead.InnerText = dsHead.Tables[0].Rows[HC][3].ToString();
                                        tblRow.Cells.Add(tcHead);

                                        tblBA = new HtmlTable();
                                        //tblBA.Attributes.Add("style", "font-size:12px");
                                        trBA = new HtmlTableRow();
                                        tcBANplan = new HtmlTableCell();
                                        tcBANplan.Style.Add("width", "10%");
                                        tcBANplan.InnerHtml = "&nbsp;";
                                        trBA.Cells.Add(tcBANplan);
                                        tcBAPlan = new HtmlTableCell();
                                        tcBAPlan.Style.Add("width", "10%");
                                        tcBAPlan.InnerHtml = "&nbsp;";
                                        trBA.Cells.Add(tcBAPlan);
                                        tblBA.Rows.Add(trBA);
                                        tcTemp = new HtmlTableCell();
                                        tcTemp.Controls.Add(tblBA);
                                        tblRow.Cells.Add(tcTemp);

                                        tblAE = new HtmlTable();
                                        tblAE.Style.Add("width", "100%");

                                        //tblAE.Attributes.Add("style", "font-size:12px");
                                        trAE = new HtmlTableRow();
                                        tcAENplan = new HtmlTableCell();
                                        tcAENplan.Style.Add("width", "25%");
                                        tcAENplan.InnerHtml = "&nbsp;";
                                        tcAENplan.Align = "right";
                                        trAE.Cells.Add(tcAENplan);
                                        tcAEPlan = new HtmlTableCell();
                                        tcAEPlan.Style.Add("width", "25%");
                                        tcAEPlan.InnerHtml = "&nbsp;";
                                        tcAEPlan.Align = "right";
                                        trAE.Cells.Add(tcAEPlan);
                                        tcAETotal = new HtmlTableCell();
                                        tcAETotal.Style.Add("width", "25%");
                                        tcAETotal.InnerHtml = "&nbsp;";
                                        tcAETotal.Align = "right";
                                        trAE.Cells.Add(tcAETotal);
                                        tcAERemarks = new HtmlTableCell();
                                        tcAERemarks.Style.Add("width", "25%");
                                        tcAERemarks.InnerHtml = "&nbsp;";
                                        tcAERemarks.Align = "right";
                                        trAE.Cells.Add(tcAERemarks);
                                        tblAE.Rows.Add(trAE);
                                        tcTemp = new HtmlTableCell();
                                        tcTemp.Controls.Add(tblAE);
                                        tblRow.Cells.Add(tcTemp);
                                        tblCMS.Rows.Add(tblRow);
                                        for (int SHC = 0; SHC < dsSubHead.Tables[0].Rows.Count; SHC++)
                                        {
                                            tblRow = new HtmlTableRow();
                                            tcSrNo = new HtmlTableCell();
                                            tcSrNo.Style.Add("width", "5%");
                                            tcSrNo.InnerHtml = "&nbsp;";
                                            tblRow.Cells.Add(tcSrNo);
                                            tcHead = new HtmlTableCell();
                                            tcHead.Style.Add("width", "35%");
                                            tcHead.InnerText = SSr.ToString() + ") " + dsSubHead.Tables[0].Rows[SHC][3].ToString();
                                            tblRow.Cells.Add(tcHead);

                                            dsTemp = objAcc.GetCMS(0, Convert.ToInt32(dsSubHead.Tables[0].Rows[SHC][0].ToString()),Convert.ToInt32(rdbPlan.SelectedValue),ddlYear.SelectedValue,Convert.ToInt32(ddlMnth.SelectedValue));
                                            tblBA = new HtmlTable();
                                            //tblBA.Attributes.Add("style", "font-size:12px");
                                            trBA = new HtmlTableRow();
                                            tcBANplan = new HtmlTableCell();
                                            tcBANplan.Style.Add("width", "10%");
                                            tcBANplan.InnerHtml = "&nbsp;";
                                            trBA.Cells.Add(tcBANplan);
                                            tcBAPlan = new HtmlTableCell();
                                            tcBAPlan.Style.Add("width", "10%");
                                            CumTot = CumTot + Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString());
                                            tcBAPlan.InnerHtml = dsTemp.Tables[0].Rows[0][0].ToString();
                                            tcBAPlan.Align = "right";
                                            trBA.Cells.Add(tcBAPlan);
                                            tblBA.Rows.Add(trBA);
                                            tcTemp = new HtmlTableCell();
                                            tcTemp.Controls.Add(tblBA);
                                            tblRow.Cells.Add(tcTemp);

                                            tblAE = new HtmlTable();
                                            tblAE.Style.Add("width", "100%");
                                            //tblAE.Attributes.Add("style", "font-size:12px");
                                            trAE = new HtmlTableRow();
                                            tcAENplan = new HtmlTableCell();
                                            tcAENplan.Style.Add("width", "25%");
                                            MonTot = MonTot + Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString());
                                            tcAENplan.InnerText = dsTemp.Tables[1].Rows[0][0].ToString();
                                            tcAENplan.Align = "right";
                                            trAE.Cells.Add(tcAENplan);
                                            tcAEPlan = new HtmlTableCell();
                                            tcAEPlan.Style.Add("width", "25%");
                                            tcAEPlan.InnerHtml = "&nbsp;";
                                            tcAEPlan.Align = "right";
                                            trAE.Cells.Add(tcAEPlan);
                                            //Balance=Balance-(Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString())+Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString()));
                                            tcAETotal = new HtmlTableCell();
                                            tcAETotal.Style.Add("width", "25%");
                                            tcAETotal.InnerHtml ="&nbsp;";
                                            tcAETotal.Align = "right";
                                            trAE.Cells.Add(tcAETotal);
                                            tcAERemarks = new HtmlTableCell();
                                            tcAERemarks.Style.Add("width", "25%");
                                            tcAERemarks.InnerHtml =Convert.ToString(Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString()) + Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString()));
                                            tcAERemarks.Align = "right";
                                            trAE.Cells.Add(tcAERemarks);
                                            tblAE.Rows.Add(trAE);
                                            tcTemp = new HtmlTableCell();
                                            tcTemp.Controls.Add(tblAE);
                                            tblRow.Cells.Add(tcTemp);
                                            tblCMS.Rows.Add(tblRow);

                                            SSr++;
                                        }

                                    }
                                    else
                                    {
                                        tblRow = new HtmlTableRow();
                                        tcSrNo = new HtmlTableCell();
                                        tcSrNo.Style.Add("width", "5%");
                                        tcSrNo.InnerText = Convert.ToString(HC + 1);
                                        tblRow.Cells.Add(tcSrNo);
                                        tcHead = new HtmlTableCell();
                                        tcHead.Style.Add("width", "35%");
                                        tcHead.Style.Add("FONT-WEIGHT", "bold");
                                        tcHead.InnerText = dsHead.Tables[0].Rows[HC][3].ToString();
                                        tblRow.Cells.Add(tcHead);

                                        dsTemp = objAcc.GetCMS(Convert.ToInt32(dsHead.Tables[0].Rows[HC][0].ToString()), 0, Convert.ToInt32(rdbPlan.SelectedValue), ddlYear.SelectedValue, Convert.ToInt32(ddlMnth.SelectedValue));
                                        tblBA = new HtmlTable();
                                        //tblBA.Attributes.Add("style", "font-size:12px");
                                        trBA = new HtmlTableRow();
                                        tcBANplan = new HtmlTableCell();
                                        tcBANplan.Style.Add("width", "10%");
                                        tcBANplan.InnerHtml = "&nbsp;";
                                        trBA.Cells.Add(tcBANplan);
                                        tcBAPlan = new HtmlTableCell();
                                        tcBAPlan.Style.Add("width", "10%");
                                        CumTot = CumTot + Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString());
                                        tcBAPlan.InnerHtml = dsTemp.Tables[0].Rows[0][0].ToString();
                                        tcBAPlan.Align = "right";
                                        trBA.Cells.Add(tcBAPlan);
                                        tblBA.Rows.Add(trBA);
                                        tcTemp = new HtmlTableCell();
                                        tcTemp.Controls.Add(tblBA);
                                        tblRow.Cells.Add(tcTemp);

                                        tblAE = new HtmlTable();
                                        tblAE.Style.Add("width", "100%");
                                        //tblAE.Attributes.Add("style", "font-size:12px");
                                        trAE = new HtmlTableRow();
                                        tcAENplan = new HtmlTableCell();
                                        tcAENplan.Style.Add("width", "25%");
                                        MonTot = MonTot + Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString());
                                        tcAENplan.InnerText = dsTemp.Tables[1].Rows[0][0].ToString();
                                        tcAENplan.Align = "right";
                                        trAE.Cells.Add(tcAENplan);
                                        tcAEPlan = new HtmlTableCell();
                                        tcAEPlan.Style.Add("width", "25%");
                                        tcAEPlan.InnerHtml = "&nbsp;";
                                        tcAEPlan.Align = "right";
                                        trAE.Cells.Add(tcAEPlan);
                                       // Balance = Balance - (Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString()) + Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString()));
                                        tcAETotal = new HtmlTableCell();
                                        tcAETotal.Style.Add("width", "25%");
                                        tcAETotal.InnerHtml = "&nbsp;";
                                        tcAETotal.Align = "right";
                                        trAE.Cells.Add(tcAETotal);
                                        tcAERemarks = new HtmlTableCell();
                                        tcAERemarks.Style.Add("width", "25%");
                                        tcAERemarks.InnerHtml = (Convert.ToDecimal(dsTemp.Tables[1].Rows[0][0].ToString()) + Convert.ToDecimal(dsTemp.Tables[0].Rows[0][0].ToString())).ToString(); ;
                                        tcAERemarks.Align = "right";
                                        trAE.Cells.Add(tcAERemarks);
                                        tblAE.Rows.Add(trAE);
                                        tcTemp = new HtmlTableCell();
                                        tcTemp.Controls.Add(tblAE);
                                        tblRow.Cells.Add(tcTemp);
                                        tblCMS.Rows.Add(tblRow);
                                    }
                                }

                            }
                        }
                    }
                    
                }
                
            }
        }
        tblRow = new HtmlTableRow();
        tcSrNo = new HtmlTableCell();
        tcSrNo.Style.Add("width", "5%");
        tcSrNo.InnerHtml = "&nbsp;";
        tblRow.Cells.Add(tcSrNo);
        tcHead = new HtmlTableCell();
        tcHead.Style.Add("width", "35%");
        tcHead.Style.Add("FONT-WEIGHT", "bold");
        tcHead.InnerText = "Total";
        tblRow.Cells.Add(tcHead);


        tblBA = new HtmlTable();
        //tblBA.Attributes.Add("style","font-size:12px");
        trBA = new HtmlTableRow();
        tcBANplan = new HtmlTableCell();
        tcBANplan.Style.Add("width", "10%");
        trBA.Cells.Add(tcBANplan);
        tcBAPlan = new HtmlTableCell();
        tcBAPlan.Style.Add("width", "10%");
        tcBAPlan.InnerHtml = CumTot.ToString();
        tcBAPlan.Align = "right";
        trBA.Cells.Add(tcBAPlan);
        tblBA.Rows.Add(trBA);
        tcTemp = new HtmlTableCell();
        tcTemp.Controls.Add(tblBA);
        tblRow.Cells.Add(tcTemp);

        tblAE = new HtmlTable();
        tblAE.Style.Add("width", "100%");
        //tblAE.Attributes.Add("style", "font-size:12px");
        trAE = new HtmlTableRow();
        tcAENplan = new HtmlTableCell();
        tcAENplan.Style.Add("width", "25%");
        tcAENplan.InnerHtml = MonTot.ToString();
        tcAENplan.Align = "right";
        trAE.Cells.Add(tcAENplan);
        tcAEPlan = new HtmlTableCell();
        tcAEPlan.Style.Add("width", "25%");
        tcAEPlan.InnerHtml = "&nbsp;";
        trAE.Cells.Add(tcAEPlan);
        tcAETotal = new HtmlTableCell();
        tcAETotal.Style.Add("width", "25%");
        tcAETotal.InnerHtml = "&nbsp;";
        trAE.Cells.Add(tcAETotal);
        tcAERemarks = new HtmlTableCell();
        tcAERemarks.Style.Add("width", "25%");
        tcAERemarks.InnerHtml = Convert.ToString(CumTot+MonTot);
        tcAERemarks.Align = "right";
        trAE.Cells.Add(tcAERemarks);
        tblAE.Rows.Add(trAE);
        tcTemp = new HtmlTableCell();
        tcTemp.Controls.Add(tblAE);
        tblRow.Cells.Add(tcTemp);
        tblCMS.Rows.Add(tblRow);
    }
}
