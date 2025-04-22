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

	echo "<h2>Receipt</h2>";
 	
	if (!isset($_GET["db_msg"])) {// not from process_order.php, redirection
		header("location:enquire.php");
		exit();
	}
	else { // from process_order.php, display receipt
		echo $_GET["db_msg"];
	}
	
	include_once "footer.inc";
?>
</body>
</html>