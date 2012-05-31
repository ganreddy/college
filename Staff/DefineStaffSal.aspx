<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DefineStaffSal.aspx.cs" Inherits="Staff_DefineStaffSal" Title="Define Staff Salary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function Confirm()
         {
            
            var con = confirm("If Remove This Head Name Then Corresponding Headers Are Also Removed? Do You Want Delete This Field");
            if (con == true) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        function validation() {
        
            
            if (!isEmpty('<%=txtHeadName.ClientID%>', "Please Enter Head Name")) return false;
            var Addition = document.getElementById('<%=rdbAddition.ClientID%>').checked;
            var Deduction = document.getElementById('<%=rdbDeduction.ClientID%>').checked;
            if ((Addition == false) && (Deduction == false)) {
                alert("Please Select Type");
                return false;
            }
            var DirectAmount = document.getElementById('<%=rdbDirect.ClientID%>').checked;
            var Percentage = document.getElementById('<%=rdbPercentage.ClientID%>').checked;
            if ((DirectAmount == false) && (Percentage == false)) {
                alert("Please Select Calculation Type");
                return false;
            }
            if (document.getElementById('<%=rdbPercentage.ClientID%>').checked) {
                if (!CheckDecimal('<%= txtPercentage.ClientID %>', "Please Enter Percentage")) return false;
                if (!DropdownValidate('<%=ddlHeader.ClientID%>', "Please Select Header")) return false;
            }
            

        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
    <ContentTemplate>
     <table align="center" class="tdcls" width="60%">
            <tr>
                <td class="heading" colspan="2" style="text-align: center">
                    Define Staff Salary
                </td>
            </tr>
            <tr align="right">
                        <td colspan="2" style="width: 20%" id="TD1" runat="server" align="left">
                            <asp:HiddenField ID="hdnHeadID" runat="server"></asp:HiddenField>
                        </td>
                    </tr>
            <tr><td>&nbsp;</td></tr>
            <tr >
                <td  class="subhead">
                    Head Name<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td >    
                    <asp:TextBox ID="txtHeadName" runat="server"></asp:TextBox>
                    </td>
            </tr> 
            <tr>
                <td class="subhead">
                    Type<span style="font-size: 10px; color: Red">*</span></td>
                <td> 
                    <asp:RadioButton ID="rdbAddition" runat="server" class="subhead" ForeColor="Black" GroupName="rbReg1"
                                    Text="Addition" />&nbsp;
                                <asp:RadioButton ID="rdbDeduction" runat="server" class="subhead" ForeColor="Black"
                                    GroupName="rbReg1" Text="Deduction" />
                    </td>
            </tr>
            
            <tr>
                <td class="subhead">
                    Calculation Type<span style="font-size: 10px; color: Red">*</span></td>
                <td>
                    
                    <asp:RadioButton ID="rdbDirect" runat="server" class="subhead" 
                        ForeColor="Black" GroupName="rbReg2"
                                    Text="Direct Amount" 
                        oncheckedchanged="rdbDirect_CheckedChanged" AutoPostBack="true" />&nbsp;
                                <asp:RadioButton ID="rdbPercentage" runat="server" class="subhead" ForeColor="Black"
                                    GroupName="rbReg2" Text="Percentage" 
                        oncheckedchanged="rdbPercentage_CheckedChanged" AutoPostBack="true" />
                    </td>
            </tr>
            <asp:Panel ID="panel1" runat="server" Visible="false">
            <tr >          
                <td  class="subhead">
                    Percentage(%)<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td >    
                    <asp:TextBox ID="txtPercentage" runat="server"></asp:TextBox>
                    </td>                   
            </tr>
            </asp:Panel>
            
            <tr >
                <td  class="subhead">
                    Header<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td >    
                    <%--<asp:TextBox ID="txtHeader" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlHeader" runat="server" Height="16px" Width="154px"
                            AutoPostBack="true"> 
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr>
            <td colspan="2" align="center"><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 26px">
                    <asp:Button ID="btnSave" runat="server"  Text="Save" Width="123px" 
                        onclick="btnSave_Click" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
            <table align="center">
              <tr>
                        <td align="center">
                            <asp:GridView ID="gdvStaffSalary" runat="server" 
                                AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" AllowPaging="true" PageSize="10" 
                                onrowcommand="gdvStaffSalary_RowCommand" 
                                onrowdatabound="gdvStaffSalary_RowDataBound" 
                                onpageindexchanging="gdvStaffSalary_PageIndexChanging">  
                                <FooterStyle BackColor="#CCCCCC" />
                                <RowStyle CssClass="gridviewitem" />
                                <SelectedRowStyle  Font-Bold="True" />
                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadID" runat="server" Text='<%#Bind("HeadID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="HeadName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeadName" runat="server" Text='<%#Bind("HeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Bind("Type")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CalculationType">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCalculationType" runat="server" Text='<%#Bind("CalculationType")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>  
                                        <asp:TemplateField HeaderText="Percentage">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPercentage" runat="server" Text='<%#Bind("Percentage")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>    
                                        <asp:TemplateField HeaderText="Header" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeaderID" runat="server" Text='<%#Bind("HeaderID")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Header">
                                        <ItemTemplate>
                                            <asp:Label ID="lblHeaderName" runat="server" Text='<%#Bind("HeaderName")%>'></asp:Label>
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
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
        </table>
            
            
            
            
        </table>
       <%-- <table align="center" class="tdcls" width="60%">
            <tr>
                <td class="subhead">
                    From<span style="font-size: 10px; color: Red">*</span></td>
                <td >
                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                   <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgCalFrom">
                   <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                    PopupButtonID="imgCalFrom" Format="dd/MM/yyyy"/>
                    </td>
                <td class="subhead">
                    To<span style="font-size: 10px; color: Red">*</span></td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                    <img alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16" id="imgCalTo">
                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                    PopupButtonID="imgCalTo" Format="dd/MM/yyyy"/>
                    </td>
            </tr>
            <tr >
                <td class="subhead">
                    Result<span style="font-size: 10px; color: Red">*</span></td>
                <td>
                    <asp:TextBox ID="txtResult" runat="server"></asp:TextBox>
                    </td>
                     <td class="subhead">
                    Authority<span style="font-size: 10px; color: Red">*</span></td>
                <td>
                   
                   <asp:DropDownList ID="ddlAuthority" runat="server" Width="154px" 
                        >
                     
                    </asp:DropDownList>
                    </td>
            </tr>
            
            <tr>
            <td colspan="4" align="center"><asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label></td>
            </tr>
            </tr>
            <tr>
                <td align="center" colspan="4" style="height: 26px">
                    <asp:Button ID="btnSave" runat="server"  Text="Save" Width="123px" 
                        onclick="btnSave_Click" />
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
            <table align="center">
              <tr>
                        <td align="center">
                            <asp:GridView ID="gdvTrainingCourses" runat="server" 
                                AutoGenerateColumns="False" BackColor="#CCCCCC"
                                CellSpacing="2" AllowPaging="true" PageSize="10" 
                                onpageindexchanging="gdvTrainingCourses_PageIndexChanging" 
                                onrowcommand="gdvTrainingCourses_RowCommand" 
                                onrowdatabound="gdvTrainingCourses_RowDataBound">
                              
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
                                    <asp:TemplateField HeaderText="NatureOfCourse">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%#Bind("CourseAttended")%>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Result">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResult" runat="server" Text='<%#Bind("Result")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAuthorityID" runat="server" Text='<%#Bind("Authority")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>  
                                        <asp:TemplateField HeaderText="Authority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAuthority" runat="server" Text='<%#Bind("FullName")%>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>  
                                        <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecordID" runat="server" Text='<%#Bind("RecordID")%>'></asp:Label>
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
        </table>--%>
    </ContentTemplate>
    </asp:UpdatePanel>
    
</asp:Content>

