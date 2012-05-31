<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PayStudentFee.aspx.cs" Inherits="PayStudentFee" Title="STUDENT FEE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function Clear() {
            document.getElementById('<%=txtAdmSearch.ClientID%>').value = "";
            document.getElementById('<%=ddlBatch.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlClasses.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlSections.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlStudentID.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=txtAdmNo.ClientID%>').value = "";
            document.getElementById('<%=ddlCategory.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddltype.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=ddlFeeType.ClientID%>').selectedIndex = 0;
            document.getElementById('<%=txtFeeSlipNo.ClientID%>').value = "";
            document.getElementById('<%=txtCast.ClientID%>').value = "";
            document.getElementById('<%=txtCon.ClientID%>').value = "";
            if (document.getElementById('<%= gdvStud.ClientID%>') != null) {

                document.getElementById('<%= gdvStud.ClientID%>').innerText = null;

                return false;
            }
        }

        function validations() {
            if (document.getElementById('<%=rdbAdminNo.ClientID%>').checked) {
                if (!isEmpty('<%= txtAdmSearch.ClientID%>', "Please Enter Admission No")) return false;
                //      if(document.getElementById('<%=txtAdmSearch.ClientID %>').value!="")
                //         {
                //           if(! ZipCode('<%= txtAdmSearch.ClientID %>',"Please enter Admission No: ")) return false;
                //         }
                


                if (document.getElementById('<%=txtAdmSearch.ClientID %>').value) {
                    var count = 0;
                    if (document.getElementById('<%=gdvStud.ClientID %>') == null) {
                        alert("Please Enter Valid Admission Number & Click Search Button");
                        document.getElementById('<%=txtAdmSearch.ClientID%>').focus();
                        return false;
                    }
                    var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
                    for (var i = 1; i < tableElement.rows.length; i++) {
                        var rowElem = tableElement.rows[i];
                        var cell = rowElem.cells[0];
                        //alert(cell);
                        if (cell.childNodes[0].type == "radio") {
                            if (cell.childNodes[0].checked == true) {
                                count = 1;
                                break;
                            }
                        }

                    }
                    if (count == 0) {
                        alert("Please Select Radio Button For Corresponding Admission Number");
                        return false;
                    }


                }
            }

            var AdmissionNo = document.getElementById('<%=rdbAdminNo.ClientID%>').checked;
            var StudentName = document.getElementById('<%=rdbName.ClientID%>').checked;
            if ((AdmissionNo == false) && (StudentName == false)) {
                alert("Please Choose Admission Number/Student Name");
                return false;
            }
            if (document.getElementById('<%=rdbName.ClientID%>').checked) {
                if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
                if (!DropdownValidate('<%=ddlClasses.ClientID%>', "Please Select Class")) return false;
                if (!DropdownValidate('<%=ddlSections.ClientID%>', "Please Select Section")) return false;
                if (!DropdownValidate('<%=ddlStudentID.ClientID%>', "Please Select Student")) return false;
            }
            // if(! DropdownValidate('<%=ddlFeeType.ClientID%>',"Please Select Fee Type"))return false;


            // document.getElementById('<%=hdnPaid.ClientID%>').value=str;
            /*if(countcb==0)
            {
            alert("please select atleast radio Button to click on search button");
            return false;
            }*/



            if (!isEmpty('<%=txtPaymentDate.ClientID%>', "Please Enter Date Of Payment ")) return false;
            if (document.getElementById('<%=txtPaymentDate.ClientID %>').value != "") {
                if (!isDateFormat('<%=txtPaymentDate.ClientID %>', "Date Format Should Be DD/MM/YYYY")) return false;
            }
            if (!DropdownValidate('<%=ddlFeeType.ClientID%>', "Please Select Fee Type")) return false;
            if (document.getElementById('<%=ddlFeeType.ClientID %>').value) {
                var count = 0;
                if (document.getElementById('<%=FeeDetails.ClientID%>') == null) {
                    alert("Please Select Fee Details");
                    return false; 
                }
                var tableElement = document.getElementById('<%=FeeDetails.ClientID%>');
                for (var i = 1; i < tableElement.rows.length; i++) {
                    var rowElem = tableElement.rows[i];
                    var cell = rowElem.cells[0];
                    //alert(cell);
                    if (cell.childNodes[0].type == "checkbox") {
                        if (cell.childNodes[0].checked == true) {
                            count++;
                        }
                    }
                }
                if (count == 0) {
                    alert("Please Check Atleast One Checkbox");
                    return false;
                }
            }
            if (!isEmpty('<%=txtFeeSlipNo.ClientID%>', "Please Enter Fee Slip Number")) return false;
        }





        function Validate() {
            var count = 0;
            var str = "";
            var tableElement = document.getElementById('<%=tblFee.ClientID%>');
            for (var i = 0; i < tableElement.rows.length - 2; i++) {
                var rowElem = tableElement.rows[i];
                var cell = rowElem.cells[0];
                //alert(rowElem.cells[1].childNodes[1].value);
                if (cell.childNodes[1].type == "checkbox") {
                    if (cell.childNodes[1].checked) {
                        //str=str+rowElem.cells[1].childNodes[1].value+"@"+rowElem.cells[2].childNodes[0].value+"$";
                    }
                }

            }
            document.getElementById('<%=hdnPaid.ClientID%>').value = str;
            if (!isEmpty('<%=txtFeeSlipNo.ClientID%>', "Please Enter the Fee Slip Number")) return false;

        }
        function SelectStudent() {
            if (document.getElementById('<%=rdbAdminNo.ClientID%>').checked) {
                var count = 0;
//                if (document.getElementById('<=%gdvStud.ClientID %>') == null) {
//                    alert("Please Enter Valid Admission Number & Click Search Button");
//                    document.getElementById('<%=txtAdmSearch.ClientID%>').focus();
//                    return false;
//                }
                var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
                for (var i = 1; i < tableElement.rows.length; i++) {
                    var rowElem = tableElement.rows[i];
                    var cell = rowElem.cells[0];
                    //alert(cell);
                    if (cell.childNodes[0].type == "radio") {
                        //assign the status of the Select All checkbox to the cell checkbox within the grid
                        if (cell.childNodes[0].checked) count++;
                    }

                }
                if (count == 0) {
                    alert("Please select student");
                    return false;
                }
                if (count > 1) {
                    alert("Please select only one student");
                    return false;
                }
            }

        }
        function CheckRadio(rowindex) {
            var count = 0;
            
            var tableElement = document.getElementById('<%=gdvStud.ClientID%>');
            for (var i = 1; i < tableElement.rows.length; i++) {
                var rowElem = tableElement.rows[i];
                var cell = rowElem.cells[0];
                //alert(cell);
                if (cell.childNodes[0].type == "radio") {
                    //assign the status of the Select All checkbox to the cell checkbox within the grid
                    cell.childNodes[0].checked = false;
                }

            }
            tableElement.rows[rowindex + 1].cells[0].childNodes[0].checked = true;
            document.getElementById('<%=txtAdmSearch.ClientID%>').value = tableElement.rows[rowindex + 1].cells[2].childNodes[0].innerText;

            return true;

        }
        function window.onload() {
            ShowHide();
        }
        function ShowHide() {
            if (document.getElementById('<%=rdbName.ClientID%>').checked) {
                document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "none";
                document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "inline";
            }
            if (document.getElementById('<%=rdbAdminNo.ClientID%>').checked) {
                document.getElementById('<%=pnlAdmSearch.ClientID%>').style.display = "inline";
                document.getElementById('<%=pnlSearchName.ClientID%>').style.display = "none";
            }
            return;
        }

        function Check(text, check, txttotal) {
            var txt1, check1, txt2;
            txt1 = document.getElementById(text);
            check1 = document.getElementById(check);
            txt2 = document.getElementById(txttotal);

            if (check1.checked == true) {
                txt2.value = parseFloat(parseFloat(txt2.value) + parseFloat(txt1.value));
            }
            if (check1.checked == false) {
                txt2.value = parseFloat(parseFloat(txt2.value) - parseFloat(txt1.value));
            }
            //alert("hai");
        }

        //alert(document.getElementById(checkid));
        //alert(txtid);
        // var chk =
        // if (chk.checked = true) {
        //   alert("hi");
        //}
        //alert(checkid.checked)
        //if(checkid.checked=
        //var chkBoxList = document.getElementById(checkid);
        //var txt = document.getElementById(txtid);
        // alert(chkBoxList.checked);
        //if (checkid.checked == true) {



        // } 
     

    </script>

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="upd" runat="server">
        <ContentTemplate>
            <div>
                <br />
                <table align="center" class="tdcls" style="width: 80%;">
                    <tr>
                        <td colspan="4" style="height: 17%">
                            <asp:HiddenField ID="hdnFee" runat="server" />
                            <asp:HiddenField ID="hdnPaid" runat="server" />
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="4" class="heading" style="height: 17%">
                            <strong>STUDENT FEE</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="center" style="width: 30%">
                            Search By:
                        </td>
                        <td class="subhead">
                            <asp:RadioButton ID="rdbAdminNo" runat="server" class="subhead" ForeColor="Black"
                                GroupName="rbOnly" Text="Admission No" TabIndex="1"/>&nbsp;
                            <asp:RadioButton ID="rdbName" runat="server" class="subhead" ForeColor="Black" GroupName="rbOnly"
                                Text="Student Name" TabIndex="1"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlAdmSearch" runat="server">
                                <table align="center" class="tdcls" style="width: 80%;">
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Admission No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdmSearch" runat="server" TabIndex="2"></asp:TextBox>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                                ToolTip="Search" TabIndex="3"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" width="100%">
                                            <asp:GridView ID="gdvStud" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                                CellSpacing="2" OnRowDataBound="gdvStud_RowDataBound" AllowPaging="true" PageSize="5"
                                                OnPageIndexChanging="gdvStud_PageIndexChanging" TabIndex="4">
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <RowStyle CssClass="gridviewitem" />
                                                <SelectedRowStyle Font-Bold="True" />
                                                <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                                <HeaderStyle CssClass="gridviewheader" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                                <Columns>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStudentID" runat="server" Text='<%#Bind("StudID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:RadioButton ID="rdbSelect" runat="server" GroupName="rdb" AutoPostBack="true"
                                                                OnCheckedChanged="rdb_CheckedChanged" TabIndex="5"></asp:RadioButton>
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
                                                            <asp:Label ID="lblFather" runat="server" Text='<%#Bind("Fathername")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Category">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Bind("Caste")%>' nowrap></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Branch">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClass" runat="server" Text='<%#Bind("AdmittedClass")%>' nowrap></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Section">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSection" runat="server" Text='<%#Bind("AdmittedSection")%>' nowrap></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ClassID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClassid" runat="server" Text='<%#Bind("AdmittedInClass")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategoryid" runat="server" Text='<%#Bind("CategoryF")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSectionid" runat="server" Text='<%#Bind("Section")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBatchid" runat="server" Text='<%#Bind("BatchId")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Panel ID="pnlSearchName" runat="server">
                                <table align="center" class="tdcls" style="width: 80%;">
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Batch <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlBatch" runat="server" OnSelectedIndexChanged="ddlBatch_SelectedIndexChanged"
                                                AutoPostBack="true" Width="155px" Height="16%" TabIndex="6">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Class <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlClasses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlClasses_SelectedIndexChanged"
                                                Width="155px" Height="16%" TabIndex="7">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Section <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSections" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSections_SelectedIndexChanged"
                                                Width="155px" Height="16%" TabIndex="8">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Student <span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlStudentID" runat="server" Width="155px" Height="16%" OnSelectedIndexChanged="ddlStudentID_SelectedIndexChanged"
                                                AutoPostBack="true" TabIndex="9">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Admission No:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdmNo" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="subhead">
                                            S/O:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblFather" runat="server"></asp:Label>
                                        </td>
                                    </tr>--%>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="subhead" align="left" colspan="2">
                            <table align="center" class="tdcls" style="width: 80%;">
                                <tr>
                                    <td style="width: 30%" class="subhead">
                                        Caste
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCast" runat="server" TabIndex="10"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="subhead">
                                        Concession
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCon" runat="server" TabIndex="11"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left">
                            <%--<asp:RadioButton ID="rdbSC" runat="server" Text="SC" GroupName="Caste" />&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbST" runat="server" Text="ST" GroupName="Caste" />&nbsp;&nbsp;
                            <asp:RadioButton ID="rdbOBC" runat="server" Text="OBC" GroupName="Caste" />&nbsp;&nbsp;--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%" class="subhead">
                        </td>
                        <td>
                            <%-- <asp:CheckBox ID="chkSGC" runat="server" Text="SGC" />
                            <asp:CheckBox ID="chkYoungerBrother" runat="server" Text="Brother" />
                            <asp:CheckBox ID="chkKVS" runat="server" Text="KVS" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table align="center" class="tdcls" style="width: 80%;">
                                <tr>
                                    <td style="width: 30%" class="subhead">
                                        Category<span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCategory" runat="server" Width="154px" Style="margin-left: 0px" TabIndex="12">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="subhead">
                                        Branch<span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" Width="154px" Style="margin-left: 0px" TabIndex="13">
                                            <asp:ListItem Value="-1">---Select---</asp:ListItem>
                                            <asp:ListItem Value="0">General</asp:ListItem>
                                            <asp:ListItem Value="1">Science</asp:ListItem>
                                            <asp:ListItem Value="2">Non Science</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 30%" class="subhead">
                                        Fee Type <span style="font-size: 11px; color: Red">*</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFeeType" runat="server" Width="155px" Height="16%" OnSelectedIndexChanged="ddlFeeType_SelectedIndexChanged"
                                            AutoPostBack="true" Style="margin-left: 1px" TabIndex="14">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="heading" colspan="2" align="left">
                            <strong>FEE DETAILS</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table id="tblFee" align="center" class="tdcls" style="width: 80%;" runat="server">
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:GridView ID="FeeDetails" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC"
                                            OnRowDataBound="FeeDetails_RowDataBound" OnRowCommand="FeeDetails_RowCommand" TabIndex="15">
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <RowStyle CssClass="gridviewitem" />
                                            <SelectedRowStyle Font-Bold="True" />
                                            <PagerStyle BackColor="#739bcf" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle CssClass="gridviewitem" BackColor="#739bcf" Font-Bold="True" ForeColor="White" />
                                            <Columns>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblHeader" runat="server" Text='<%#Bind("Headerid")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Header Name">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheHeader" Text='<%#Bind("HeaderName")%>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAmount" Text='<%#Bind("Amount")%>' runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 40%" align="right">
                                        <asp:Label ID="lblTotalamout" runat="server" Text="Total Amount" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="txtTotal" runat="server" TabIndex="16"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="2">
                            <asp:Panel ID="pnlBank" runat="server">
                                <table align="center" class="tdcls" style="width: 80%;">
                                    <tr align="center">
                                        <td class="heading" colspan="2" align="center" align="left">
                                            <strong>PAYMENT DETAILS</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 138px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Date Of Payment<span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPaymentDate" runat="server" TabIndex="17">&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; 
                                            &#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160; </asp:TextBox>
                                            <%--<img id="Img1" alt="Pick a date" border="0" height="16" src="../images/cal.gif" width="16">--%>
                                            <asp:ImageButton runat="server" ID="Img1" alt="Pick a date" border="0" Height="16px"
                                                src="../images/cal.gif" Width="16px" />
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Img1"
                                                TargetControlID="txtPaymentDate" Format="dd/MM/yyyy">
                                            </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30%" class="subhead">
                                            Fee Slip No<span style="font-size: 11px; color: Red">*</span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFeeSlipNo" runat="server" TabIndex="18"> </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 20px" valign="top" align="center">
                            <asp:Button ID="btnPaid" runat="server" Text="Paid" OnClick="btnPaid_Click" TabIndex="19"/>
                            &nbsp;&nbsp;&nbsp
                            <asp:Button ID="btnClear" runat="server" Text=" Clear " Style="height: 26px" TabIndex="20" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
