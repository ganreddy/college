<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ReportTimetable1.aspx.cs" Inherits="Staff_ReportTimetable1" Title="  Staff Class Wise Timetable Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function printSpecial() {
            if (document.getElementById != null) {
                var html = '<HTML>\n<HEAD>\n';

                if (document.getElementsByTagName != null) {
                    var headTags = document.getElementsByTagName("head");
                    if (headTags.length > 0)
                        html += headTags[0].innerHTML;
                }

                html += '\n</HEAD>\n\n';

                var printReadyElem = document.getElementById("Divtag");

                if (printReadyElem != null) {
                    html += printReadyElem.innerHTML;
                }
                else {
                    alert("Could not find the printReady function");
                    return;
                }

                html += '\n</BODY>\n</HTML>';

                var printWin = window.open("", "printSpecial");
                printWin.document.open();
                printWin.document.write(html);

                if (gAutoPrint) {
                    printWin.print();

                }


            }
            else {
                alert("The print ready feature is only available if you are using an browser. Please update your browswer.");
            }
        }
        function validation()
        {
            if(!DropdownValidate('<%=ddlClass.ClientID%>',"Please Select Class"))return false;
            if(!DropdownValidate('<%=ddlSection.ClientID%>',"Please Select Section"))return false;
            if(!DropdownValidate('<%=ddlYear.ClientID%>',"Please Select Year"))return false;
        }
    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>
            <table style="height: 100%; width: 100%">
                <tr>
                    
                    <td width="100%" align="center">
                        <table width="80%">
                            <tr>
                                <td class="heading" style="text-align: center" colspan="2">
                                    Class Wise Timetable
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 25px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 25px" class="subhead">
                                    Class<span style="font-size: 14px; color: Red">*</span>
                                </td>
                                <td style="height: 25px">
                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="154px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    Section<span style="font-size: 14px; color: Red">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged" Width="154px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    Year<span style="font-size: 14px; color: Red">*</span>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" Width="154px">
                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                        <asp:ListItem Value="1">2011</asp:ListItem>
                                        <asp:ListItem Value="2">2012</asp:ListItem>
                                        <asp:ListItem Value="3">2013</asp:ListItem>
                                        <asp:ListItem Value="4">2014</asp:ListItem>
                                        <asp:ListItem Value="5">2015</asp:ListItem>
                                        <asp:ListItem Value="6">2016</asp:ListItem>
                                        <asp:ListItem Value="7">2017</asp:ListItem>
                                        <asp:ListItem Value="8">2018</asp:ListItem>
                                        <asp:ListItem Value="9">2019</asp:ListItem>
                                        <asp:ListItem Value="10">2020</asp:ListItem>
                                        <asp:ListItem Value="11">2021</asp:ListItem>
                                        <asp:ListItem Value="12">2022</asp:ListItem>
                                        <asp:ListItem Value="13">2023</asp:ListItem>
                                        <asp:ListItem Value="14">2024</asp:ListItem>
                                        <asp:ListItem Value="15">2025</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="subhead">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="lblText" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 23px" colspan="2">
                                    <asp:Panel ID="GvPanel" runat="server">
                                        &nbsp;
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellSpacing="2"
                                            BackColor="#CCCCCC">
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <RowStyle CssClass="gridviewitem" />
                                            <SelectedRowStyle Font-Bold="True" />
                                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                <center>
                                    </center>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button ID="Prtbtn" runat="server" Text="Print" OnClick="Prtbtn_Click" /> 
                                </td>
                            </tr>
                        </table>
                    </td>
                    
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
