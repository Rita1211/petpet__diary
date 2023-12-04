using UnityEngine;


public class shoppingCart : MonoBehaviour
{
    public shoppingCartData shoppingCartData;

    public void AddToCart(string itemName, float price)
    {
        shoppingCartData.CartItem existingItem = shoppingCartData.items.Find(item => item.itemName == itemName);

        if (existingItem != null)
        {
            existingItem.quantity++;
        }
        else
        {
            shoppingCartData.CartItem newItem = new shoppingCartData.CartItem
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
