using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStockManager : MonoBehaviour
{
    [SerializeField]
    private StockController controller = null;
    [SerializeField]
    private InputField itemNameInputField = null;
    [SerializeField]
    private InputField itemPriceInputField = null;
    [SerializeField]
    private InputField itemQuantityInputField = null;
    [SerializeField]
    private Transform stockItemStockContent = null;
    [SerializeField]
    private Transform stockItemOrderContent = null;
    [SerializeField]
    private GameObject stockItem = null;
    [SerializeField]
    private GameObject quantityPanel = null;
    private List<GameObject> itemGOList = new List<GameObject>();
    private List<GameObject> itemGOOrderList = new List<GameObject>();
    private bool wasOrderCreated;

    public void AddItemUI(Item item)
    {
        GameObject itemGameObject = Instantiate(stockItem, stockItemStockContent);
        itemGOList.Add(itemGameObject);
        itemGameObject.GetComponent<StockItem>().Initialize(item, OpenQuantityPanel);
    }

    public void SaveStockItem()
    {
        string itemName = itemNameInputField.text;
        int.TryParse(itemQuantityInputField.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);
        int.TryParse(itemPriceInputField.text, out int itemPrice);
        itemPrice = Mathf.Abs(itemQuantity);
        if (!string.IsNullOrEmpty(itemName) && itemQuantity > 0)
        {
            controller.SetItemBST(itemName, itemQuantity, itemPrice);
            UpdateUI();
        }
    }

    public void SetOrderState(bool value)
    {
        wasOrderCreated = value;
    }

    public void UpdateUI()
    {
        ClearUI();
        foreach (Item item in StockDataManager.GetStock().items)
        {
            AddItemUI(item);
        }
    }

    public void UpdateStockContentOrder()
    {
        foreach (var item in itemGOOrderList)
        {
            Destroy(item);
        }
        foreach (Item item in StockDataManager.GetStock().items)
        {
            GameObject itemGameObject = Instantiate(stockItem, stockItemOrderContent);
            itemGOOrderList.Add(itemGameObject);
            itemGameObject.GetComponent<StockItem>().Initialize(item, OpenQuantityPanel);
        }
    }

    private void ClearUI()
    {
        itemNameInputField.text = "";
        itemPriceInputField.text = "";
        itemQuantityInputField.text = "";
        foreach (var item in itemGOList)
        {
            Destroy(item);
        }
    }

    private void OpenQuantityPanel(Item item)
    {
        if (wasOrderCreated)
        {
            quantityPanel.SetActive(true);
            quantityPanel.GetComponent<QuantityPanel>().SetItem(item);
        }
    }

}
