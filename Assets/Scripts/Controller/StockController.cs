using System.Collections.Generic;
using BST;

public class StockController
{
    private BSTTree tree = new BSTTree();

    private void Start()
    {
        foreach (var item in StockDataManager.GetStock().items)
        {
            tree.Insert(item.id, item);
        }
    }

    public void AddUpdateItemBST(string itemName, int itemQuantity)
    {
        int itemID = itemName.GetHashCode();
        BSTNode node = tree.Find(itemID);
        if (node == null)
        {
            Item item = new Item()
            {
                id = itemID,
                name = itemName,
                quantity = itemQuantity
            };
            tree.Insert(itemID, item);
        }
        else
        {
            itemID = node.GetData<Item>().name.GetHashCode();
            node.SetData(new Item
            {
                id = itemID,
                name = node.GetData<Item>().name,
                quantity = itemQuantity
            }, itemID);
        }
        List<Item> nodes = new List<Item>();
        tree.PreorderTraversal(nodes);
        StockDataManager.UpdateStock(nodes);
    }
}
