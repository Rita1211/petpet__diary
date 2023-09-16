
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;


[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlane : MonoBehaviour
{
    [Header("想放置物件")]
    public GameObject tapObject;

    
    private ARRaycastManager arRaycast;

    private List<ARRaycastHit> hits=new List<ARRaycastHit>();

    private Vector2 mousePos;
    public bool openTap;



    // Start is called before the first frame update
    private void Start()
    {
        //取得射線管理器元件
        arRaycast = GetComponent<ARRaycastManager>();
        openTap=true;
    }


 // Update is called once per frame
    private void Update()
    {
        TapObject();
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
