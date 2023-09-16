using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PetMove : MonoBehaviour
{
    public float MoveSpeed =1.0f;
    public float RotateSpeed =30.0f;

    public int key=0;
    public bool temp =true;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        key=1;
        m_Animator =GetComponent<Animator>();
        StartCoroutine("Wait");
    }

    // Update is called once per frame
    void Update()
    {
        if(temp==false)
        {
            return;
        }

        switch(key)
        {
            case 1:
                transform.Translate(0,0,1*MoveSpeed*Time.deltaTime,Space.Self);
                transform.Rotate(0,1*RotateSpeed*Time.deltaTime,0,Space.Self);
                break;
            case 2:
                transform.Translate(0,0,0.5f*MoveSpeed*Time.deltaTime,Space.Self);
                transform.Rotate(0,0.5f*RotateSpeed*Time.deltaTime,0,Space.Self);
                break;
            case 3:
                //transform.Translate(0,0,1*MoveSpeed*Time.deltaTime,Space.Self);
                //transform.Rotate(0,1*RotateSpeed*Time.deltaTime,0,Space.Self);
                m_Animator.SetBool("idle",true);
                Wait();
                m_Animator.SetBool("idle",false);
                break;
            case 4:
                m_Animator.SetBool("idle",false);
                m_Animator.SetBool("ToSit",true);
                //transform.Translate(0,0,1*MoveSpeed*Time.deltaTime,Space.Self);
                //transform.Rotate(0,1*RotateSpeed*Time.deltaTime,0,Space.Self);
                break;

        }

    }
    IEnumerator Wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            Timer();
        }
    }

    void Timer()
    {
        //random 1~3
        int i = Random.Range(0,4);
        //walk 2/3 sit 1/3
        if(i>1)
        {
            temp=true;
            m_Animator.SetBool("idle",false);
            //transform.Rotate(0,180,0,Space.Self);
            return;
        }
        else
        {
            temp=false;
            //cat is walk
            m_Animator.SetBool("idle",true);
        }
        //換一種走路方式
        key++;
        if(key ==4){
            key=1;
        }
    }
}
