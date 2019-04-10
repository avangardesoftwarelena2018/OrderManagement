using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityPanel : MonoBehaviour
{
    [SerializeField]
    private Text quantity;
    [SerializeField]
    private Text warningMessage;
    private Item currentItem;

    public void SetItem(Item item)
    {
        currentItem = item;
    }

    public void AddItemInOrder()
    {
        int.TryParse(quantity.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);
        if (itemQuantity <= currentItem.quantity)
        {

        }
        else
        {
            warningMessage.text = "quantity is greater than the available stock";
            quantity.text = "";
        }
    }

}
