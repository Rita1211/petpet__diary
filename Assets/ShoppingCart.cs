using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShoppingCart : MonoBehaviour
{
    public TextMeshProUGUI billText;
    public TextMeshProUGUI totalPriceText;

    private Dictionary<string, float> cart = new Dictionary<string, float>();
    private float totalPrice = 0;

    private void SaveCartToPlayerPrefs()
    {
        string cartJson = JsonUtility.ToJson(cart);
        PlayerPrefs.SetString("Cart", cartJson);
        PlayerPrefs.SetFloat("TotalPrice", totalPrice);
        PlayerPrefs.Save();
    }

    private void LoadCartFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Cart"))
        {
            string cartJson = PlayerPrefs.GetString("Cart");
            cart = JsonUtility.FromJson<Dictionary<string, float>>(cartJson);
        }

        if (PlayerPrefs.HasKey("TotalPrice"))
        {
            totalPrice = PlayerPrefs.GetFloat("TotalPrice");
        }
    }

    private void Start()
    {
        // 检查是否有保存的购物车信息
        if (PlayerPrefs.HasKey("SelectedShopItem"))
        {
            string itemName = PlayerPrefs.GetString("SelectedShopItem");
            float itemPrice = PlayerPrefs.GetFloat("SelectedShopItemPrice");

            // 添加到购物车
            AddToCart(itemName, itemPrice);
        }

        // 在這裡調用 UpdateBill，以確保在 Start 時也能正確顯示購物清單
        UpdateBill();
    }

    public void AddToCart(string itemName, float price)
    {
        if (cart.ContainsKey(itemName))
        {
            cart[itemName] += 1;
        }
        else
        {
            cart[itemName] = 1;
        }
        totalPrice += price;

        // 更新 PlayerPrefs
        PlayerPrefs.SetString("SelectedShopItem", itemName);
        PlayerPrefs.SetFloat("SelectedShopItemPrice", price);
        PlayerPrefs.Save();

        UpdateBill();
    }

    private void UpdateBill()
    {
        string bill = "";
        foreach (var item in cart)
        {
            bill += item.Key + " * " + item.Value + "\n";
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
}