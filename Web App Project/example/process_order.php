<?php 
	// write header comments here 	
	// description about this file
	
	function sanitise_input($data) {
   		$data = trim($data);
   		$data = stripslashes($data);
   		$data = htmlspecialchars($data);
   		return $data;
	}
	
	// *********************  if it is not submitted from payment, redirection
	if (!isset($_POST["submitButton"])) {//it is not triggered by payment form submission (eg. by direct URL access)
		header("location:enquire.php");
		exit();
	}
	
	// **********************  validate form  
	$err_msg="";
	
	// first name
	if (!isset($_POST["firstName"])) {
		// if this page is triggered by payment form submission, all text inputs are set
		// for security reason, just in case somebody created a similar form, and tried to submit to process_order, we can also test isset for all the text inputs
		header("location:enquire.php");
		exit();
	}
	else{
		$firstName=$_POST["firstName"];  
		$firstName=sanitise_input($firstName);
		if ($firstName=="") {
			$err_msg .= "<p>Please enter first name.</p>";
		}
		else if (!preg_match("/^[a-zA-Z]{2,20}$/",$firstName)) {
			$err_msg .= "<p>First name can only contain max 20 alpha characters.</p>";
		}
	}
	
	// last name  	
	if (!isset($_POST["lastName"])) {
		header("location:enquire.php");
		exit();
	}
	else{
		$lastName=$_POST["lastName"];  
		$lastName=sanitise_input($lastName);
		if ($lastName=="") {
			$err_msg .= "<p>Please enter last name.</p>";
		}
		else if (!preg_match("/^[a-zA-Z]{2,20}$/",$lastName)) {
			$err_msg .= "<p>Last name can only contain max 20 alpha characters.</p>";
		}
	}
	//apple quantity
	if (!isset($_POST["appleQty"])) {
		header("location:enquire.php");
		exit();
	}
	else {
		$appleQty=$_POST["appleQty"];  
		$appleQty=sanitise_input($appleQty);
		if ($appleQty=="") {
			$appleQty=0;
		}
		else if (!is_numeric($appleQty)) {
			$err_msg .= "<p>Apple quantity is not numeric.</p>";
		}
		else {
			$appleQty=(int)$appleQty;
		}
	}
	// banana quantity
	if (!isset($_POST["bananaQty"])) {
		header("location:enquire.php");
		exit();
	}
	else {
		$bananaQty=$_POST["bananaQty"]; 
		$bananaQty=sanitise_input($bananaQty);
		if ($bananaQty=="") {
			$bananaQty=0;
		}
		else if (!is_numeric($bananaQty)) {
				$err_msg .= "<p>Banana quantity is not numeric.</p>";
			}
		else {
			$bananaQty=(int)$bananaQty;
		}
	}	
	// extra item (check box)
	if (!isset($_POST["extraItem"])) {
		$extraItemString="";  
	}
	else {
		$extraItem=$_POST["extraItem"];  // array
		$extraItemString=implode(",",$extraItem); //make the array a comma-separated string
		$extraItemString=sanitise_input($extraItemString);
	}

	// credit card related values 
	$cardType=$_POST["cardType"]; 
	$cardName=$_POST["cardName"]; 
	$cardNumber=$_POST["cardNumber"]; 
					// need sanitise, and validation  

	// ********************** there are errors, redirect to fix_order.php
	if ($err_msg!=""){
		// pass the name-value pairs via session, pass the err_msg using query string
		// you can use other methods
		session_start();
		$_SESSION['firstName'] = $firstName;
		$_SESSION['lastName'] = $lastName;
		$_SESSION['appleQty'] = $appleQty;
		$_SESSION['bananaQty'] = $bananaQty;
		$_SESSION['extraItemString'] = $extraItemString;
				
		//echo $err_msg;
		header("location:fix_order.php?err_msg=$err_msg"); 
		exit();
	}
	
	// ********************** no error, insert into database , redirect to receipt.php
	$db_msg="";  //record messages during database operations
	require_once "settings.php";	 
	$conn = mysqli_connect ($host,$user,$pwd,$sql_db);	 
 
	if ($conn) { 
		// create table if not exists
		$query = "CREATE TABLE IF NOT EXISTS orders (
					order_id INT AUTO_INCREMENT PRIMARY KEY, 
					firstName VARCHAR(25),
					lastName VARCHAR(25),
					appleQty INT,
					bananaQty INT,
					extraItem VARCHAR (50), 
					orderCost DECIMAL(5,2),
					orderTime DATETIME,
					cardType VARCHAR (20),
					cardName VARCHAR (20),
					cardNumber VARCHAR (20),					
					orderStatus VARCHAR(20)
					);";
					
		$result = mysqli_query ($conn, $query);
		if ($result) {	// create table successfull	
			// calculate cost 
			$cost = 0.99 * $appleQty + 0.36 * $bananaQty;
			
			if (strpos($extraItemString,"chocBar")!==false) $cost += 1;
			if (strpos($extraItemString,"chewingGum")!==false) $cost += 1.85;
			// date time
			$datetime = date('Y-m-d H:i:s');
			// insert
			$query = "INSERT INTO orders (firstName, lastName, appleQty, bananaQty, extraItem, 	
					orderCost, orderTime, cardType, cardName, cardNumber, orderStatus) 
					VALUES ('$firstName','$lastName', $appleQty, $bananaQty, '$extraItemString', $cost,'$datetime', '$cardType','$cardName','$cardNumber','PENDING');";
			$insert_result = mysqli_query ($conn, $query);
 
			if ($insert_result) {	//   insert successfully 
				$db_msg="<p>Your order is inserted into the database.</p>"
						. "<table class='receiptTable'><tr><th>Item</th><th>Value</th></tr>"
						. "<tr><th>Order ID</th><td>" . mysqli_insert_id($conn) . "</td></tr>"
						. "<tr><th>First Name</th><td>$firstName</td></tr>"
						. "<tr><th>Last Name</th><td>$lastName</td></tr>"
						. "<tr><th>Apple Quantity</th><td>$appleQty</td></tr>"
						. "<tr><th>Banana Quantity</th><td>$bananaQty</td></tr>"
						. "<tr><th>Extra Item</th><td>$extraItemString</td></tr>"
						. "<tr><th>Cost</th><td>$cost</td></tr>"
						. "<tr><th>Date</th><td>$datetime</td></tr>"
						. "<tr><th>Status</th><td>PENDING</td></tr>"
						. "</table>";  // you can display more information 
							
			} else {
				$db_msg= "<p>Insert  unsuccessful.</p>";
			}
		} else {
			$db_msg= "<p>Create table operation unsuccessful.</p>";
		}
		mysqli_close ($conn);					// Close the database connect
	} else {
		$db_msg= "<p>Unable to connect to the database.</p>";
	}
	//  redirect to receipt.php
	//echo $db_msg;
	header("location:receipt.php?db_msg=$db_msg");

	
?>	
 