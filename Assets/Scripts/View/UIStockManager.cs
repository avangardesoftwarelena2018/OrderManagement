using BST;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStockManager : MonoBehaviour
{
    [SerializeField]
    private InputField itemNameInputField;
    [SerializeField]
    private InputField itemQuantityInputField;
    private List<Item> stockItems = new List<Item>();

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

        Item item = new Item()
        {
            name = itemName,
            quantity = itemQuantity
        };

        BSTTree tree = new BSTTree();
        BSTNode node = tree.Find(itemName.GetHashCode());
    }
   
}
