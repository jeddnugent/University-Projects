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
  <script src="scripts/part2.js"></script>
  <script src="scripts/enhancements.js"></script>
  <script src="scripts/fml.js"></script>
</head>
<body>
    <header>
        <h1>Mobile Phones 4 You</h1> 
      </header>
      <ul class="nav"> <!-- Nav bar formatting from: https://csswizardry.com/2011/01/create-a-centred-horizontal-navigation/ --> 
        <li><a href="index.html">Home</a></li>
        <li><a href="product.html">Product</a></li>
        <li><a href="enquire.html">Enquire</a></li>
        <li><a href="about.html">About</a></li>
        <li><a href="enhancements.html">Enhancements</a></li>
        <li><a href="enhancements2.html">Enhancements 2</a></li>
    </ul>
<section class="center">
  <h2>Order Enquiries</h2>
  <fieldset>
    <legend>Persoanl Details</legend>
    <p>
      <label for="firstName">First Name:</label>
      <input type="text" name="firstName" id="firstName">
    </p>
    <p>
      <label for="lastName">Last Name:</label>
      <input type="text" name="lastName" id="lastName">
    </p>
    <p>
    <label for="streetAddress">Street Address</label>
    <input type="text" id="streetAddress" name="streetAddress"  maxlength="40"/>
    
    
    <label for="suburbTown">Suburb/town</label>
    <input type="text" id="suburbTown" name="suburbTown" pattern = "^[a-zA-Z ]+$" maxlength="20"/>
    </p>
    <p><label for="state">State</label> 
        <select name="state" id="state" >
            <option value="">Please Select</option>
            <option value="VIC">VIC</option>			
            <option value="NSW">NSW</option>
            <option value="QLD">QLD</option>
            <option value="NT">NT</option>
            <option value="WA">WA</option>
            <option value="SA">SA</option>
            <option value="TAS">TAS</option>
            <option value="ACT">ACT</option>
        </select>
        
        <label for="postCode">Postcode</label>
            <input type="text" id="postCode" name="postCode" pattern="([0-9][0-9][0-9][0-9])" maxlength="4"/>

    </p>
</fieldset>
      <fieldset class="order">
        <legend>Order Details</legend> 
        <table id="prodTable">
          <tr>
            <th>
                <img src="images/iphoneXR.png" alt="Apple iPhone XR" width="180" class="jump"> <!--Original Image: https://static.salidzini.lv/item_image.jpg?w=180&h=180&c=35c&d=https%3A%2F%2Flabsveikals.lv%2Fimage%2Fdata%2Fimp_1701874971%2Fa862739fdd54e95c823768489f3199a5%2F5551000_0_f.jpg-->
            </th>
            <th>
                 <img src="images/samsungA10.png" alt="Samsung Galaxy A10" width="150" class="jump"> <!-- Original Image: https://www.mobilebazaar.com.pk/image/cache/catalog/products/samsung/a10/Samsung-Galaxy-A10-image-removebg-preview-500x500.png-->
            </th>
            <th>
                <img src="images/note7.png" alt="Xiaomi Redmi Note 7" width="160" class="jump"> <!-- Original Image: https://i.ebayimg.com/images/g/KHYAAOSwSk9cfPXD/s-l400.png-->
           </th>
        </tr>
          <tr>
            <th colspan="3"> Price </th>
        </tr>
          <tr>
            <td>
                iPhone XR
            </td>
            <td>
                Samsung Galaxy A10
            </td>
            <td>
                Xiaomi Redmi Note 7
            </td>
        </tr>

        <tr>
            <td>$1,049.00</td>
            <td>$333.00</td>   
            <td>$269.99</td>
        </tr>
        </table>
        <p><label for="phoneVal" >Please Select what product you would like to order:</label> 
          <select name = "phoneVal" id="phoneVal" onchange="dropdown()"> <!-- onchange="test()" -->
              <option value="">Please Select</option>
              <option value="XR">iPhone XR</option>			
              <option value="A10">Samsung Galaxy A10</option>
              <option value="Note7">Xiaomi Redmi Note 7</option>
          </select>


       
<!--           This code was based off code from: https://stackoverflow.com/questions/35827443/in-html-on-click-button-values-is-increase-or-decrease-by-1 -->
          <h3 class = "order">Please enter the quantity:</h3>
        <p>
        <button onclick="clicked(-1)">Previous</button>
        <span id="count">0</span>
        <button onclick="clicked(1)">next</button>
        </p>
        
        <h3 class = "order">You may also like these items: </h3>
        <p>
          <label for="airPods"> Apple AirPods with Charging Case $259.00</label>
          <input type="checkbox" name="airPods" id="airPods" value="airPods"><br />
          
          <label for="powerCore">Anker PowerCore 5000 $15.00 (save $3.00) </label>
          <input type="checkbox" name="powerCore" id="powerCore" value="powerCore"><br />
          
          <label for="nest">Google Nest Mini 2rd Generation $49.00 (save $10.00) </label>
          <input type="checkbox" name="nest" id="nest" value="nest"><br />
        </p>
        
        <p>Your total will come to: $<span id ="finalPrice">0.00</span></p>
    <form id="enquireForm" action="payment.html">
    <input type="submit" value="Order Now" >
    <input type="button" id ="reset" value="Reset" >
    </form>
  </fieldset>
</section>
<footer>
    <p>Mobile Phones 4 You &copy; &nbsp; Contact information: <a href="mailto:103064999@student.swin.edu.au"> 103064999@student.swin.edu.au </a></p>
</footer>
</body>
</html>
