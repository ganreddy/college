<%@ Page Title="Student Details By Name Report" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StdDetailByName.aspx.cs" Inherits="student_StdDetailByName" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function CheckRadio(rowindex) 
        {
            var count = 0;
            var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
            for (var i = 1; i < tableElement.rows.length; i++)
             {
                var rowElem = tableElement.rows[i];
                var cell = rowElem.cells[0];
                //alert(cell);
                if (cell.childNodes[0].type == "radio") 
                {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[0].checked = false;
                }

            }
            tableElement.rows[rowindex + 1].cells[0].childNodes[0].checked = true;
           // document.getElementById('<%=txtAdmissionNo.ClientID%>').value = tableElement.rows[rowindex + 1].cells[2].childNodes[0].innerText;


         }
        
        function window.onload() 
        {
            ShowHide();
        }
        
        
        function ShowHide() 
        {
            if (document.getElementById('<%=rdbName.ClientID%>').checked) 
            {
                document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "none";
                document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "inline";
                //alert(document.getElementById('<%=gdvStud.ClientID%>').style.display);
               
            }
            if (document.getElementById('<%=rdbAdminNo.ClientID%>').checked) 
            {
                document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "inline";
                document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "none";
                //alert(document.getElementById('<%=gdvStud.ClientID%>').style.display);
                
            }
            //if (document.getElementById('<%=gdvStud.ClientID%>'). == "") {
            
               // document.getElementById('<%=gdvStud.ClientID%>').style.display = "none";
            //}
            //else {
            //    document.getElementById('<%=gdvStud.ClientID%>').style.display = "inline";
           // }
            
            return;
        }
        
        
        function gridvalidatio() {
            if (document.getElementById('<%=gdvStud.ClientID%>') != null) {


                if (document.getElementById('<%=rdbName.ClientID%>').checked == true) {
                    if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
                    if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
                    if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Section")) return false;
                    document.getElementById('<%=gdvStud.ClientID%>').style.display = "none";
                }
                else {
                    document.getElementById('<%=gdvStud.ClientID%>').style.display = "inline";
                
                }
            }

                var count = 0;
                var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
                for (var i = 1; i < tableElement.rows.length; i++) 
                {
                    var rowElem = tableElement.rows[i];
                    var cell = rowElem.cells[0];
                    //alert(cell);
                    if (cell.childNodes[0].type == "radio")
                     {
                         if (cell.childNodes[0].checked == true)
                         {
                            count = 1;
                            break;
                        }
                    }

                }
                if (count == 0) 
                {

                    alert("Please Select Radio Button");
                    return false;
                }
                


            }
            function validation() {
                if (!isEmpty('<%=txtAdmissionNo.ClientID%>', "Please Enter Name")) return false;
            }

            function Check(check,lbl,txttotal) {
        var txt1, check1, txt2;
        //txt1 = document.getElementById(lbl);
                
        check1 = document.getElementById(check);
        txt2 = document.getElementById(txttotal);
       
        if (check1.checked == true) {
            txt2.value =lbl
        }
        
        }

    </script>
    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <%--<asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>--%>
            <table align="center" width="90%" border="0">
                <tr>
                    <td>
                        <asp:HiddenField ID="hdntransfer" runat="server"></asp:HiddenField>
                    </td>
                </tr>
                <tr>
                    <td class="heading" colspan="2" style="text-align: center" width="100%">
                        STUDENT TC REPORT
                    </td>
                </tr>
                <tr>
                    <td class="subhead">
                        Search By:
                    </td>
                    <td class="subhead">
                        <asp:RadioButton ID="rdbAdminNo" runat="server" class="subhead" ForeColor="Black"
                            GroupName="rbOnly" Text="By Name" />&nbsp;
                        <asp:RadioButton ID="rdbName" runat="server" class="subhead" ForeColor="Black" GroupName="rbOnly"
                            Text="By Class" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlAdmSearch" runat="server">
                            <table width="100%" border="0">
                                <tr>
                                    <td class="subhead" >
                                        Student Name:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAdmissionNo" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" 
                                             />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="pnlSearchName" runat="server">
                            <table width="100%">
                                <tr>
                                    <td class="subhead" >
                                        Batch <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlBatch" runat="server" AutoPostBack="true" Width="155px"
                                            Height="16%" onselectedindexchanged="ddlBatch_SelectedIndexChanged"  >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" style="height: 26px" >
                                        Class <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td style="height: 26px">
                                        <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" Width="155px"
                                            Height="16%" onselectedindexchanged="ddlClasses_SelectedIndexChanged"  >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="subhead" >
                                        Section <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSections" runat="server" AutoPostBack="True" Width="155px"
                                            Height="16%" onselectedindexchanged="ddlSections_SelectedIndexChanged"  >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr id="trSearch" runat="server">
                    <td colspan="2" align="center">
                        
                        <asp:GridView ID="gdvStud" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                                CellSpacing="2" ondatabound="gdvStud_DataBound" 
                            onrowcommand="gdvStud_RowCommand" onrowediting="gdvStud_RowEditing"  
                                                 >
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <RowStyle CssClass="gridviewitem" />
                                                <SelectedRowStyle Font-Bold="True" />
                                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStudId" runat="server" Text='<%#Bind("StudID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rdbSelect" runat="server" GroupName="rdb" AutoPostBack="true" ></asp:RadioButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFullName" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Admission No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAdmisNo" runat="server" Text='<%#Bind("AdmissionNo")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Father's Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFather" runat="server" Text='<%#Bind("FatherName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mother Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("MotherName")%>' nowrap></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                     
                                                    <asp:TemplateField HeaderText="DOB" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategoryid" runat="server" Text='<%#Bind("DOB")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    
                                                </Columns>
                                            </asp:GridView>
                    </td>
                </tr>
            </table>
            <table align="center" class="tdcls" width="65%">
            <tr>
                <td style="text-align: center">
                  <asp:Button Text="Get Report" ID="btnReport" runat="server" onclick="btnReport_Click" 
                          /> 
                </td>
            </tr>
            </table>
            <table align="center" class="tdcls" width="100%">
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    STUDENT TC REPORT
                </td>
            </tr>
            <tr>
                <td>
                    <td align="center">
                    <rsweb:ReportViewer runat="server" ID="MyReportViewer" Width="100%" Height="700px">
                    </rsweb:ReportViewer>
                </td>
                </td>
            </tr>
        </table>
        
       <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

