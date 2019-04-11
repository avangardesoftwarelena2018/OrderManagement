using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderItem : MonoBehaviour
{
    [SerializeField]
    private Text nameText = null;
    [SerializeField]
    private Text quantityText = null;

    public void Initialize(Item item)
    {
        nameText.text = item.name;
        quantityText.text = item.quantity.ToString();
    }

}
