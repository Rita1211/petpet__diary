
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEngine.UI;


[RequireComponent(typeof(ARRaycastManager))]
public class TapDogs : MonoBehaviour
{
    [Header("想放置物件")]
    //public GameObject tapObject;
    public GameObject target;
    public AnimalSelection animalSelection;
    
    public GameObject dog1Pref; 
    public GameObject dog2Pref;
    public GameObject dog3Pref;
    public GameObject cat1Pref;
    public GameObject cat2Pref;
    public GameObject cat3Pref;
    public bool opentap;

    
    private ARRaycastManager arRaycast;

    private List<ARRaycastHit> hits=new List<ARRaycastHit>();

    private Vector2 mousePos;



    // Start is called before the first frame update
    private void Start()
    {
        //取得射線管理器元件
        arRaycast = GetComponent<ARRaycastManager>();

        string selectedAnimal = PlayerPrefs.GetString("SelectedAnimal", ""); // Get the selected animal from PlayerPrefs

        // Check the selected animal and set the corresponding image texture
        switch (selectedAnimal)
        {
            case "dog1":
                target=dog1Pref;
                break;
            case "dog2":
                target=dog2Pref;
                break;
            case "dog3":
                target=dog3Pref;
                break;
            case "cat1":
                target=cat1Pref;
                break;
            case "cat2":
                target=cat2Pref;
                break;
            case "cat3":
                target=cat3Pref;
                break;
            default:
                Debug.LogError("Invalid or no selected animal: " + selectedAnimal);
                break;
        }
        opentap=true;
    }


 // Update is called once per frame
    private void Update()
    {
        TapObject();
    }
    
    private void TapObject()
    {
        //判斷是否點擊
        if(opentap&&Input.GetKeyDown(KeyCode.Mouse0))
        {
            //儲存點擊座標
            mousePos = Input.mousePosition;
            //AR射線碰撞
            if(arRaycast.Raycast(mousePos,hits,TrackableType.PlaneWithinPolygon))
            {
                //生成物件在點擊座標
                Pose pose = hits[0].pose;

                GameObject temp=Instantiate(target,pose.position,pose.rotation);
                Vector3 look = transform.position;
                look.y=temp.transform.position.y;
                temp.transform.LookAt(look);
                opentap=false;

            }
            
        }
    }

    
}
