using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantityPanel : MonoBehaviour
{
    [SerializeField]
    private UIStockManager uiStockManager = null;
    [SerializeField]
    private StockController stockController = null;
    [SerializeField]
    private UIOrdersManager uiOrdersManager = null;
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
        if (itemQuantity <= currentItem.quantity && !string.IsNullOrEmpty(quantityInputField.text) && itemQuantity > 0)
        {
            AddItemInOrder(itemQuantity);
            UpdateAddedItemInStock(itemQuantity);

            gameObject.SetActive(false);
            warningMessage.text = "Insert quantity";
        }
        else
        {
            warningMessage.text = "Incorrect quantity or not enough items!";
            quantityInputField.text = "";
        }
    }

    private void UpdateAddedItemInStock(int itemQuantity)
    {
        stockController.SetItemBST(currentItem.name, currentItem.quantity - itemQuantity);
        uiStockManager.UpdateUI();
    }

    private void AddItemInOrder(int itemQuantity)
    {
        Item newAddedItem = new Item()
        {
            id = currentItem.id,
            name = currentItem.name,
            quantity = itemQuantity
        };
        uiOrdersManager.AddItemOrder(newAddedItem);
    }

    private void OnDisable()
    {
        warningMessage.text = "Insert quantity";
    }
}
