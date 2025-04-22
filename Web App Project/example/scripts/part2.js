/* write header comments here 

functions in this file
- validateEnquire: validate the form on the enquire page
- validatePayment: validate the form on the payment page
- getInfo: get information from storage
- saveInfo: save information to storage
*/

"use strict";
var debug=true;   
//*************************  validate enquire form   ***************
function testQuantity(quantity, fruitType){
	var err="";
	if (isNaN(quantity)) {
		err += fruitType + " quantity is not a number. \n";
	}
	else if  (quantity <0)  {
		err +=  fruitType + " quantity cannot be negative. \n";
	}
	else if (parseInt(quantity, 10) !== Number(quantity)) { 
		err +=  fruitType + " quantity is not an integer. \n";
	}
	return err;
}	
function validateEnquire() {
	var errMsg="";
	var result=true;
	var temp="";
	
	var firstName=document.getElementById("firstName").value.trim();
	var lastName=document.getElementById("lastName").value.trim();
	var appleQty=document.getElementById("appleQty").value.trim();
	var bananaQty=document.getElementById("bananaQty").value.trim();
	
	// validate first and last name. 
	if (firstName=="") {
		errMsg += "Please enter your first name.\n";
	}

	if (lastName=="") {
		errMsg += "Please enter your last name.\n";
	}
	if (!debug){	  // disable javascript validation	
		// validate quantity

		if (appleQty=="" && bananaQty =="") {
			errMsg += "You haven't entered quantity for any fruit. \n";
		}
		else {
			if (appleQty!="" ){
				temp = testQuantity (appleQty, "Apple");
				if (temp!="") {
					errMsg += temp;
				}
			}
			if (bananaQty!="" ){		
				temp = testQuantity (bananaQty, "Banana");
				if (temp!="") {
					errMsg += temp;
				}
			}
			if (appleQty+bananaQty==0) {
				errMsg += "Your total quantity is zero. \n";
			}
		}
		//  more validation here 
	}

	if (errMsg!="") { // with errors
		alert (errMsg);
		result=false;
	}
	else {    // no error, save info to storage
		saveInfo(firstName, lastName, appleQty, bananaQty);
	}
	return result;	
}
//*************************  validate payment form   ***************
function validatePayment() {
	var errMsg="";
	var result=true;
	
	var cardType=document.getElementById("cardType").value;
	var cardName=document.getElementById("cardName").value.trim();
	var cardNumber=document.getElementById("cardNumber").value.trim();
	
	if (!debug){ // disable javascript validation
		if (cardName=="") {
			errMsg += "Please enter the name on the credit card.\n";
		}
		if (cardNumber=="") {
			errMsg += "Please enter the credit card number. \n";
		}
		//  more validation here 
	}
	if (errMsg!="") {
		alert (errMsg);
		result=false;
	}

	return result;	
}
//*******************  save and get information from storate  ***************
function saveInfo (firstName, lastName, appleQty, bananaQty){  // save information to storage
	if(typeof(Storage)!=="undefined"){  // the browser support web storage
		localStorage.setItem("firstName", firstName);
		localStorage.setItem("lastName", lastName);
		localStorage.setItem("appleQty", appleQty);
		localStorage.setItem("bananaQty", bananaQty);
		
		var chocBar=document.getElementById("chocBar").checked;
		localStorage.setItem("chocBar", chocBar);
		var chewingGum=document.getElementById("chewingGum").checked;
		localStorage.setItem("chewingGum", chewingGum);		
	}
}

function getInfo(){ 
	if (typeof(Storage)!=="undefined"){// the browser support web storage
		if (localStorage.getItem("firstName") !== null){// there are some saved info in storage  
			// name
			document.getElementById("fullName").textContent = localStorage.getItem("firstName") + " " + localStorage.getItem("lastName");	
		 
			document.getElementById("firstName").value = localStorage.getItem("firstName");	 
			document.getElementById("lastName").value = localStorage.getItem("lastName");
			// quantity     apple 0.99 each, banana 0.36 each, choc bar 1, chewing gum 1.85
			var cost=0;
			if (localStorage.getItem("appleQty")!=null){
				var appleQty=Number(localStorage.getItem("appleQty"));
				document.getElementById("appleQty").value = appleQty;
				cost=cost+0.99*appleQty;
			}
			if (localStorage.getItem("appleQty")!=null){				
				var bananaQty=Number(localStorage.getItem("bananaQty"));
				document.getElementById("bananaQty").value = bananaQty;
				cost=cost+0.36*bananaQty;
			}
			// recommended item checkbox
			var chocBar=localStorage.getItem("chocBar");
			var chewingGum=localStorage.getItem("chewingGum");
			document.getElementById("chocBar").checked= (chocBar=="true");
			document.getElementById("chewingGum").checked= (chewingGum=="true");
			if (chocBar=="true"){
				cost=cost+1;
			}
			if (chewingGum=="true"){
				cost=cost+1.85;
			}
			
			document.getElementById("totalCost").value = cost.toFixed(2);
		}

	}
}
function clearStorage(){  // for cancel order button
	localStorage.clear();
	location.href="index.html";
}

//*************************  init ***************
// if you want to use one javascript for two pages, you can use if else to seperate the init
function init() {
	if (document.getElementById("enquireForm")!=null) {  // it is enquire page  
		document.getElementById("enquireForm").onsubmit = validateEnquire;
	}
	else if (document.getElementById("paymentForm")!=null) { // it is payment page  
		getInfo();     // fill up the page with information passed from enquire page
		document.getElementById("paymentForm").onsubmit = validatePayment;
		document.getElementById("cancelOrder").onclick = clearStorage;
		
	}
}
// if you link to 2 javascript files in the same html and they both have init, you can use addEventListener and give the two init function different names
window.addEventListener("load",init);
//window.onload = init;  
