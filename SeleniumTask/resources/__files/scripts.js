var pswdcode;
//Page2 - code.html
function loadPageCode(){
    var timeout = Math.floor(Math.random() * (5000 - 1000)) + 1000; 
    setTimeout(function(){  
        $('#loader').remove();
        $('#code').val(globalCode);
        $('#code').attr("hidden",false);
    }, timeout);
}
//Page masked
function passwordField(number,id){
    return '<div class="col-md-auto align-items-center passwdDiv" id="div'+id+'">'+
    '<input class="passwdField" maxlength="1" id="passwd_'+id+'"">'+
    '<div class="w-100"></div>'+
    '<label class="passwdField horizontal-center" for="passwd_'+id+'">'+number+'</label>'+
    '</div>';
}

function generatePasswordBox(){

	pswdcode = getRndInteger(100000000,999999999).toString();
    var passwordInnerHtml="";
	
    for(i=0;i<3;i++){
		for(k=0;k<3;k++){	
			passwordInnerHtml += passwordField(pswdcode.charAt(i*2+i+k),i*2+i+k);
		}
		passwordInnerHtml +='<div class="w-100"></div>';//"</div>";
    }
    $('#passwordBox').html(passwordInnerHtml);
}

function loadPasswdFieldValues(){
    var passwdFieldValues= "";
  $(".passwdField").each(function(){passwdFieldValues += $(this).val();})
}

function verifyPasswd(){
    var passwd = pswdcode;
    var passwdFieldValues= "";
  $(".passwdField:enabled").each(function(){passwdFieldValues += $(this).val();})
    if (passwdFieldValues == removeCharFrompPassword(passwd)){
        $("#loggedIn").html("You pass!!!");
    }
	else{
		$("#loggedIn").html("WRONG!!!");
	}
}

function removeCharFrompPassword(str){
    var arr = str.split('');

    arr[blockedField1] = '';
    arr[blockedField2] = '';
    arr[blockedField3] = '';

    return arr.join("");
}

function getRndInteger(min, max,except) {
    var result = except;
    do {
        result = Math.floor(Math.random() * (max - min)) + min;
    }while(result == except);
  return result;
}

var blockedField1;
var blockedField2;
var blockedField3;

function blockRandomField(){
    blockedField1 = getRndInteger(0,8);
    blockedField2 = getRndInteger(0,8,blockedField1);
    blockedField3 = getRndInteger(0,8,blockedField2);
    $("#passwd_"+blockedField1).prop("disabled",true);
    $("#passwd_"+blockedField2).prop("disabled",true);
    $("#passwd_"+blockedField3).prop("disabled",true);
}


function load(){
    // $('.buttonLogin').click(function(){
    //     verifyPasswd();
    // });
    $(".passwdField").keyup(function() {
        if (this.value.length == this.maxLength) {
            $(this).parent().nextAll(".passwdDiv").children('input:enabled:first').focus();
            loadPasswdFieldValues();
        }
    });
}