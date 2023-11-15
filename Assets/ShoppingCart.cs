using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShoppingCart : MonoBehaviour
{
    public TextMeshProUGUI billText;
    public TextMeshProUGUI totalPriceText;

    private Dictionary<string, int> cart = new Dictionary<string, int>();
    private float totalPrice = 0;

    public void AddToCart(string itemName, float price)
    {
        if(cart.ContainsKey(itemName))
        {
            cart[itemName] += 1;
        }
        else
        {
            cart[itemName] = 1;
        }
        totalPrice += price;
        UpdateBill();
    }

    private void UpdateBill()
    {
        string bill ="";
        foreach (var item in cart)
        {
            bill += item.Key+ " * " + item.Value + "\n";

        }

        // 添加 Debug.Log 語句
    Debug.Log("billText: " + (billText != null ? billText.text : "null"));
    Debug.Log("totalPriceText: " + (totalPriceText != null ? totalPriceText.text : "null"));
        // 添加空值檢查
    if (billText != null)
        billText.text = bill;

    // 添加空值檢查
    if (totalPriceText != null)
        totalPriceText.text = "$" + totalPrice.ToString("F2");
    }

    private void Awake()
{
    // 確保這兩個 Text 對象在運行時已經被初始化
    if (billText == null)
        billText = GetComponent<TextMeshProUGUI>();

    if (totalPriceText == null)
        totalPriceText = GetComponent<TextMeshProUGUI>();
}
}
