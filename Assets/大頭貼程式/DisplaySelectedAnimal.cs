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

    private void Start()
    {
        if (animalSelection.selectedAnimal == "dog1")
        {
            animalImage.texture = dog1Image;
        }
        else if (animalSelection.selectedAnimal == "dog2")
        {
            animalImage.texture = dog2Image;
        }
    }   
}
