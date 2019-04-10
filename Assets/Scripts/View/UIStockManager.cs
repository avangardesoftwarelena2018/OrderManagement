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
   
    public void SaveStockItem()
    {
        string itemName = itemNameInputField.text;
        int.TryParse(itemQuantityInputField.text, out int itemQuantity);
        itemQuantity = Mathf.Abs(itemQuantity);
        if (!string.IsNullOrEmpty(itemName))
        {
            controller.AddUpdateItemBST(itemName, itemQuantity);
        }
    }
}
