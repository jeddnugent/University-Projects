<!-- write header comments here  -->
<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8" >
	<meta name="description" content="     " >
	<meta name="keywords" content="      " >
	<meta name="author" content="       "  >
	<title>Fruit Shop </title>
	<link href="styles/style.css" rel="stylesheet" >
</head>
<body>
<?php
	$page="payment_page"; // used by nav.inc to know which page is the current page
	include_once "header.inc";
	include_once "nav.inc";
?>

	<h2>Please Fix the Errors</h2>

<?php 
	// *******************  not from process_order.php, redirection
	if (!isset($_GET["err_msg"])) {
		header("location:enquire.php");
		exit();// terminiate 
	}
	// **********************   from process_order.php
	// display error message  
	echo "<div class='error'>";
	echo $_GET["err_msg"];
	echo "</div>";
	// get values
	session_start();
	if (isset($_SESSION["firstName"]))    // first name
		$firstName=$_SESSION["firstName"];
	else 
		$firstName="";
	 
	if (isset($_SESSION["lastName"]))    // last name
		$lastName=$_SESSION["lastName"];
	else 
		$lastName="";
	
	if (isset($_SESSION["appleQty"]))  // apple qty
		$appleQty=$_SESSION["appleQty"];
	else 
		$appleQty=0;

	if (isset($_SESSION["bananaQty"]))   // banana qty
		$bananaQty=$_SESSION["bananaQty"];
	else 
		$bananaQty=0;
	
	if (isset($_SESSION["extraItemString"]))   // extra item (check box)
		$extraItemString=$_SESSION["extraItemString"];
	else 
		$extraItemString=0;
	
	$chocBar = (strpos($extraItemString,"chocBar")!==false); //if $extraItemString contains 'chocBar' then $chocBar is true
	$chewingGum = (strpos($extraItemString,"chewingGum")!==false);
		
?>
	<!-- fill up values in form  -->
	<form method="post" action="process_order.php">
		<p>
			<label for="firstName">First Name</label>
			<input type="text" id="firstName" name="firstName" value="<?php echo $firstName; ?>" >
		</p>
		<p>
			<label for="lastName">Last Name</label>
			<input type="text" id="lastName" name="lastName" value="<?php echo $lastName; ?>" >
		</p>
		<p>
			<label for="appleQty">Apple Quantity</label>
			<input type="text" id="appleQty" name="appleQty" value="<?php echo $appleQty; ?>" >
		</p>
		<p>
			<label for="bananaQry">Banana Quantity</label>
			<input type="text" id="bananaQty" name="bananaQty" value="<?php echo $bananaQty; ?>" >
		</p>
		<p>
			<label for="chocBar">Chocolate Bar</label>
			<input type="checkbox" name="extraItem[]" id="chocBar" value="chocBar" 
			       <?php echo ($chocBar)?"checked":"";  ?>   ><br />
			<label for="chewingGum">Chewing Gum</label>
			<input type="checkbox" name="extraItem[]" id="chewingGum" value="chewingGum" 
			       <?php echo ($chewingGum)?"checked":"";  ?>   ><br />
		</p>	
		
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
 		</p>
	 
	</form>
	
<?php
	include_once "footer.inc";
?>
</body>
</html>