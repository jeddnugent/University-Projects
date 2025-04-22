<!-- write header comments here  -->
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" >
	<meta name="description" content="     " >
	<meta name="keywords" content="      " >
	<meta name="author" content="       "  >
	<title>Fruit Shop - Home</title>
	<link href="styles/style.css" rel="stylesheet" >
	<script src="scripts/part2.js"></script>
</head>
<body>
<?php
	$page="index_page"; // used by nav.inc to know which page is the current page
	include_once "header.inc";
	include_once "nav.inc";
?>


	<h2>You can order fruits from us.</h2>
	<img src="images/fruits.png" alt="fruits">
	<h2>This is not a complete and perfect website. It is mainly used to demonstrate some useful techniques. </h2>
	
<?php
	include_once "footer.inc";
?>

</body>
</html>