<!-- write header comments here  -->
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8" />
	<meta name="description" content="     " >
	<meta name="keywords" content="      ">
	<meta name="author" content="       "  >
	<title>Fruit Shop - Our Fruits</title>
	<link href="styles/style.css" rel="stylesheet" >
	<script src="scripts/part2.js"></script>
	<script src="scripts/enhancement.js"></script>
</head>
<body>
<?php
	$page="enquire_page"; // used by nav.inc to know which page is the current page
	include_once "header.inc";
	include_once "nav.inc";
?>

	<h2>Place an Order</h2>
 	<figure>
		<img src="images/apple.png" id="picImage"  alt="landscape"  >
	</figure>
	
	<form id="enquireForm" action="payment.php">
		<!--  first name and last name -->
		<p>
			<label for="firstName">First Name:</label>
			<input type="text" name="firstName" id="firstName"  >
		</p>
		<p>
			<label for="lastName">Last Name:</label>
			<input type="text" name="lastName" id="lastName"  >
		</p>
		<hr>
		<!--  order quantity -->
		<p>Please enter the quantity:</p>
		<p>
			<label for="appleQty">Apple (0.99 each)</label>
			<input type="text" id="appleQty" name="appleQty"   >
		</p>
		<p>
			<label for="bananaQty">Banana (0.36 each)</label>
			<input type="text" id="bananaQty" name="bananaQty"   >
		</p>
		<hr>
		<!--  recommended items -->
		<p>You may also like these itmes:</p>
		<p>
			<label for="chocBar">Chocolate Bar $1 (save $1) </label>
			<input type="checkbox" name="chocBar" id="chocBar" value="chocBar"><br />
			
			<label for="chewingGum">Chewing Gum $1.85 (save $0.15) </label>
			<input type="checkbox" name="chewingGum" id="chewingGum" value="chewingGum"><br />
		</p>
		<!--  submit and reset -->		
		<p>
			<input type="submit" value="Order Now" >
			<input type="reset" value="Reset" >
		</p>
	</form>

<?php
	include_once "footer.inc";
?>
	
</body>
</html>