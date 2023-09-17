using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARisON : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BGpanel;
    void Strat()
    {
        BGpanel.SetActive(false);
    }
    public void Click()
    {
        BGpanel.SetActive(!BGpanel.activeSelf);
    }
}