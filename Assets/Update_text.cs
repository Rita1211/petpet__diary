using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Update_text : MonoBehaviour
{
    private TextMeshProUGUI obj_text;

    // Start is called before the first frame update
    void Start()
    {
        obj_text = GameObject.FindGameObjectWithTag("text").GetComponent<TextMeshProUGUI>();
        
        if (obj_text != null)
        {
            obj_text.text = PlayerPrefs.GetString("user_name");
        }
        else
        {
            Debug.LogWarning("obj_text is null.");
        }
    }
}
