using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalSelection : MonoBehaviour
{
    public string selectedAnimal;

    public void OnSelectAnimalButtonClicked(string animalName)
    {
        PlayerPrefs.SetString("SelectedAnimal", animalName);
        selectedAnimal = animalName;
        Debug.Log("Selected Animal: " + animalName); 
        
    }
}
