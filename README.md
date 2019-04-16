# OrderManagement
## An order management application. Using the UI, a user is be able to add new items to the inventory and place orders for customers.
* App is based on MVC pattern
* For managing the inventory and the orders is used BST-Binary Search Trees
https://github.com/avangardesoftwarelena2018/BinaryTreeExample
* App has 4 tabs:
* Tab1.Inventory - Add items in inventroy (name, price, quantity, sale);

            If the item already exists, the new quantity is added to the existing one;
            If the item does not exist, a new entry is made for the item and its quantity.

* Tab2.Order - Create order for customer (customer name, add itemes in order by double click on invetory item);

            When making the selection to create an order, the user is presented with a window asking for the customer’s name;
            If a customer already has an order placed, the new order is added on top of the old one;
            If a customer does not have an order placed, a new order is created for them;
            The user can see a list of the inventory with names and quantities;
            Double clicking on an item prompt the user to enter a quantity;
            If the quantity is greater than the available stock, the user is warned and asked to insert a different quantity;
            After the item is added to the order, the order details are refreshed

* Tab3.Orders - Shows all created orders;

           On order click are shown all items in the order;
           On proceed button click all orders are send to history orders;

* Tab4.History - Shows all proceeded orders.
