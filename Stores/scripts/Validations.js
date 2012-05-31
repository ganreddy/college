var Chars=null;
var emailpattern=null;
var digits=null;



function IsInteger(ele,helperMsg)
{
var numericExpression = /^[0-9]+$/;
var MaxLength=31;
if(document.getElementById(ele).value.match(numericExpression)<MaxLength)
{
return true;
}
else
{
alert(helperMsg);
document.getElementById(ele).focus();
return false;
}
}
//Used for Empty String
function isEmpty(input,helpermsg)
{
    
    if(document.getElementById(input).value=="")
     {
         alert(helpermsg);
         document.getElementById(input).focus();
         return false;
     }
     else
     {
         return true;
     }
   
}
    //used 4 dropdown
  function DropdownValidate(input,msg)
  {
         if (document.getElementById(input).selectedIndex==0)
          {
           alert(msg);
           document.getElementById(input).focus();
            return false;
          }
          else 
          {
             return true;
          }
     }
    
    
    // Used for Allowing Characters only
    
function ValidateTextFormat(input,helpermsg)   
{
   Chars=/^[a-zA-Z ]+$/;
   if(document.getElementById(input).value.search(Chars)==-1)  
   {
      alert(helpermsg);
      document.getElementById(input).focus();
      return false;
   }
   else
     {
      return true;
     }   
}
  //Used for Allowing Valid Email Format
  
function EmailFormat(input,helpermsg)
{
     emailpattern=/^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$/;
    //emailpattern= /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
    var EmailId=document.getElementById(input).value;
    var matchArray=EmailId.match(emailpattern);
   if(matchArray==null)
   {
          alert(helpermsg);
          document.getElementById(input).focus();
          return false;
   }
   else
     {
      return true;
     }
      
}
  // Used for Allowing Valid Zipcode Format
 function ZipCode(input,helpermsg)
     {
          digits="0123456789";
          var temp;
            for(var i=0;i<document.getElementById(input).value.length;i++)
               {
                     temp=document.getElementById(input).value.substring(i,i+1);
                     if(digits.indexOf(temp)==-1)
                        {
                            alert(helpermsg);
                            document.getElementById(input).focus();
                            return false;
                        }
              }
      return true;
   }
  
  // Used for Allowing Valid phoneNo Format
  
function ChkPhoneNum(input,helpermsg)
 {
        var phone2 = /^[0-9]{1,}$/;
        if(phone2.test(document.getElementById(input).value))
        {
         
             return true;
        }
        else
         {
            alert(helpermsg);
            document.getElementById(input).focus();
            return false;
         }
  
}
  
// Used For Check AlphaNumeric or not
function isAlphaNumeric(str,helpermsg)
      {
            var AlphaNumericPattern = /[^a-zA-Z0-9]/g;
            var an=document.getElementById(str).value;
            var matchArray=an.match(AlphaNumericPattern);
            if(matchArray==null)
            
          //  if (re.test(document.getElementById(str)))
                {
                     alert(helpermsg);
                     document.getElementById(str).focus();
                     return false;
                }
   return true;
     }
  
     function isPhoneNo(input,helpermsg)
     {
         var re = /^\(?[2-9]\d{2}[\)\.-]?\s?\d{3}[\s\.-]?\d{4}$/;
         if(document.getElementById(input).value.test(re))
         if(re.test(document.getElementById(input).value)=="")
             {
                 alert(helpermsg);
                 return false;
             }
         return true;
     }
    function DateFormat(input1,input2,helpermsg1,helpermsg2,helpermsg6,helpermsg7)
       {
          var splitDate1 = document.getElementById(input1).value.split("/");
          var splitDate2 = document.getElementById(input2).value.split("/");
          var refDate1 = new Date(splitDate1[1]+"/"+splitDate1[0]+"/"+splitDate1[2]);
          var refDate2 = new Date(splitDate2[1]+"/"+splitDate2[0]+"/"+splitDate2[2]);
          var objFromDate = document.getElementById(input1).value;
          var objToDate = document.getElementById(input2).value;
          var date1 = new Date(objFromDate);
          var date2 = new Date(objToDate);
            
            if(objFromDate=='')
             {
                alert(helpermsg1);
                return false;
             }
            else if(objToDate=='')
             {
                alert(helpermsg2);
                return false;
             }
            else if(objFromDate!='' && objToDate!='' && objFromDate>objToDate )
             {
                alert(helpermsg6);
                return false;
             }
            else if(splitDate1[2] && splitDate1[2].length == 2 && splitDate2[2] && splitDate2[2].length == 2){splitDate1[2] = "20"+splitDate1[2];splitDate2[2] = "20"+splitDate2[2];}
            else if(splitDate1[1] < 1 || splitDate1[1] > 12 || refDate1.getDate() != splitDate1[0] || splitDate1[2].length != 4 || (!/^20/.test(splitDate1[2])) ||splitDate2[1] < 1 || splitDate2[1] > 12 || refDate2.getDate() != splitDate2[0] || splitDate2[2].length != 4 || (!/^20/.test(splitDate2[2])))
			{
			 alert(helpermsg7);
			 document.getElementById(input1).value = ""; 
			 document.getElementById(input2).value="";
			 document.getElementById(input1).focus();
			 document.getElementById(input2).focus();
			 return false;
			}
			            
            return true;
     }
  
     function isCurrentDate(input,helpermsg)
       {
            var objdate1=document.getElementById(input).value;
            var date1=new Date();
            var date2=date1.getMonth() + "/" + date1.getDay() + "/" +date1.getFullYear();
            var currentdate=new Date(date2);
         if(date1>currentdate)
            {
              alert(helpermsg);
              return false;
            }
      return true;
      }
 function IsDateGreaterThanEqual(PreDate,currentDate,strErrMsg)
 {
 
 var From = document.getElementById(PreDate).value;
    var To = document.getElementById(currentDate).value;
    var strSplitFrom = From.split('/');
    var myDateFrom = new Date();
   myDateFrom.setFullYear(strSplitFrom[2], strSplitFrom[1] - 1, strSplitFrom[0]);
     var strSplitTo = To.split('/');
    myDateTo = new Date();
    myDateTo.setFullYear(strSplitTo[2], strSplitTo[1] - 1, strSplitTo[0]);
    
    if (myDateTo >= myDateFrom) {
       
       // txtfrom.focus();
        return true;
    }
    else {
     alert(strErrMsg);
        return false;
    }
    return true;
 }
 
function IsDateGreaterThan(Date1,Date2,strErrMsg)
 {
 
    var From = document.getElementById(Date1).value;
    var To = document.getElementById(Date2).value;
    var strSplitFrom = From.split('/')
    var myDateFrom = new Date();
    myDateFrom.setFullYear(strSplitFrom[2], strSplitFrom[1] - 1, strSplitFrom[0]);
    var strSplitTo = To.split('/')
    myDateTo = new Date();
    myDateTo.setFullYear(strSplitTo[2], strSplitTo[1] - 1, strSplitTo[0]);

    if (myDateTo > myDateFrom) {
       
       // txtfrom.focus();
        return true;
    }
    else {
     alert(strErrMsg);
        return false;
    }
 }
  
 //Used For Check Numeric or not

function isNumeric(elem, helperMsg){
	var numericExpression = /^[0-9]+$/;
	if(document.getElementById(elem).value.match(numericExpression))
	         {
		          return true;
	         }
	         else
	           {
		          alert(helperMsg);
		          document.getElementById(elem).focus();
		          return false;
	}
}

function isAlphanumeric(elem, helperMsg){
	var alphaExp = /^[0-9a-zA-Z]+$/;
	if(document.getElementById(elem).value.match(alphaExp)){
		return true;
	}else{
		alert(helperMsg);
		document.getElementById(elem).focus();
		return false;
	}
	
}

function validate(input,helpermsg,helpermsg1){

		splitDate = document.getElementById(input).value.split("/");
		if (splitDate[2] && splitDate[2].length == 2){splitDate[2] = "20"+splitDate[2]}
		refDate = new Date(splitDate[1]+"/"+splitDate[0]+"/"+splitDate[2]);
		if (splitDate[1] < 1 || splitDate[1] > 12  || refDate.getDate() != splitDate[0] || splitDate[2].length !== 4 || (!/^/.test(splitDate[2])))
			{
			 alert(helpermsg);
			 document.getElementById(input).value = ""; 
			 document.getElementById(input).focus();
			}
			else if(splitDate[1]==splitDate[0])
			{
			return true;
			document.getElementById(input).focus();
			}
	}
	
function isDateFormat(elem, helperMsg)
{
	var numericExpression = /^([0]{0,1}[1-9]|[1|2][0-9]|[3][0|1])[/]([0]?[1-9]|[1][0-2])[/]([0-9]{4})$/;
	if(document.getElementById(elem).value.match(numericExpression))
     {
          return true;
     }
     else
     {
          alert(helperMsg);
          document.getElementById(elem).focus();
          return false;
	 }
}

function isDecimal(elem, helperMsg)
{
    var numericExpression = /^[0-9]+(\.[0-9][0-9]?)?$/;
	if(document.getElementById(elem).value.match(numericExpression))
     {
          return true;
     }
     else
     {
          alert(helperMsg);
          document.getElementById(elem).focus();
          return false;
	 }
}

function CheckBox(elem,msg)
{
    if(document.getElementById(elem).checked>=1)
       {
            return true;
       }
   else
      {
           alert(msg);
           document.getElementById(elem).checked=1;
           return false;
     }
}

function CheckBox1(elem,msg)
{
if(document.getElementById(elem).checked==false)
{
alert(msg);
return false;
}
else
{
    return true;
}
}