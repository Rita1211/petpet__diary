using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class camara2 : MonoBehaviour
{
    [Header("檔案名稱")]
    public string FileName;
    int FileNumber;
    [Header("APP上的UI")]
    public GameObject[] UIs;
    public Texture2D[] imageArray;

    public void CapturePhoto()
    {
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(false);
        }
        // 等待下一帧再进行截图操作
        StartCoroutine(CaptureWithDelay());
    }

    IEnumerator CaptureWithDelay()
    {
        yield return new WaitForEndOfFrame();

        

        string timestamp = System.DateTime.Now.ToString("yyyyMMddHHmmss");
        FileName = "IThomeAR" + timestamp + ".png";
        
        // string filePath = Path.Combine("../../../../", FileName);
        // 截取屏幕
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        //轉為字節數组
        byte[] bytes = texture.EncodeToPNG();

        string destination = "/sdcard/DCIM/PetpetDiaryPhoto";
        //判斷目錄是否存在，不存在則會創建目錄
        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }
        else
        {
            string Path_save = destination + "/" + FileName;
            //存圖片
            System.IO.File.WriteAllBytes(Path_save, bytes);
        }
        // ScreenCapture.CaptureScreenshot("../../../../"+FileName);
        Invoke("openUI", 1);
    }

    void openUI()
    {
        for (int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(true);
        }
    }
    void CreateImage()
    {
        GameObject go = GameObject.Find("Canvas/Screenimage").gameObject;//先?建一?空物体
        GameObject Im = new GameObject();
        Im.name = "jieping";
        Im.transform.SetParent(go.transform, false);
        Im.AddComponent<Image>();//添加Image?性
        Im.GetComponent<Image>().sprite = Resources.Load<Sprite>("ScreenShot/screenshot");
        Im.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        Vector2 v2 = new Vector2((float)(113.8 * 7), (float)(64.2 * 7));
    }
}
