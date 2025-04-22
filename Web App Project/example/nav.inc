<nav>
	<ul>
	  <li><a <?php echo ($page=="index_page")?"class='active'":"";  ?> href="index.php">Home</a></li>
	  <li><a <?php echo ($page=="enquire_page")?"class='active'":"";  ?> href="enquire.php">Enquire</a></li>       
	  <li><a <?php echo ($page=="payment_page")?"class='active'":"";  ?> href="payment.php">Payment</a></li>
	  <li><a <?php echo ($page=="manager_page")?"class='active'":"";  ?> href="manager.php">Manager</a></li>
	</ul>
</nav>
<!-- $page is initialised in enquire.php or payment.php ....   -->

<p class="highlight">Please change the username, password and database in settings.php.<p>