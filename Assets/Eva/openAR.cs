using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Strat()
    {
        gameObject.SetActive(false);
    }
    public void ClicktoOpen()
    {
        gameObject.SetActive(true);
    }
}
