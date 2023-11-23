using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ShoppingCart_2 : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemPriceText;
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
        // 檢查是否有保存的購物車信息
        LoadCartFromPlayerPrefs();
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
        SaveCartToPlayerPrefs();
    }

    public void ViewBill()
    {
        // 在這裡切換到帳單場景
        SceneManager.LoadScene("BillScene");
    }

    public void UpdateBillText()
    {
        string bill = "";
        foreach (var item in cart)
        {
            bill += item.Key + " * " + item.Value + "\n";
        }

        // 更新 UI 文本
        if (itemNameText != null)
            itemNameText.text = bill;

        if (itemPriceText != null)
            itemPriceText.text = "$" + totalPrice.ToString("F2");

        // 更新總金額文本
        if (totalPriceText != null)
            totalPriceText.text = "Total: $" + totalPrice.ToString("F2");
    }
}
