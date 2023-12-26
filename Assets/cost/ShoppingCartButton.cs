using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartButton : MonoBehaviour
{
    public string itemName;
    public float itemPrice;

    public void AddItemToCart()
    {
        FindObjectOfType<ShoppingCart>().AddToCart(itemName, itemPrice);
    }
}
