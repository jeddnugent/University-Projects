<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8" />
  <meta name="description" content="The online storefront for Mobile Phones 4 You" />
  <meta name="keywords" content="Mobile, Phones, Mobile Phones, Sale, Apple, Samsung, iPhone, Galaxy, Oppo" />
  <meta name="author" content="Jedd Nugent"  />
  <link rel="icon" href = "images/phoneIcon.png"> <!--Original img: https://www.theblocklearning.com/wp-content/uploads/2018/09/mobile.png-->
  <title>Mobile Phones 4 U</title>
  <link href= "styles/style.css" rel="stylesheet"/>
</head>
<body>
<?php
	$page="index"; // used by nav.inc to know which page is the current page
	#include_once "header.inc";
	include_once "nav.inc";
?>


    <section class="center">
    
        <h2>Welcome to Mobile Phones 4 you</h2>
        <img src="images/cellPhRange.jpg" alt="Wide Selection of Phones" width="500" class="centerImg"> <!-- Original Image: https://149362378.v2.pressablecdn.com/wp-content/uploads/2019/07/idc_583434ca63022.jpg-->

        <p>Mobile Phones 4 You &copy; is now Australia’s leading distributer of mobile phones. After breaking new ground in our retail practices down under, we have expanded our operation to now be Australia’s premier online location for purchasing the newest in Mobile technologies; whether you are loyal to Stevie Jobs and Apple or are Bill Gatesian we have the phones for you. Feel free to browse our website for our expansive catalogue of mobile phones available to you. If you have any enquiries or complaints, please navigate your way on over to our <a href="enquire.html">Enquire</a> page where any complaints can be lodged.</p>
    </section>




<?php
	include_once "footer.inc";
?>
   
</body>
</html>