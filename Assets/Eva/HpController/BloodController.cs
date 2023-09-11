using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
    [SerializeField] RectTransform blood;
    public float hp,maxHp;
    float oriW,oriH;

    


    // Start is called before the first frame update
    void Start()
    {
        oriW=blood.sizeDelta.x;
        oriH=blood.sizeDelta.y;
        hp=40;
        oriW=40;
       
    }
    void countHp(){
        //blood.sizeDelta=new Vector2(oriW/maxHp*hp,oriH);
        blood.sizeDelta=new Vector2(100/maxHp*hp,oriH);
    }
    public void add01(){
        if (hp>=maxHp){
            hp=100;
        }else{
            hp+=20;
        }
        countHp();
    }
    public void minus01() {
        if (hp<=0){
            hp=0;
        }else{
            hp-=20;
        }
        countHp();
    } 

   
}
