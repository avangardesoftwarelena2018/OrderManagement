using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrdersManager : MonoBehaviour
{
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

    public void UpdateUIContent(Item item)
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
                    UpdateUIContent(item);
                }
            }
            else
            {
                controller.SetOrderBST(customerName, new List<Item>());
            }
        }
    }

    public void AddItemOrder(Item item)
    {
        currentOrder = controller.GetOrderBST(customerName);
        if (currentOrder != null)
        {
            currentOrder.items.Add(item);
            UpdateUIContent(item);
        }
    }
}
