using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StockDataManager
{
    private static Stock stock;

    private static string projectFilePath = "/stock.json";

    public static Stock GetStock()
    {
        return LoadData();
    }

    //LoadData from json file
    private static Stock LoadData()
    {
        string filePath = Application.dataPath + projectFilePath;
        if (File.Exists(filePath))
        {
            try
            {
                string dataAsJson = File.ReadAllText(filePath);
                stock = JsonUtility.FromJson<Stock>(dataAsJson);
            }
            catch (Exception e)
            {
                Debug.Log("Exception caught" + e);
                stock = new Stock();
            }
        }
        return stock;
    }

    [Serializable]
    public class Stock
    {
        public List<Item> items = new List<Item>();
    }
}
