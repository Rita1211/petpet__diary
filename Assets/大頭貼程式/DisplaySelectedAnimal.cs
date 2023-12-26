using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedAnimal : MonoBehaviour
{
    public RawImage animalImage;
    public AnimalSelection animalSelection;
    
    public Texture2D dog1Image; // Assign the image textures in the Inspector
    public Texture2D dog2Image;
    public Texture2D dog3Image;
    public Texture2D cat1Image;
    public Texture2D cat2Image;
    public Texture2D cat3Image;
    public bool CatorDog=true;



    private void Start()
    {
         string selectedAnimal = PlayerPrefs.GetString("SelectedAnimal", ""); // Get the selected animal from PlayerPrefs

        // Check the selected animal and set the corresponding image texture
        switch (selectedAnimal)
        {
            case "dog1":
                animalImage.texture = dog1Image;
                CatorDog=false;
                break;
            case "dog2":
                animalImage.texture = dog2Image;
                CatorDog=false;
                break;
            case "dog3":
                animalImage.texture = dog3Image;
                CatorDog=false;
                break;
            case "cat1":
                animalImage.texture = cat1Image;
                CatorDog=true;
                break;
            case "cat2":
                animalImage.texture = cat2Image;
                CatorDog=true;
                break;
            case "cat3":
                animalImage.texture = cat3Image;
                CatorDog=true;
                break;
            default:
                Debug.LogError("Invalid or no selected animal: " + selectedAnimal);
                break;
        }
    }   
}
