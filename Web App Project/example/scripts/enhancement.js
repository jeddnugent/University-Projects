"use strict";
var running;
var currentImg = 0;  // set start position as global
var theImages = new Array("images/apple.png","images/banana.png","images/mandarin.png","images/pear.png");

function cycleImage() {
   var figImg = document.getElementById("picImage");
   if(document.images) {
	currentImg++;	
	currentImg = currentImg%4;
	figImg.src = theImages[currentImg];
   }
}
 	
function enhancement_init() {
	running = setInterval("cycleImage()", 2000);  //2 secs
}
// if you link to 2 javascript files in the same html and they both have init, you can use addEventListener and give the two init function different names
window.addEventListener("load",enhancement_init);
//window.onload = init;