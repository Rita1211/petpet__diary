using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 對話文本文件 csv格式
    /// </summary>
    public TextAsset dialogDataFile;
    public TMP_Text nameText;
    public TMP_Text dialogText;

    public int dialogIndex;
    public Button nextBTN;
    public GameObject optionBTN;//選項按鈕欲置物
    public Transform buttonGroup;//選像按鈕父節點用於自動排列

    /// <summary>
    /// 對話文本 依行數分割
    /// </summary>
    public string[] dialogRows;

    void Start()
    {
        ReadText(dialogDataFile);
        ShowDialogRow();
        //UpdateText("獸醫","");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(string _name,string _text)
    {
        nameText.text=_name;
        dialogText.text=_text;
    }
    public void ReadText(TextAsset _textAsset)
    {
        dialogRows = _textAsset.text.Split('\n');
        //foreach(var row in rows)
        //{
        //    string[] cell = row.Split(',');
        //}
        Debug.Log("讀取成功");
    }
    public void ShowDialogRow()
    {
        for( int i=0;i<dialogRows.Length;i++)
        {
           string[] cells =dialogRows[i].Split(','); 
           if(cells[0]=="#" && int.Parse(cells[1]) == dialogIndex)
           {
                UpdateText(cells[2],cells[3]);
                dialogIndex=int.Parse(cells[4]);
                break;
           }
           else if (cells[0]=="&" && int.Parse(cells[1]) == dialogIndex)
           {
                nextBTN.gameObject.SetActive(false);
                GenerateOption(i);
           }
        }
        
    }
    public void onClicknextBtn()
    {
        ShowDialogRow();
    }
    public void GenerateOption(int _index)
    {
        string [] cells = dialogRows[_index].Split(',');
        if(cells[0]=="&")
        {
            cells = dialogRows[_index].Split(',');
            if(cells[0]=="&")
            {
                GameObject button =Instantiate(optionBTN,buttonGroup);
                //綁定按鈕事件
                button.GetComponentInChildren<TextMeshPro>().text=cells[3];
                button.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    OnOptionClick(dialogIndex=int.Parse(cells[4]));
                });
                GenerateOption(_index+1);
            }                        
        }        
    }
    public void OnOptionClick(int _id)
    {
        dialogIndex=_id;
        ShowDialogRow();
        for( int i = 0 ;i <buttonGroup.childCount;i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }
}
