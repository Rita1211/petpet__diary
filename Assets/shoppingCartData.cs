using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "shoppingCartData", menuName = "ScriptableObjects/shoppingCartData", order = 1)]
public class shoppingCartData : ScriptableObject
{
    public class CartItem
    {
        public string itemName;
        public int quantity;
        public float price;
    }

    public List<CartItem> items = new List<CartItem>();
    public float totalAmount;
}
