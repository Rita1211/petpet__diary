using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;


public class Photo : MonoBehaviour
{
    public Texture2D[] imageArray;
    public RawImage displayImage;
    public Button prevButton;
    public Button nextButton;
    public Button removeButton;

    
    private int currentImageIndex = 0;

    private void Start()
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
            displayImage.texture = imageArray[0];
        }

    }

    // 這個方法連接到 Button 的 OnClick 事件
    public void ShowLastImage(int index)
    {
        if (imageArray.Length > 0 && index >= 0 && index < imageArray.Length)
        {
            displayImage.texture = imageArray[index];
        }

    }
    public void ShowPreviousImage()
    {
        currentImageIndex = Mathf.Clamp(currentImageIndex - 1, 0, imageArray.Length - 1);
        ShowLastImage(currentImageIndex);
    }
    public void ShowNextImage()
    {
        currentImageIndex = Mathf.Clamp(currentImageIndex + 1, 0, imageArray.Length - 1);
        ShowLastImage(currentImageIndex);
    }

    public void RemoveCurrentImage()
    {
        // 設定要讀取的資料夾路徑
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // 修改為你的圖片資料夾路徑

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // 修改檔案類型或副檔名

        if (imageArray.Length > 0 && currentImageIndex >= 0 && currentImageIndex < imageArray.Length)
        {

            // 取得要刪除的圖片的路徑
            string imagePathToDelete = Path.Combine("/sdcard/DCIM/PetpetDiaryPhoto", Path.GetFileName(imagePaths[currentImageIndex]));
          
            // 刪除圖片
            File.Delete(imagePathToDelete);
            
            // 移除圖片
            Texture2D removedTexture = imageArray[currentImageIndex];
            imageArray = imageArray.Where((texture, index) => index != currentImageIndex).ToArray();
            Destroy(removedTexture);

            // 更新顯示
            if (imageArray.Length > 0)
            {
                currentImageIndex = Mathf.Clamp(currentImageIndex, 0, imageArray.Length - 1);
                ShowLastImage(currentImageIndex);
            }
            else
            {
                displayImage.texture = null;
            }
        }
    }
}
