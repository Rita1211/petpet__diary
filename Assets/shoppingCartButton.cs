using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoppingCartButton : MonoBehaviour
{
    public string itemName;
    public float itemPrice;

    public void AddItemToCart()
    {
        FindObjectOfType<shoppingCart>().AddToCart(itemName, itemPrice);
    }
}
