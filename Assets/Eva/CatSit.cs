using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CatSit : MonoBehaviour
{
    public int key=0;
    public bool isSit=false;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        key=1;
        m_Animator =GetComponent<Animator>();
        StartCoroutine("Wait");
    }
    public void onClicktoSit(){
        m_Animator.SetBool("toSit",true);
        Wait();

    }
    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            StopSit();
        }
    }
    void StopSit(){
        m_Animator.SetBool("toSit",false);
    }

    // Update is called once per frame
}