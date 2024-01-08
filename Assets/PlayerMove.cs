using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public GameObject model;
    private bool moveState = false;
    private Vector3 target = new Vector3();
    public float speed = 1;

    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            // 浪代牟北秨﹍Beganㄆン
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPositionV3 = new Vector3(touch.position.x, touch.position.y, 293f);
                Debug.Log("牟北竚V2" + touch.position);
                Debug.Log("牟北竚V3: " + touchPositionV3);
                Ray ray = Camera.main.ScreenPointToRay(touchPositionV3);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "floor")
                    {
                        moveState = true;
                        target = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    }
                }
            }
        }

        if (moveState)
        {
            float step = speed * Time.deltaTime;
            Vector3 targetDir = target - model.transform.position;
            Vector3 newDir = Vector3.RotateTowards(model.transform.forward, targetDir, step * 10, 0.0F);
            model.transform.rotation = Quaternion.LookRotation(newDir);

            if (Vector3.Distance(model.transform.position, target) < 0.1f)
            {
                moveState = false;
            }

            model.transform.position = Vector3.MoveTowards(model.transform.position, target, step);
        }
    }
}




