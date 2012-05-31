<%@ Page AutoEventWireup="true" CodeFile="DefinePeriodTimings.aspx.cs" Inherits="DefinePeriodTimings"
    Language="C#" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" runat="Server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script src="App_Themes/all/Validations.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
    function validation()
    {
        if(! isEmpty('<%=txtPeriodName.ClientID%>',"Please Enter PeriodName"))return false;
        if(! DropdownValidate('<%=ddlfromHr.ClientID%>',"Please Select Hours"))return false;
        if(! DropdownValidate('<%=ddlFromMin.ClientID%>',"Please Select Minuts"))return false;
        if(! DropdownValidate('<%=ddlFromAmpm.ClientID%>',"Please Select Am or PM"))return false;
        if(! DropdownValidate('<%=ddlToHr.ClientID%>',"Please Select Hours"))return false;
        if(! DropdownValidate('<%=ddlToMn.ClientID%>',"Please Select Minuts"))return false;
        if(! DropdownValidate('<%=ddlToAmpm.ClientID%>',"Please Select Am or Pm"))return false;

    }
    </script>
    <div>
        <table align="center" class="tdcls" width="60%">
            <tr>
                <td>
                    <asp:HiddenField ID="Message" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="heading" style="text-align: center">
                    DEFINE PERIOD TIMINGS
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="subhead">
                     Period Name <span style="font-size: 10px; color: Red">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtPeriodName" runat="server" CssClass="txtcls"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    From
                    <span style ="font-size:10px;color:Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlfromHr" runat="server" Width="80px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlFromMin" runat="server" Width="80px">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                        <asp:ListItem Value="32">32</asp:ListItem>
                        <asp:ListItem Value="33">33</asp:ListItem>
                        <asp:ListItem Value="34">34</asp:ListItem>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <asp:ListItem Value="36">36</asp:ListItem>
                        <asp:ListItem Value="37">37</asp:ListItem>
                        <asp:ListItem Value="38">38</asp:ListItem>
                        <asp:ListItem Value="39">39</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="41">41</asp:ListItem>
                        <asp:ListItem Value="42">42</asp:ListItem>
                        <asp:ListItem Value="43">43</asp:ListItem>
                        <asp:ListItem Value="44">44</asp:ListItem>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <asp:ListItem Value="46">46</asp:ListItem>
                        <asp:ListItem Value="47">47</asp:ListItem>
                        <asp:ListItem Value="48">48</asp:ListItem>
                        <asp:ListItem Value="49">49</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="51">51</asp:ListItem>
                        <asp:ListItem Value="52">52</asp:ListItem>
                        <asp:ListItem Value="53">53</asp:ListItem>
                        <asp:ListItem Value="54">54</asp:ListItem>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <asp:ListItem Value="56">56</asp:ListItem>
                        <asp:ListItem Value="57">57</asp:ListItem>
                        <asp:ListItem Value="58">58</asp:ListItem>
                        <asp:ListItem Value="59">59</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlFromAmpm" runat="server" Width="80px">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="AM">AM</asp:ListItem>
                        <asp:ListItem Value="PM">PM</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead">
                    To
                    <span style ="font-size:10px;color:Red">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlToHr" runat="server" Width="80px">
                        <asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlToMn" runat="server" Width="80px">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                        <asp:ListItem Value="24">24</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <asp:ListItem Value="26">26</asp:ListItem>
                        <asp:ListItem Value="27">27</asp:ListItem>
                        <asp:ListItem Value="28">28</asp:ListItem>
                        <asp:ListItem Value="29">29</asp:ListItem>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <asp:ListItem Value="31">31</asp:ListItem>
                        <asp:ListItem Value="32">32</asp:ListItem>
                        <asp:ListItem Value="33">33</asp:ListItem>
                        <asp:ListItem Value="34">34</asp:ListItem>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <asp:ListItem Value="36">36</asp:ListItem>
                        <asp:ListItem Value="37">37</asp:ListItem>
                        <asp:ListItem Value="38">38</asp:ListItem>
                        <asp:ListItem Value="39">39</asp:ListItem>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <asp:ListItem Value="41">41</asp:ListItem>
                        <asp:ListItem Value="42">42</asp:ListItem>
                        <asp:ListItem Value="43">43</asp:ListItem>
                        <asp:ListItem Value="44">44</asp:ListItem>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <asp:ListItem Value="46">46</asp:ListItem>
                        <asp:ListItem Value="47">47</asp:ListItem>
                        <asp:ListItem Value="48">48</asp:ListItem>
                        <asp:ListItem Value="49">49</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="51">51</asp:ListItem>
                        <asp:ListItem Value="52">52</asp:ListItem>
                        <asp:ListItem Value="53">53</asp:ListItem>
                        <asp:ListItem Value="54">54</asp:ListItem>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <asp:ListItem Value="56">56</asp:ListItem>
                        <asp:ListItem Value="57">57</asp:ListItem>
                        <asp:ListItem Value="58">58</asp:ListItem>
                        <asp:ListItem Value="59">59</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlToAmpm" runat="server" Width="80px">
                        <asp:ListItem Value="">Select</asp:ListItem>
                        <asp:ListItem Value="AM">AM</asp:ListItem>
                        <asp:ListItem Value="PM">PM</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="subhead" >
                    Remarks
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" Width="120px" TextMode="multiline" CssClass="txtcls">
                    </asp:TextBox>
                </td>
            </tr>
            </table>&nbsp;
        <table align="center" class="tdcls" width="576px">
            <tr>
                <td align="center">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" Width="50px" 
                         />&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Modify" Width="50px"  />&nbsp;&nbsp;
                    <asp:Button ID="Button3" runat="server" Text="Delete" Width="50px"  />&nbsp;&nbsp;
                    
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="dgrid" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="Name" />
                            <asp:BoundField DataField="timeFrom" HeaderText="From" />
                            <asp:BoundField DataField="timeTo" HeaderText="To" />
                            <asp:BoundField DataField="remarks" HeaderText="Remarks" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
