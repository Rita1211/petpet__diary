using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARON_Btn : MonoBehaviour
{
    public GameObject ONtoOff;
    public void Start()
    {
        ONtoOff.SetActive(true);
    }
    public void Click()
    {
        ONtoOff.SetActive(!ONtoOff.activeSelf);
    }
}
