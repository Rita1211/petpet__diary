using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemButton : MonoBehaviour
{
   public string itemName ;
   public float itemPrice;

  
   
   public void SelectItem()
   {
       
        //ShoppingCart.AddToCart(itemName, itemPrice);
        // 儲存所選項目和價格
    PlayerPrefs.SetString("SelectedShopItem", itemName);
        PlayerPrefs.SetFloat("SelectedShopItemPrice", itemPrice);
    
   }
}
