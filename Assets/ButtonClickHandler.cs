using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public ShopItemButton shopItemButton;
    
    public void OnButtonClick()
    {
        shopItemButton.SelectItem();
    }
}
