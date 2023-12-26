using UnityEngine;


public class ShoppingCart : MonoBehaviour
{
    public ShoppingCartData shoppingCartData;

    public void AddToCart(string itemName, float price)
    {
        ShoppingCartData.CartItem existingItem = shoppingCartData.items.Find(item => item.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.quantity++;
        }
        else
        {
            ShoppingCartData.CartItem newItem = new ShoppingCartData.CartItem
            {
                itemName = itemName,
                quantity = 1,
                price = price
            };

            shoppingCartData.items.Add(newItem);
        }

        shoppingCartData.totalAmount += price;
    }
}
