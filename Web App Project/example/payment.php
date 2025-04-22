<!-- write header comments here  -->
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8" >
	<meta name="description" content="     " >
	<meta name="keywords" content="      " >
	<meta name="author" content="       "  >
	<title>Fruit Shop - Payment</title>
	<link href="styles/style.css" rel="stylesheet" >
	<script src="scripts/part2.js"></script>
</head>
<body>
<?php
	$page="payment_page"; // used by nav.inc to know which page is the current page
	include_once "header.inc";
	include_once "nav.inc";
?>

	<h2>Please complete your payment information</h2>

	<!-- display some summary information based on the basic information -->
	<p>Full Name: <span id="fullName"></span></p>

	<!-- for the information you want to send to the server, put them in a form -->
	<form id="paymentForm" method="post" action="process_order.php">

		<!-- these information need to be sent to the server, but you don't want to show them again, so use hidden input  -->
		<input type="hidden" name= "firstName" id="firstName" > 
		<input type="hidden" name= "lastName" id="lastName" >

		<!-- these information need to be sent to the server and you also want to show them, then don't use hidden-->
		<fieldset>
		<legend>You have ordered:</legend>
		<p>
			<label for="appleQty">Apple (0.99 each)</label>
			<input type="text" id="appleQty" name="appleQty" readonly >
		</p>
		<p>
			<label for="bananaQty">Banana (0.36 each)</label>
			<input type="text" id="bananaQty" name="bananaQty" readonly>
		</p>

		<p>
			<label for="chocBar">Chocolate Bar $1 (save $1) </label>
			<input type="checkbox" name="extraItem[]" id="chocBar" value="chocBar" class="readonlyCheck"><br />
			<!--  there is a css rule about the check box readonly. There is no checkbox readonly,  if use disabled, it won't be sent to the server  -->
			<label for="chewingGum">Chewing Gum $1.85 (save $0.15) </label>
			<input type="checkbox" name="extraItem[]" id="chewingGum" value="chewingGum" class="readonlyCheck"><br />
		</p>	
		<p>Total Cost: <input type="text" name= "totalCost" id="totalCost" readonly></p>
		</fieldset>
		
		<!-- credit card information  -->
		<fieldset>
		<legend>Payment Details</legend>
		<p>
			<label for="cardType">Card Type:</label>
			<select name="cardType" id="cardType">
				<option value="visa">Visa</option>			
				<option value="master">MasterCard</option>
				<option value="amex">American Express</option>
			</select>
		<p>	
		<p>
			<label for="cardName">Name on Card:</label> 
			<input type="text" name= "cardName" id="cardName" >
		</p>
		<p> <label for="cardNumber">Card Number:</label> 
			<input type="text" name= "cardNumber" id="cardNumber"  >
		</p>
		<p>Other credit card details here...</p>
		</fieldset>
		<p>
			<input type= "submit" name="submitButton" value="Check Out" >
			<input id="cancelOrder" type= "reset" value="Cancel Order" >
		</p>
	 
	</form>
	
<?php
	include_once "footer.inc";
?>
</body>
</html>