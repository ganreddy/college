<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true"
    CodeFile="StaffPrevPosts.aspx.cs" Inherits="StaffPrevPosts"  Title="Staff Previous Posts"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function validation()
    {
        if (!DropdownValidate('<%=ddlStaffId.ClientID%>', "Please Select Staff")) return false;
        if (!DropdownValidate('<%=ddlNameOfPost.ClientID%>', "Please Select Name Of Post")) return false;
        if(! isEmpty('<%=txtWorkPlace.ClientID%>',"Please Enter Place Worked At"))return false;
        if(! isEmpty('<%=txtFrom.ClientID%>',"Please Enter From Date"))return false;
        if(document.getElementById('<%=txtFrom.ClientID %>').value!="")
        {
           if(! isDateFormat('<%=txtFrom.ClientID %>',"Date Format Should Be DD/MM/YYYY Of From Date")) return false;
        }
        if(! isEmpty('<%=txtTo.ClientID%>',"Please Enter To Date"))return false;
 if(document.getElementById('<%=txtTo.ClientID %>').value!="")
        {
            if (!isDateFormat('<%=txtTo.ClientID %>', "Date Format Should Be DD/MM/YYY Of To Date")) return false;
        }
        if (!isEmpty('<%=txtReasonForTransfer.ClientID%>', "Please Enter Reason For Transfer")) return false;
        if (!DateFormat12('<%=txtFrom.ClientID%>', '<%=txtTo.ClientID%>', "From Date Cannot Be Less Than To Date ")) return false;
    }
    </script>

    <div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
        
       
        <table align="center" class="tdcls" style="width: 60%">
        <tr>
             <td>
                 <asp:HiddenField ID="hdnStaffPrvPosting" runat="server" />
             </td>
         </tr>
         <tr>
             <td>
                 <asp:HiddenField ID="hdnRecordID" runat="server" />
             </td>
         </tr>
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    STAFF PREVIOUS POSTINGS
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Staff <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStaffId" runat="server" Width="154px" 
                        onselectedindexchanged="ddlStaffId_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblMessage1" runat="server" Text="No Previous Postings To This Employee"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
            <tr>
                <td colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="heading" colspan="2">
                    PERIOD
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" style="width: 60%">
            <tr>
                <td class="subhead">
                    Name of Post<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td style="width: 155px">
                    <%--<asp:TextBox ID="txtNameOfPost" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlNameOfPost" runat="server" Width="154px" >   
                    </asp:DropDownList>
                </td>
                <td class="subhead" nowrap>
                    Place Worked At<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtWorkPlace" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    From<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td nowrap>
                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                    <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        id="imgCalFrom">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        id="imgCalFrom"/>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                        PopupButtonID="imgCalFrom" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
                <td class="subhead">
                    To<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td nowrap>
                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                   <%-- <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        id="imgcalTo">--%>
                        <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                        id="imgcalTo"/>
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                        PopupButtonID="imgcalTo" Format="dd/MM/yyyy">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td class="subhead" nowrap>
                    Reason For Transfer<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtReasonForTransfer" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
            <td colspan="4" align="center"><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
        </table>
        <table align="center" class="tdcls" width="576">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="115px" OnClick="btnSave_Click" />
                </td>
            </tr>
            
            
             <tr>
                        <td align="center">
                            <asp:GridView ID="gdvPrevPosts" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" AllowPaging="true" PageSize="10" 
                                onpageindexchanging="gdvPrevPosts_PageIndexChanging" 
                                onrowcommand="gdvPrevPosts_RowCommand" 
                                onrowdatabound="gdvPrevPosts_RowDataBound">
                              
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffID" runat="server" Text='<%#Bind("StaffId")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcaderid" runat="server" Text='<%#Bind("CaderID")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name OfThe Post">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameOfThePost" runat="server" Text='<%#Bind("CaderType")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="WorkPlace">
                                        <ItemTemplate>
                                            <asp:Label ID="lblWorkPlace" runat="server" Text='<%#Bind("WorkPlace")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FromDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" runat="server" Text='<%#Bind("FromDate")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ToDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" runat="server" Text='<%#Bind("ToDate")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ReasonForTransfer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReasonForTransfer" runat="server" Text='<%#Bind("ReasonForTransfer")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecordID" runat="server" Text='<%#Bind("recordid")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
        </table>
         </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
