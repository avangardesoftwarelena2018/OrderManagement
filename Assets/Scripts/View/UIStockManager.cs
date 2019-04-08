using BST;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStockManager : MonoBehaviour
{
    [SerializeField]
    private InputField itemNameInputField = null;
    [SerializeField]
    private InputField itemQuantityInputField = null;
    private List<Item> stockItems = new List<Item>();
    private BSTTree tree = new BSTTree();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveStockItem()
    {
        string itemName = itemNameInputField.text;
        int.TryParse(itemQuantityInputField.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);


        BSTNode node = tree.Find(itemName);
        if (node == null)
        {
            Item item = new Item()
            {
                name = itemName,
                quantity = itemQuantity
            };
            tree.Insert(item);
        }
        else
        {
            node.SetData(new Item
            {
                name = node.GetData<Item>().name,
                quantity = itemQuantity
            });
        }
        tree.PreorderTraversal();
    }
   
}
