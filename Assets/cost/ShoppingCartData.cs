using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ShoppingCartData", menuName = "ScriptableObjects/ShoppingCartData", order = 1)]
public class ShoppingCartData : ScriptableObject
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
