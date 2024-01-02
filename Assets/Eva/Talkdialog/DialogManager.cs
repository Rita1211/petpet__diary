using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogManager : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// 對話文本文件 csv格式
    /// </summary>
    public TextAsset dialogDataFile;
    public TextAsset dialogDataFile_dog;
    public AnimalSelection animalSelection;
    public TMP_Text nameText;
    public TMP_Text dialogText;

    public int dialogIndex;
    public Button nextBTN;
    public GameObject optionBTN;//選項按鈕欲置物
    public Transform buttonGroup;//選像按鈕父節點用於自動排列
    public GameObject ch1;
    public GameObject ch2;
    public GameObject ch3;
    public GameObject ch4;

    /// <summary>
    /// 對話文本 依行數分割
    /// </summary>
    public string[] dialogRows;
    

    void Start()
    {
       bool _catOrdog =CatorDog();
        if (_catOrdog==true){
            ReadText(dialogDataFile);
        }else{
            ReadText(dialogDataFile_dog);
        }
        //ReadText(dialogDataFile);
        ShowDialogRow();
        //UpdateText("獸醫","");
        ch1.gameObject.SetActive(false);
        ch2.gameObject.SetActive(false);
        ch3.gameObject.SetActive(false);
        ch4.gameObject.SetActive(false);
        
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
    public void UpdateImage(string _name,string _position)
    {
        if(_position=="左")//淺
        {
            //對話框底為獸醫白底
        }
        else if (_position=="右")//深
        {
            //對話框底為深色底 自己 並出現選項
        }
    }
     bool CatorDog ()
    {
        string selectedAnimal = PlayerPrefs.GetString("SelectedAnimal", ""); 

        bool rlt=true;
        switch (selectedAnimal)
        {           
            case "dog1":
                rlt=false;
                break;
            case "dog2":
                rlt=false;
                break;
            case "dog3":
                rlt=false;
                break;
            case "cat1":
                rlt=true;
                break;
            case "cat2":
                rlt=true;
                break;
            case "cat3":
                rlt=true;
                break;
            default:
                Debug.LogError("Invalid or no selected animal: " + selectedAnimal);
                break;
            
        }
        return rlt;
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
                UpdateText(cells[2],cells[3]);//name人物,說話內容
                //UpdateImage(cells[2],cell[??]);//人物,淺深
                dialogIndex=int.Parse(cells[4]);//跳轉
                nextBTN.gameObject.SetActive(true);
                break;
           }
           else if (cells[0]=="&" && int.Parse(cells[1]) == dialogIndex)
           {
                nextBTN.gameObject.SetActive(false);//繼續按鈕消失
                GenerateOption(i);
           }
           else if (cells[0]=="END" && int.Parse(cells[1]) == dialogIndex)
           {
                Debug.Log("劇情結束");
                //頁面跳轉
                SceneManager.LoadScene("mainCat2");
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
                GameObject button =Instantiate(optionBTN,buttonGroup);//生成按鈕在Buttongroup裡
                //綁定按鈕事件
                button.GetComponentInChildren<TMP_Text>().text=cells[3];//選項裡的內容
                button.GetComponent<Button>().onClick.AddListener(//添加Onclik事件
                delegate//委託
                {
                    OnOptionClick(dialogIndex=int.Parse(cells[4]));//影片cell[5]跳轉
                    if (cells[5]!="")//效果
                    {
                        Debug.Log("添加按鈕附加效果");
                        string  effect = cells[5];
                        OptionEffect(effect);
                    }
                });
                GenerateOption(_index+1);
            }                        
        }        
    }
    public void OnOptionClick(int _id)//選項按鈕的點擊事件
    {
        dialogIndex=_id;
        ShowDialogRow();
        //點擊後銷毀
        for( int i = 0 ;i <buttonGroup.childCount;i++)
        {
            Destroy(buttonGroup.GetChild(i).gameObject);
        }
    }

    public void OptionEffect(string _effect)
    {
        if (_effect=="基礎健檢完成")
        {
            ch1.gameObject.SetActive(true);
        }
        else if (_effect =="植入晶片完成")
        {
            ch2.gameObject.SetActive(true);
        }
        else if (_effect =="打預防針完成")
        {
            ch3.gameObject.SetActive(true);
        }
        else if (_effect =="結紮完成")
        {
            ch4.gameObject.SetActive(true);
        }
        
    }
}
