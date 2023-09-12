using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodChange : MonoBehaviour
{
    [SerializeField] RectTransform blood;
    public float hp,maxHp;
    float oriW,oriH;

    


    // Start is called before the first frame update
    void Start()
    {
        oriW=blood.sizeDelta.x;
        oriH=blood.sizeDelta.y;
        blood.sizeDelta=new Vector2(150/maxHp*hp,oriH);
    }
    void countHp(){
        blood.sizeDelta=new Vector2(oriW/maxHp*hp,oriH);
        //blood.sizeDelta=new Vector2(100/maxHp*hp,oriH);
    }
    public void add(){
        if (hp>=maxHp){
            hp=maxHp;
        }else{
            hp+=50;
        }
        countHp();
    }
    public void errFood() {
        if (hp>=maxHp){
            hp=maxHp;
        }else{
            hp+=25;
        }
        countHp();
    } 
    

   
}
