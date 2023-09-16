using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ScreenShotSave : MonoBehaviour
{
    public Texture2D[] imageArray;
    public RawImage displayImage;
    public Button removeButton;

    private int currentImageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 設定要讀取的資料夾路徑
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // 修改為你的圖片資料夾路徑
        // 讀取資料夾中的所有圖片檔案
        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // 修改檔案類型或副檔名

        // 初始化圖片陣列
        imageArray = new Texture2D[imagePaths.Length];

        for (int i = 0; i < imagePaths.Length; i++)
        {
            byte[] imageData = File.ReadAllBytes(imagePaths[i]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);
            imageArray[i] = texture;
        }
        // 將最後一張圖片顯示在 RawImage 上
        if (imageArray.Length > 0)
        {
            displayImage.texture = imageArray[imageArray.Length - 1];
        }

    }
    public void RemoveCurrentImage()
    {
        // 設定要讀取的資料夾路徑
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // 修改為你的圖片資料夾路徑

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // 修改檔案類型或副檔名
       
        if (imageArray.Length > 0 && currentImageIndex >= 0 && currentImageIndex < imageArray.Length)
        {
            currentImageIndex =  imageArray.Length - 1;
            // 取得要刪除的圖片的路徑
            string imagePathToDelete = Path.Combine("/sdcard/DCIM/PetpetDiaryPhoto", Path.GetFileName(imagePaths[currentImageIndex]));

            // 刪除圖片
            File.Delete(imagePathToDelete);

            // 更新顯示
            if (imageArray.Length > 0)
            {
                displayImage.texture = imageArray[imageArray.Length - 1];
            }
            else
            {
                displayImage.texture = null;
            }
        }
    }
}