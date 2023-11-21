using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testCat : MonoBehaviour
{
    // Start is called before the first frame update
    public ToggleGroup[] toggleGroups;
    private int scores = 0;


    public GameObject PassCat_Panel;
    public GameObject FailCat_Panel;
    public Text PassScore_Text;
    public Text FailScoreText;

    private void Start()
    {
        // 检查Toggle Groups是否已分配
        if (toggleGroups == null || toggleGroups.Length == 0)
        {
            Debug.LogError("Toggle Groups are not assigned!");
            return;
        }

        // 初始化每题的分数
        //scores = new int[toggleGroups.Length];

        // 为每个Toggle Group添加监听器
        for (int i = 0; i < toggleGroups.Length; i++)
        {
            ToggleGroup toggleGroup = toggleGroups[i];

            // 获取Toggle Group下的所有Toggle
            Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();

            // 给每个Toggle添加监听器
            foreach (Toggle toggle in toggles)
            {
                toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggleGroup, i, toggle); });
            }
        }
    }

    // 当Toggle的值发生变化时调用的方法
    private void OnToggleValueChanged(ToggleGroup toggleGroup, int questionIndex, Toggle selectedToggle)
    {
        if (selectedToggle.isOn)
        {
            Debug.Log($"Selected Option for Question {questionIndex + 1}: {selectedToggle.gameObject.name}");

            // 在这里处理选择的Toggle
            // 可以根据需要添加逻辑

            // 如果是 toggleGroup(1) 并且选择了 toggle1，则给予10分
            if (toggleGroup == toggleGroups[0] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }

            // 如果是 toggleGroup(2) 并且选择了 toggle2，则再给予10分
            if (toggleGroup == toggleGroups[1] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[2] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[3] && selectedToggle.gameObject.name == "rBtn4")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[4] && selectedToggle.gameObject.name == "rBtn2")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[5] && selectedToggle.gameObject.name == "rBtn4")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[6] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[7] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[8] && selectedToggle.gameObject.name == "rBtn4")
            {
                scores += 10;
            }
            if (toggleGroup == toggleGroups[9] && selectedToggle.gameObject.name == "rBtn3")
            {
                scores += 10;
            }
        }
    }

    // 计算总分
    private int GetTotalScore()
    {
        return scores;

    }


    // 显示Pass和Fail Canvas
    public void CheckAndShowResult()
    {
        if (GetTotalScore() >= 80)
        {
            ShowResultPanel(true); // 显示Pass Canvas
        }
        else
        {
            ShowResultPanel(false); // 显示Fail Canvas
        }
    }
    public void ShowResultPanel(bool pass)
    {

        PassCat_Panel.gameObject.SetActive(pass);
        FailCat_Panel.gameObject.SetActive(!pass);

        if (pass)
        {
            PassScore_Text.text = $"Your Score: {GetTotalScore()}";
        }
        else
        {
            FailScoreText.text = $"Your Score: {GetTotalScore()}";
        }
    }
}
