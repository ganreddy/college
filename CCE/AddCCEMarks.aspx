<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AddCCEMarks.aspx.cs" Inherits="CCE_AddCCEMarks" Title="Add Student CCE Marks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../scripts/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script src="../scripts/Validations.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
    function GetDetails(Rows,Columns)
    {
     document.getElementById('<%=hdnValues.ClientID%>').value="";
     for (var i = 0; i < Rows; i++) 
     {
         var txtTotalID = "ctl00_ContentPlaceHolder1_txtTotal" + i;
         var gradeID = "ctl00_ContentPlaceHolder1_txtGrade" + i;
         var Weigthage = "ctl00_ContentPlaceHolder1_txtWeightage" + i; 
        for(var j=0;j<Columns;j++)
        {
          var txtID="ctl00_ContentPlaceHolder1_txtMarks"+i+j;
          if(j != Columns-1)
            document.getElementById('<%=hdnValues.ClientID%>').value+=document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID"+i).value+"~"+document.getElementById("ctl00_ContentPlaceHolder1_hdnScholasticID"+j).value+"~"+document.getElementById(txtID).value+"#";
          else
            document.getElementById('<%=hdnValues.ClientID%>').value+=document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID"+i).value+"~"+document.getElementById("ctl00_ContentPlaceHolder1_hdnScholasticID"+j).value+"~"+document.getElementById(txtID).value;
        } 
         document.getElementById('<%=hdnValues.ClientID%>').value+="@"
         if (i != Rows - 1)
             document.getElementById('<%=hdnTotal.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById(txtTotalID).value + "~" + document.getElementById(gradeID).value +"~"+ document.getElementById(Weigthage).value + "#";
         else
             document.getElementById('<%=hdnTotal.ClientID%>').value += document.getElementById("ctl00_ContentPlaceHolder1_hdnStdID" + i).value + "~" + document.getElementById(txtTotalID).value + "~" + document.getElementById(gradeID).value +"~"+document.getElementById(Weigthage).value;
        
     }
    
      
    }
    function Validate(Presentrow,Presentcolumn) {

        if ((event.keyCode >= 48 && event.keyCode <= 57) || event.keyCode==46)
        event.keyCode=event.keyCode;
     else
        event.keyCode=0;
    }
    function CalcMarks(Presentrow,Presentcolumn,TotalColumns)
    {
      var sum=0,txtValue=0,TotalMarks=0;
      for(var i=0;i<TotalColumns;i++)
      {
         
         var txtID="ctl00_ContentPlaceHolder1_txtMarks"+Presentrow+i;
         var MarksID="ctl00_ContentPlaceHolder1_hdnMaxMarks"+i;
         if(parseFloat(document.getElementById(txtID).value)>parseFloat(document.getElementById(MarksID).value))
         {
            alert("Marks Should not be greater than "+document.getElementById(MarksID).value);
            return false;
         }
         TotalMarks+=parseFloat(document.getElementById(MarksID).value);
         //alert(TotalMarks);
         if(document.getElementById(txtID).value=="")
            txtValue=0;
         else
            txtValue=parseFloat(document.getElementById(txtID).value);
         sum=parseFloat(sum)+txtValue;   
      }
       document.getElementById("ctl00_ContentPlaceHolder1_txtTotal"+Presentrow).value=sum;
       document.getElementById("ctl00_ContentPlaceHolder1_txtWeightage"+Presentrow).value=(sum/TotalMarks)* document.getElementById('<%=hdnWeightage.ClientID%>').value
       sum=(sum/TotalMarks)*100;
       if(sum>90 && sum<=100)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="A1";
       if(sum>80 && sum<=90)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="A2";
       if(sum>70 && sum<=80)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="B1";
       if(sum>60 && sum<=70)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="B2";
       if(sum>50 && sum<=60)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="C1";
       if(sum>40 && sum<=50)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="C2";
       if(sum>32 && sum<=40)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="D";
       if(sum>20 && sum<=33)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="E1";
       if(sum>=0 && sum<=20)
              document.getElementById("ctl00_ContentPlaceHolder1_txtGrade"+Presentrow).value="E2";

      }
      function validation() {
          if (!DropdownValidate('<%=ddlYear.ClientID%>', "Please Select Academic Year")) return false;
          if (!DropdownValidate('<%= ddlSubject.ClientID%>', "Please Select Subject")) return false;
          if (!DropdownValidate('<%= ddlExamType.ClientID%>', "Please Select Exam Type")) return false;
          if (!DropdownValidate('<%=ddlBatch.ClientID%>', "Please Select Batch")) return false;
          if (!DropdownValidate('<%=ddlClass.ClientID%>', "Please Select Class")) return false;
          if (!DropdownValidate('<%=ddlSection.ClientID%>', "Please Select Section")) return false;
      
      }
        
    </script>

    <%-- <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updBatch">
        <ContentTemplate>--%>
    <div>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td colspan="2" class="heading">
                    ADD STUDENT CCE MARKS
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="hdnWeightage" runat="server" />
                    <asp:HiddenField ID="hdnValues" runat="server" />
                    <asp:HiddenField ID="hdnTotal" runat="server" />
                </td>
            </tr>
            <tr visible="false" runat="server">
                <td class="subhead">
                    Academic Year<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlYear" runat="server" Width="154px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                     Subject<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSubject" runat="server" Width="154px" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                   Exam Type<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlExamType" runat="server" Width="154px" OnSelectedIndexChanged="ddlExamType_SelectedIndexChanged"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                   Batch<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBatch" runat="server" Width="154px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Class<span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" Width="154px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    Section <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSection" runat="server" Width="154px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Table ID="tb" runat="server" BorderWidth="1">
                    </asp:Table>
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 15px;" colspan="2">
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
        
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
