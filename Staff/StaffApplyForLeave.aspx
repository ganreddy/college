<%@ Page MasterPageFile="~/MasterPage.master" Language="C#" AutoEventWireup="true"
    CodeFile="StaffApplyForLeave.aspx.cs" Inherits="StaffApplyForLeave" Title="Staff Leaves" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function Confirm()
     {
        var con = confirm("Do You Want Delete This Leave?");
        if (con == true) 
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    function ShowHide()
    {
      if(document.getElementById('<%=ddlStaffName.ClientID%>').selectedIndex==0)
      {
        document.getElementById('<%=pnlEmpDetails.ClientID%>').style.display="none";
      }
      else
      {
        document.getElementById('<%=pnlEmpDetails.ClientID%>').style.display="inline";
      }
     return;
    }
    function validate()
    {
   
         if(! DropdownValidate('<%=ddlStaffName.ClientID%>',"Please Select Staff Name"))return false;
         if(! DropdownValidate('<%=ddlLeaveType.ClientID%>',"Please Select Leave Type"))return false;
         if(! isEmpty('<%=txtToDate.ClientID%>',"Please Enter To Date"))return false;
         if(document.getElementById('<%=txtToDate.ClientID %>').value!="")
            {
               if(! isDateFormat('<%=txtToDate.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;
            }
         if(! isEmpty('<%=txtFromDate.ClientID%>',"Please Enter From Date"))return false;
         if(document.getElementById('<%=txtFromDate.ClientID %>').value!="")
            {
               if(! isDateFormat('<%=txtFromDate.ClientID %>',"Date Format Should Be DD/MM/YYYY")) return false;
            }
         if(! isEmpty('<%=txtDescrption.ClientID%>',"Please Enter Description"))return false;
         if(! DropdownValidate('<%=ddlAuthority.ClientID%>',"Please Select Authority"))return false;
     }
    
    </script>


    <asp:ToolkitScriptManager ID="ScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="updLeaves" runat="server">
        <ContentTemplate>
            <div align="center">
                <table align="center" class="tdcls" align="center" width="80%">
                    <tr>
                        <td class="heading" colspan="2" style="text-align: center">
                            STAFF LEAVES
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdnLeave" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Staff Name<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td style="width: 39%">
                            <asp:DropDownList ID="ddlStaffName" runat="server" CssClass="txtcls" Height="19px"
                                Width="154px" OnSelectedIndexChanged="ddlStaffName_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem>select</asp:ListItem>
                                <asp:ListItem>Vani</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="trEmpDetails" runat="server">
                        <td class="subhead" colspan="2">
                            <asp:Panel ID="pnlEmpDetails" runat="server">
                                <table width="100%">
                                    <tr>
                                        <td class="subhead" style="width: 39%">
                                            Date of Birth<span style="font-size: 10px; color: Red">*</span>
                                        </td>
                                        <td style="width: 39%">
                                            <asp:Label ID="lblDob" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="subhead" style="width: 39%">
                                            Staff Type<span style="font-size: 10px; color: Red">*</span>
                                        </td>
                                        <td style="width: 39%">
                                            <asp:Label ID="lblStaffType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:GridView ID="gdvAvailLeaves" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" AllowPaging="true" PageSize="10">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffID" runat="server" Text='<%#Bind("StaffID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeaveType" runat="server" Text='<%#Bind("leavetype")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("noofdays")%>' style="text-align:center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leaves Availed" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFromDate" runat="server" Text='<%#Bind("UsedLeaves")%>' style="text-align:center;"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Leaves Remaining" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblToDate" runat="server" Text='<%#Bind("avail")%>' style="text-align:center;" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2">
                            LEAVE DURATION
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Leave Type<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td style="width: 39%">
                            <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="txtcls" Height="23px"
                                Width="154px">
                                <%--<asp:ListItem Value="0">Select</asp:ListItem>--%>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            From:<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td class="tdcls" valign="top" nowrap style="width: 39%">
                            <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtcls" Width="134px"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                runat="server" id="imgcal">--%>
                                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                runat="server" id="imgcal"/>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                                PopupButtonID="imgcal" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            To<span style="font-size: 10px; color: Red"> *</span>
                        </td>
                        <td class="tdcls" valign="top" style="width: 39%" nowrap>
                            <asp:TextBox ID="txtToDate" runat="server" CssClass="txtcls" Width="134px"></asp:TextBox>
                            <%--<img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                id="imgcal1">--%>
                                <asp:ImageButton runat="server" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16"
                                id="imgcal1"/>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                                PopupButtonID="imgcal1" Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" valign="top" style="width: 39%">
                            DESCRIPTION
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Purpose<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td class="tdcls" colspan="2" valign="top" style="width: 39%">
                            <asp:TextBox ID="txtDescrption" runat="server" CssClass="txtcls" TextMode="MultiLine"
                                Width="149px" Height="36px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" style="width: 39%">
                            Authority<span style="font-size: 10px; color: Red">*</span>
                        </td>
                        <td class="tdcls" colspan="2" valign="top" style="width: 39%">
                            <asp:DropDownList ID="ddlAuthority" runat="server" Width="154px">
                                <asp:ListItem Value="0">---Select---</asp:ListItem>
                                <asp:ListItem Value="1" >Principal</asp:ListItem>
                                <asp:ListItem Value="2">Vice Principal</asp:ListItem>
                                 <asp:ListItem Value="3">In-Charge</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table align="center" class="tdcls">
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:GridView ID="gdvLeaves" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" PageSize="10" OnPageIndexChanging="gdvLeaves_PageIndexChanging"
                                OnRowCommand="gdvLeaves_RowCommand" OnRowDataBound="gdvLeaves_RowDataBound">
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Leave Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeaveType" runat="server" Text='<%#Bind("LeaveType")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From">
                                        <ItemTemplate>
                                            <asp:Label ID="lblFrom" runat="server" Text='<%#Bind("FromDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTo" runat="server" Text='<%#Bind("ToDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Purpose">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPurpose" runat="server" Text='<%#Bind("Purpose")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Authority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAuthority" runat="server" Text='<%#Bind("Authority")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLeaveId" runat="server" Text='<%#Bind("Leaveid")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStaffId" runat="server" Text='<%#Bind("staffid")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAuthorityID" runat="server" Text='<%#Bind("authorityID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" Text="Edit" CommandName="editing"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete" CommandName="del"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecordID" runat="server" Text='<%#Bind("RecordID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
