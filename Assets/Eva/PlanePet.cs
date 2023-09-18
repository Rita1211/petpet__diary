
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;


[RequireComponent(typeof(ARRaycastManager))]
public class PlanePet : MonoBehaviour
{
    [Header("想放置物件")]
    public GameObject tapObject;
    public GameObject Pet1_cat1;
    public GameObject Pet2_cat2;
    public GameObject Pet3_cat3;

    
    private ARRaycastManager arRaycast;

    private List<ARRaycastHit> hits=new List<ARRaycastHit>();

    private Vector2 mousePos;
    public bool openTap;



    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);//預設關閉AR相機

        //取得射線管理器元件
        arRaycast = GetComponent<ARRaycastManager>();
        openTap=true;
        
    }
    public void ClicktoOpen(){
        gameObject.SetActive(true);
    }


 // Update is called once per frame
    private void Update()
    {
        TapObject();
    }
    public void ClicktoCat2(){
        tapObject=Pet2_cat2;
    }
    public void ClicktoCat3(){
        tapObject=Pet3_cat3;
    }
    private void TapObject()
    {
        if (openTap)
        {
        //判斷是否點擊
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                //儲存點擊座標
                mousePos = Input.mousePosition;
                //AR射線碰撞
                if(arRaycast.Raycast(mousePos,hits,TrackableType.PlaneWithinPolygon))
                {
                    //生成物件在點擊座標
                    Pose pose = hits[0].pose;
                    GameObject temp=Instantiate(tapObject,pose.position,pose.rotation);
                    Vector3 look = transform.position;
                    look.y=temp.transform.position.y;
                    temp.transform.LookAt(look);
                    openTap=false;
                }
                
                openTap=false;
                
            }
        }
        
    }

    
}
