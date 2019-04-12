using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderInfo : MonoBehaviour
{
    [SerializeField]
    private Text orderIDText = null;
    [SerializeField]
    private Text customerNameText = null;
    [SerializeField]
    private Text priceText = null;

    public void Initialize(Order order)
    {
        orderIDText.text = order.id.ToString();
        customerNameText.text = order.clientName;
        int price = 0;
        foreach (var item in order.items)
        {
            price += item.price;
        }
        priceText.text = price.ToString();
    }
}
