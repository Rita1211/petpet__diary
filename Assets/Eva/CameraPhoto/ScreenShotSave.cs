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
            displayImage.texture = imageArray[imageArray.Length - 1];
        }

    }
    public void RemoveCurrentImage()
    {
        // �]�w�nŪ������Ƨ����|
        string folderPath = "/sdcard/DCIM/PetpetDiaryPhoto"; // �קאּ�A���Ϥ���Ƨ����|

        string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // �ק��ɮ������ΰ��ɦW
       
        if (imageArray.Length > 0 && currentImageIndex >= 0 && currentImageIndex < imageArray.Length)
        {
            currentImageIndex =  imageArray.Length - 1;
            // ���o�n�R�����Ϥ������|
            string imagePathToDelete = Path.Combine("/sdcard/DCIM/PetpetDiaryPhoto", Path.GetFileName(imagePaths[currentImageIndex]));

            // �R���Ϥ�
            File.Delete(imagePathToDelete);

            // ��s���
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