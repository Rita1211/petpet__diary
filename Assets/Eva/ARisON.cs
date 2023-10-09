using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARisON : MonoBehaviour
{
    // Start is called before the first frame update
    void Strat()
    {
        gameObject.SetActive(true);
    }
    public void Click()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}