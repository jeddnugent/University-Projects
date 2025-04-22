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
	$page="manager_page"; // used by nav.inc to know which page is the current page
	include_once "header.inc";
	include_once "nav.inc";
?>

	<h2>Manager Page</h2>
<?php
	if (!isset($_POST["fn"])&&!isset($_POST["ln"]))
		$query = "SELECT * FROM orders;";	
	else {
		$fn=trim($_POST["fn"]);
		$ln=trim($_POST["ln"]);
		$query="SELECT * FROM orders WHERE firstName LIKE '%$fn%' and lastName LIKE '%$ln%'";
	}
	 
	require_once "settings.php";	// Load MySQL log in credentials
	$conn = mysqli_connect ($host,$user,$pwd,$sql_db);	// Log in and use database
	if ($conn) { // connected
 
		$result = mysqli_query ($conn, $query);		
		if ($result) {	//   query was successfully executed
			
			$record = mysqli_fetch_assoc ($result);
			if ($record) {		//   record exist
				echo "<table class='managerTable'>";
				echo "<tr><th>order_id</th><th>First Name</th><th>Last Name</th><th>Apple Quantity</th><th>Banana Quantity</th><th>Extra Items</th><th>Order Cost</th><th>Order Time</th><th>Order Status</th></tr>";
				while ($record) {
					echo "<tr><td>{$record['order_id']}</td>";
					echo "<td>{$record['firstName']}</td>";
					echo "<td>{$record['lastName']}</td>";
					echo "<td>{$record['appleQty']}</td>";
					echo "<td>{$record['bananaQty']}</td>";
					echo "<td>{$record['extraItem']}</td>";
					echo "<td>{$record['orderCost']}</td>";
					echo "<td>{$record['orderTime']}</td>";
					echo "<td>{$record['orderStatus']}</td></tr>";
					$record = mysqli_fetch_assoc($result);
				}
				echo "</table>";
				mysqli_free_result ($result);	// Free resources
			} else {
				echo "<p>No record retrieved.</p>";
			}
		} else {
			echo "<p>Orders table doesn't exist or select operation unsuccessful.</p>";
		}
		mysqli_close ($conn);	// Close the database connection
	} else {
		echo "<p>Unable to connect to the database.</p>";
	}
?>	
	<h2>Search Order</h2>
	<form action="manager.php" method="post">
		<p><label>First Name: <input type="text" name="fn" ></label></p>    
		<p><label>Last Name: <input type="text" name="ln" ></label></p>     
		<input type="submit" value="Search" >
	</form>

<?php
	include_once "footer.inc";
?>
</body>
</html>