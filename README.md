# Food Ordering App

Each restaurant has the following information:
-	Name
-	Schedule
-	Minimum order (total food price without transportation fee)
-	Standard delivery maximum distance (km)
-	Standard delivery price
-	Extra delivery fee (price/km)
The user cannot place an order for multiple restaurants at one time.
If the current time is out of the restaurant schedule, the user is not able to select the restaurant.
Once a restaurant is selected the menu items are displayed, each item having the following information:
-	Name
-	Description
-	Price
When an item is added to the cart in addition to the desired quantity, the user can also write mentions.
Once the user has selected all the desired items, he can place the order by reaching the “Complete order” form having the following fields:
-	Name (required)
-	Address (required)
-	Distance in km (required)
-	Order mentions (optional)
After the user submits, the order is confirmed by giving the user a unique code that can be entered on the homepage to check the order details and status.
If the entered distance exceeds the standard delivery distance, the user will be charged each extra km with the “Extra delivery fee”.
If the “Minimum order” is not reached the user will be alerted when trying to complete the form.
