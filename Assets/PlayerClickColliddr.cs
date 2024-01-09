using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClickColliddr : MonoBehaviour
{
    public GameObject backpackPanel; // 在Inspector中分配的背包面板

    void Update()
    {
        // 检测屏幕触摸
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 检测触摸开始
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // 射线检测碰撞
                if (Physics.Raycast(ray, out hit))
                {
                    // 检测到tag为"eat"的物体
                    if (hit.collider.CompareTag("eat"))
                    {
                        // 打开背包面板
                        if (backpackPanel != null)
                        {
                            backpackPanel.SetActive(true);
                        }

                        // 阻止角色穿过物体
                        hit.collider.isTrigger = true;
                    }
                }
            }
        }
    }
}
