using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrdersManager : MonoBehaviour
{
    [SerializeField]
    private UIStockManager uiStockManager = null;
    [SerializeField]
    private OrderController controller = null;
    [SerializeField]
    private InputField customerNameInputField = null;
    [SerializeField]
    private GameObject orderItem = null;
    [SerializeField]
    private Transform orderItemStockContent = null;
    private Order currentOrder;
    private string customerName;
    private List<GameObject> itemGOList = new List<GameObject>();

    public void AddItemUI(Item item)
    {
        GameObject orderItemGameObject = Instantiate(orderItem, orderItemStockContent);
        orderItemGameObject.GetComponent<OrderItem>().Initialize(item);
    }

    public void CreateOrder()
    {
        customerName = customerNameInputField.text;
        if (!string.IsNullOrEmpty(customerName))
        {
            currentOrder = controller.GetOrderBST(customerName);
            if (currentOrder != null)
            {
                foreach (Item item in currentOrder.items)
                {
                    AddItemUI(item);
                }
            }
            else
            {
                controller.SetOrderBST(customerName, new List<Item>());
            }
            uiStockManager.SetOrderState(true);
        }
    }

    public void AddItemOrder(Item item)
    {
        currentOrder = controller.GetOrderBST(customerName);
        if (currentOrder != null)
        {
            currentOrder.items.Add(item);
            controller.SetOrderBST(customerName, currentOrder.items);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        ClearUI();
        foreach (Item item in currentOrder.items)
        {
            AddItemUI(item);
        }
    }

    private void ClearUI()
    {
        foreach (var item in itemGOList)
        {
            Destroy(item);
        }
    }
}
