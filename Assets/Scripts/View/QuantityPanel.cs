using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityPanel : MonoBehaviour
{
    [SerializeField]
    private InputField quantityInputField = null;
    [SerializeField]
    private Text warningMessage = null;
    private Item currentItem;

    public void SetItem(Item item)
    {
        currentItem = item;
    }

    public void AddItemInOrder()
    {
        int.TryParse(quantityInputField.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);
        if (itemQuantity <= currentItem.quantity && !string.IsNullOrEmpty(quantityInputField.text))
        {
            gameObject.SetActive(false);
            warningMessage.text = "Insert quantity";
        }
        else
        {
            warningMessage.text = "Quantity is greater than the available stock!";
            quantityInputField.text = "";
        }
    }
    private void OnDisable()
    {
        warningMessage.text = "Insert quantity";
    }
}
