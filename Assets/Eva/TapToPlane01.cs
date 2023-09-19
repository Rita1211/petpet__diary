using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlane01 : MonoBehaviour
{
    [Header("要放置的物体列表")]
    public GameObject[] characterObjects; // 不同角色的Prefab

    private ARRaycastManager arRaycast;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 mousePos;
    private int currentCharacterIndex = 0; // 当前要放置的角色索引
    private bool openTap = true;

    private void Start()
    {
        arRaycast = GetComponent<ARRaycastManager>();

        // 获取前一个场景中选择的角色索引
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacterIndex", 0);

        // 根据所选角色索引设置当前要放置的角色
        currentCharacterIndex = selectedCharacterIndex;
    }

    private void Update()
    {
        TapObject();
    }

    private void TapObject()
    {
        if (openTap && Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            if (arRaycast.Raycast(mousePos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits[0].pose;
                GameObject characterObject = characterObjects[currentCharacterIndex];
                // 将角色生成在 AR 平面上
                GameObject temp = Instantiate(characterObject, pose.position, Quaternion.identity);
                // 让生成的角色朝向 AR 相机
                Vector3 cameraPosition = Camera.main.transform.position;
                cameraPosition.y = temp.transform.position.y;
                temp.transform.LookAt(cameraPosition);

                
            }
        }
    }
}
