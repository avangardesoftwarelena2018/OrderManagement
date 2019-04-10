using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StockItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text quantityText;
    private Action<Item> callbackDoubleClick;
    private Item stockItem;

    public void Initialize(Item item, Action<Item> callback)
    {
        stockItem = item;
        callbackDoubleClick = callback;
        nameText.text = item.name;
        quantityText.text = item.quantity.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
            OnDoubleClick();
    }

    private void OnDoubleClick()
    {
        callbackDoubleClick.Invoke(stockItem);
    }
}
