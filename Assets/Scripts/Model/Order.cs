using System;
using System.Collections.Generic;

[Serializable]
public class Orders
{
    public List<Order> orders = new List<Order>();
}

[Serializable]
public class Order
{
    public int orderId;
    public List<Item> items = new List<Item>();
}

[Serializable]
public class Item
{
    public string name;
    public int quantity;
}
