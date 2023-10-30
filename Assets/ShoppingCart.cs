using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShoppingCart : MonoBehaviour
{
    public TMP_Text billText;
    public TMP_Text totalPriceText;

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
            cart[itemName] += 1;
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
        billText.text = bill;
        totalPriceText.text = "$"+ totalPrice.ToString("F2");
    }
}
