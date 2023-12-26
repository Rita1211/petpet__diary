using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BillDisplay : MonoBehaviour
{
    public TextMeshProUGUI billText;
    public TextMeshProUGUI itemText;
    public TextMeshProUGUI totalAmountText;
    public ShoppingCartData shoppingCartData;

    void Start()
    {
        DisplayBill();
    }

   void DisplayBill()
{
    foreach (var item in shoppingCartData.items)
    {
        // 使用字串格式化，靠左顯示項目名稱，靠右顯示價格
        string itemLine = $"{item.itemName} * {item.quantity}";
        itemText.text += $"{itemLine}\n";

        string billLine = $"{item.price * item.quantity:C2}";
        billText.text += $"{billLine}\n";
    }

    // 將總金額顯示靠左，並且價格靠右
    string totalAmountLine = $"{shoppingCartData.totalAmount:C2}";
    totalAmountText.text = $"{totalAmountLine}";
}




}
