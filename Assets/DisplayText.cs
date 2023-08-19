using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void SaveNameAndLoadMainScene()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("user_name", playerName);
        PlayerPrefs.Save();
    }
}
