using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
   public string itemName ;
   public float itemPrice;

   public ShoppingCart ShoppingCart;
   
   public void SelectItem()
   {
        ShoppingCart.AddToCart(itemName, itemPrice);
   }
}
