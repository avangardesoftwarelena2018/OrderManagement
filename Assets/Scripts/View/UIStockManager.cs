using UnityEngine;
using UnityEngine.UI;

public class UIStockManager : MonoBehaviour
{
    [SerializeField]
    private StockController controller = null;
    [SerializeField]
    private InputField itemNameInputField = null;
    [SerializeField]
    private InputField itemQuantityInputField = null;
    [SerializeField]
    private Transform stockItemStockContent = null;
    [SerializeField]
    private GameObject stockItem = null;
    [SerializeField]
    private GameObject quantityPanel = null;

    public void UpdateUIContent(Item item)
    {
        GameObject itemGameObject = Instantiate(stockItem, stockItemStockContent);
        itemGameObject.GetComponent<StockItem>().Initialize(item, OpenQuantityPanel);
    }

    public void SaveStockItem()
    {
        string itemName = itemNameInputField.text;
        int.TryParse(itemQuantityInputField.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);
        if (!string.IsNullOrEmpty(itemName))
        {
            controller.SetItemBST(itemName, itemQuantity);
            Item newAddedItem = controller.GetItemBST(itemName);
            UpdateUIContent(newAddedItem);
        }
    }

    private void OpenQuantityPanel(Item item)
    {
        quantityPanel.SetActive(true);
        quantityPanel.GetComponent<QuantityPanel>().SetItem(item);
    }
}
