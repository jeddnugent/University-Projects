/**
 * Author: Jedd Nugent 103064999
 * Target: enquire.html and payment.html
 * Purpose: Validate and transfer data between the pages
 * Created: 02/05/2020
 * Last updated: 06/05/2020
 * Credits: Fruit Shop Sample part2.js
 */
"use strict";
var debug = true; 
function validatePayment(){
    var errMsg = "";
    var result = true;

    var cardType = document.getElementById("cardType");

    var cardNumber = document.getElementById("cardNumber").value.trim();
    var cardName = document.getElementById("cardName").value.trim();

    var cardExpiry = document.getElementById("cardExpiry").value;
    
    var CVV = document.getElementById("CVV").value.trim();

    //checking a card type has been selected
    if(cardType.selectedIndex == 0){
        errMsg += "Please select a card type. \n";
    }
    if (!debug){
        if(isNaN(cardNumber) == true){
            errMsg += "Please ensure your card number only contains digits. \n";
        }
        else{
            switch(cardType.selectedIndex){
                case 1: //visa
                    if(cardNumber.length == 16){
                        if(cardNumber.charAt(0) != 4){
                            errMsg += "The first digit of a Visa card must be a 4. \n"
                        }
                    }
                    else{
                        errMsg += "Visa card numbers must be 16 digits. \n";
                    }
                    break;
                case 2: //mastercard
                    if(cardNumber.length == 16){
                        cardNumber = parseInt(cardNumber.substring(0,2));
                        if(between(cardNumber, 51, 55) == false){
                            errMsg += "The first two digits of a Mastercard card must be between 51 and 55. \n";
                        }
                    }
                    else{
                        errMsg += "Mastercard numbers must be 16 digits. \n";
                    }
                    break;
                case 3: //AmEx
                    if(cardNumber.length == 15){
                        cardNumber = parseInt(cardNumber.substring(0,2));
                        if(between(cardNumber, 34, 37) == false){
                            errMsg += "The first two digits of a AmEx card must be between 34 and 37. \n";
                        }
                    }
                    else{
                        errMsg += "AmEx card numbers must be 15 digits. \n";
                    }
                    break;

            }
        }


        if(CVV.length == 0){
            errMsg += "Please enter a CVV number. \n";
        }
        else{
            if(CVV.length > 3){
                errMsg += "Please ensure your CVV number is no longer than 3 digits";
            }
        }

        if(!cardName.match(/[a-zA-Z]/)){
            errMsg += "Please ensure your card name only contains letters. \n";
        }
        else{
            if(cardName.length > 40){
                errMsg += "Please ensure that the Card Name is no longer than 40 characters including spaces. \n";
            }
        }

        if(cardExpiry.length == 0){
            errMsg += "Please ensure your card name only contains letters. \n";
        }
    }
    
    if (errMsg != "") { // contains errors
		alert (errMsg);
		result = false;
    }
    return result;
}


 function validateEnquire(){
    var errMsg = "";
	var result = true;
	
    var product = document.getElementById("phoneVal");
    var count = document.getElementById("count");
    var finalPrice = document.getElementById("finalPrice");

    var airPods = document.getElementById("airPods");
    var powerCore = document.getElementById("powerCore");
    var nest = document.getElementById("nest");

	var firstName = document.getElementById("firstName").value.trim();
    var lastName = document.getElementById("lastName").value.trim();
    
    var streetAddress = document.getElementById("streetAddress").value.trim();
    var suburbTown = document.getElementById("suburbTown").value.trim();
    var state = document.getElementById("state");
    var postCode = document.getElementById("postCode").value.trim();

    //validate address
    if (streetAddress == "") {
		errMsg += "Please enter your street address.\n";
    }
    if (suburbTown == "") {
		errMsg += "Please enter your Suburb or Town.\n";
    }
    if (!debug){
        if(state.selectedIndex == 0){
            errMsg += "Please enter your state. \n";
        }
        else{
            if(postCode == ""){ // exsistance check
                errMsg += "Please enter your postcode. \n";
            }
            else{

                if (isNaN(postCode) == true){ //Checking if postcode is not a number
                    errMsg += "Your Postcode must be four digit number. \n";
                }
                else{ //Range Check
                    if(postCode.length == 4){
                        postCode = parseInt(postCode);
                        switch(state.selectedIndex){
                            case 1: // VIC
                                if(between(postCode, 3000, 3999) == false && between(postCode, 8000, 8999) == false){
                                    errMsg += "Victorian postcodes must start with either a 3 or 8. \n";
                                }
                                break;
                            case 2: // NSW
                                if(between(postCode, 1000, 1999) == false && between(postCode, 2000, 2999) == false){
                                    errMsg += "New South Wales postcodes must start with either a 1 or 2. \n";
                                }
                                break;
                            case 3: // QLD
                                if(between(postCode, 4000, 4999) == false && between(postCode, 9000, 9999) == false){
                                    errMsg += "Queensland postcodes must start with either a 4 or 9. \n";
                                }
                                break;
                            case 4: // NT
                                if(between(postCode, 0, 999) == false){
                                    errMsg += "Northern Territory postcodes must start with a 0. \n";
                                }
                                break;
                            case 5: // WA
                                if(between(postCode, 6000, 6999) == false){
                                    errMsg += "Western Australian postcodes must start with a 6. \n";
                                }
                                break;
                            case 6: // SA
                                if(between(postCode, 5000, 5999) == false){
                                    errMsg += "South Australian postcodes must start with a 5. \n";
                                }                    
                                break;
                            case 7: // TAS
                            if(between(postCode, 7000, 7999) == false){
                                errMsg += "Tasmanian postcodes must start with a 7. \n";
                            }
                                break;
                            case 8: //ACT
                                if(between(postCode, 0, 999) == false){
                                    errMsg += "Australian Capital Territory postcodes must start with a 0. \n";
                                }
                                break;
                        }
                    }
                    else{
                        errMsg += "Please ensure your postcode is 4 digits long. \n"
                    }
                }
            }

        }


        // validate first and last name. 
        if (firstName == "") {
            errMsg += "Please enter your first name.\n";
        }
        if (lastName == "") {
            errMsg += "Please enter your last name.\n";
        }
    }
    // converting string values into integers
    finalPrice = parseInt(finalPrice.innerHTML);
    count = parseInt(count.innerHTML);
 
    if (!debug){
        // Validate the phone selection
        if(product.selectedIndex == 0){
            errMsg += "Please enter a phone you would like to purchase. \n";
        }

        //Validate that a quanity has been selected
        if(count <= 0){
            errMsg += "Please select a quantity you would like to order. \n";
        }
    }
    //Validate the price is positive
/*     if(finalPrice <= 0){
        errMsg += "Please make sure you have selected a positive quantity. \n";
    } */
    //Checks for errors
    if (errMsg != "") { // contains errors
		alert (errMsg);
		result = false;
	}
	else {    // no error, save info to storage
        saveInfo(firstName, lastName, streetAddress, suburbTown, state.value, postCode, product.selectedIndex, count, powerCore.checked, airPods.checked, nest.checked, finalPrice);
	}
    return result;
 }
 
 function between(x, min, max) {
    var result = false;
    if (x >= min && x <= max){
        result = true;
    }
    return result;
  }

 function saveInfo (firstName, lastName, streetAddress, suburbTown, state, postCode, product, count, powerCore, airPods, nest, finalPrice){ //, lastName, streetAddress, suburbTown, state, postcode, product, count, airPods, powerCore, nest, finalPrice){  // save information to storage
    localStorage.clear();
    if(typeof(Storage)!=="undefined"){  // the browser support web storage

        localStorage.setItem("firstName", firstName);
        localStorage.setItem("lastName", lastName);
        localStorage.setItem("streetAddress", streetAddress);
        localStorage.setItem("suburbTown", suburbTown);
        localStorage.setItem("state", state);
        localStorage.setItem("postCode", postCode);
        localStorage.setItem("product", product);
        localStorage.setItem("count", count);

        if(powerCore == true){
            localStorage.setItem("powerCore", powerCore);
        }
        if(nest == true){
            localStorage.setItem("nest", nest);
        }
        if(airPods == true){
            localStorage.setItem("airPods", airPods);
        }	
        localStorage.setItem("finalPrice", finalPrice);
	}
} 




function getInfo(){
    if (typeof(Storage) !=="undefined"){// the browser support web storage
        if (localStorage.getItem("firstName") !== null){// there are some saved info in storage  
			// name
            var cost=0;
            //Checking what product was ordered
            var product = localStorage.getItem("product");
            if(product == 1){
                document.getElementById("product").value = "iPhone XR";
                cost += 1049;
                document.getElementById("productSub").value = "$1049.00";
            }
            else if(product == 2){
                document.getElementById("product").value = "Samsung Galaxy A10";
                cost += 333;
                document.getElementById("productSub").value = "$333.00";
            }
            else if(product == 3){
                document.getElementById("product").value = "Xiaomi Redmi Note 7";
                cost += 269.99;
                document.getElementById("productSub").value = "$269.99";
            }
            
            var subTotal = localStorage.getItem("count") * cost;
            document.getElementById("count").value = localStorage.getItem("count");
            document.getElementById("countSub").value = "$" + subTotal.toFixed(2);

            var extraSubTotal = 0;
            var extraList = [];
            if(localStorage.getItem("airPods") != null){
                extraList.push("Apple AirPods with Charging Case");
                extraList.push("$259.00");
                extraSubTotal += 259;
            }
            if(localStorage.getItem("powerCore") != null){
                extraList.push("Anker PowerCore 5000");
                extraList.push("$15.00");
                extraSubTotal += 15;
            }
            if(localStorage.getItem("nest") != null){
                extraList.push("Google Nest Mini 2rd Generation");
                extraList.push("$49.00");
                extraSubTotal += 49;
            }
            

            document.getElementById("extrasTotal").value = "$" + extraSubTotal.toFixed(2);

            // prints the extras
            var temp = "";
            var temp2 = "";
          	var i = 0;
            for (i = 0; i < 6; i++) {
                temp = i.toString();
                if(extraList[i] == undefined){
                    temp2 = document.getElementById(temp);
                    temp2.remove();
                }
                else{
                    document.getElementById(temp).value = extraList[i];  
                }
              }

            //print final total
            document.getElementById("finalTotal").value = "$" + (extraSubTotal + subTotal).toFixed(2);

            //print Delivery Details
            document.getElementById("fullName").value = localStorage.getItem("firstName") + " " + localStorage.getItem("lastName");
            document.getElementById("DeliveryAdd").value = localStorage.getItem("streetAddress") + ", " + localStorage.getItem("suburbTown") + ", " + localStorage.getItem("state") + " " + localStorage.getItem("postCode");
		}

	}

}

 function clearStorage(){  // for cancel order button
    localStorage.clear();
	location.href="index.html";
}
 
function reset(){
    var airPods = document.getElementById("airPods");
    var powerCore = document.getElementById("powerCore");
    var nest = document.getElementById("nest");

    var product = document.getElementById("phoneVal");
    var finalPrice = document.getElementById("finalPrice");

    var count = document.getElementById("count");

    var firstName = document.getElementById("firstName");
    var lastName = document.getElementById("lastName");
    
    
    var streetAddress = document.getElementById("streetAddress");
    var suburbTown = document.getElementById("suburbTown");
    var state = document.getElementById("state");
    var postCode = document.getElementById("postCode");


    airPods.checked = false;
    powerCore.checked = false;
    nest.checked = false;

    product.selectedIndex = 0;
    finalPrice.innerHTML = 0;

    count.innerHTML = 0;

    firstName.value = null;
    lastName.value = null;

    streetAddress.value = null;
    suburbTown.value = null;
    state.selectedIndex = 0;
    postCode.value = null;
}


 function init() {
    if (document.getElementById("enquireForm")!=null) {  // it is enquire page  
        document.getElementById("enquireForm").onsubmit = validateEnquire;
        var resetBtn = document.getElementById("reset");
        resetBtn.onclick = reset;
	}
	else if (document.getElementById("paymentForm")!=null) { // it is payment page  
        getInfo();     // fill up the page with information passed from enquire page
		document.getElementById("paymentForm").onsubmit = validatePayment;
		document.getElementById("cancelOrder").onclick = clearStorage;
		
	}
}

window.addEventListener("load",init);