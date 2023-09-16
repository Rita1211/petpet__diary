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
        // �]�w�nŪ������Ƨ����|
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // �קאּ�A���Ϥ���Ƨ����|

        // Ū����Ƨ������Ҧ��Ϥ��ɮ�
        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // �ק��ɮ������ΰ��ɦW

        // ��l�ƹϤ��}�C
        imageArray = new Texture2D[imagePaths.Length];

        for (int i = 0; i < imagePaths.Length; i++)
        {
            byte[] imageData = File.ReadAllBytes(imagePaths[i]);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);
            imageArray[i] = texture;
        }
        // �N�̫�@�i�Ϥ���ܦb RawImage �W
        if (imageArray.Length > 0)
        {
            displayImage.texture = imageArray[0];
        }

    }

    // �o�Ӥ�k�s���� Button �� OnClick �ƥ�
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
        // �]�w�nŪ������Ƨ����|
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // �קאּ�A���Ϥ���Ƨ����|

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // �ק��ɮ������ΰ��ɦW

        if (imageArray.Length > 0 && currentImageIndex >= 0 && currentImageIndex < imageArray.Length)
        {

            // ���o�n�R�����Ϥ������|
            string imagePathToDelete = Path.Combine("/sdcard/DCIM/PetpetDiaryPhoto", Path.GetFileName(imagePaths[currentImageIndex]));
          
            // �R���Ϥ�
            File.Delete(imagePathToDelete);
            
            // �����Ϥ�
            Texture2D removedTexture = imageArray[currentImageIndex];
            imageArray = imageArray.Where((texture, index) => index != currentImageIndex).ToArray();
            Destroy(removedTexture);

            // ��s���
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
