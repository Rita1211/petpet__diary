using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonTest : MonoBehaviour
{
    /// <summary>
    /// 定义一个Button组件
    /// </summary>
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        //获取Button组件
        btn = gameObject.GetComponent<Button>();
        //绑定按钮点击事件
        btn.onClick.AddListener(BtnClick);
    }

    /// <summary>
    /// 按钮点击事件的方法
    /// </summary>
    public void BtnClick()
    {
        print("我点击了按钮");
    }
}
