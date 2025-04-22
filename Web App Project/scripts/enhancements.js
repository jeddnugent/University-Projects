/**
 * Author: Jedd Nugent 103064999
 * Target: equire.html
 * Purpose: enhance the html through the use of java script
 * Created: 21/04/2020
 * Last updated: 05/05/2020
 * Credits:
 */


//This code was based off code from: https://stackoverflow.com/questions/35827443/in-html-on-click-button-values-is-increase-or-decrease-by-1
"use strict";
var i = 0;
function clicked(n) {
    
    var count = document.getElementById("count");
    i = i + n;
    count.innerHTML = i;
    var phPrice = finalPrice();
    var extra = extras();
    updatePrice(phPrice, extra, i);


}
function finalPrice(){
   
    var phPrice = 0;
    var product = document.getElementById("phoneVal").value;
    
    
    if(product == "XR"){
        phPrice = 1049;
    }

    else if(product == "A10"){
        phPrice = 333;
    }

    else if(product == "Note7"){
        phPrice = 269.99;
    }

    return phPrice;
}

function updatePrice(phonePrice, extraPrice, Quanity){
    var finalPrice = document.getElementById("finalPrice");
    phonePrice = phonePrice * Quanity;
    
    if (extraPrice > 0){
        phonePrice = phonePrice + extraPrice;
    } 
    finalPrice.innerHTML = phonePrice.toFixed(2);
}
function extras(){
    var airPods = document.getElementById("airPods").checked;
    var powerCore = document.getElementById("powerCore").checked;
    var nest = document.getElementById("nest").checked;
    var extra = 0;

    if (airPods == true){
        extra += 259;
    }
    if (powerCore == true){
        extra += 15;
    }
    if (nest == true){
        extra += 49;
    }

    return extra;
}



function dropdown(){
    var phPrice = finalPrice();
    var extra = extras();
    updatePrice(phPrice, extra, i);
}

function check(){
    var phPrice = finalPrice();
    var extra = extras();
    updatePrice(phPrice, extra, i);
}

function init(){
    var checkAirpod = document.getElementById("airPods");
    checkAirpod.onchange = check;
    var checkPowercore = document.getElementById("powerCore");
    checkPowercore.onchange = check;
    var checkNest = document.getElementById("nest");
    checkNest.onchange = check;
}


window.addEventListener("load",init);