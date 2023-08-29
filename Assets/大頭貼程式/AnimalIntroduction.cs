using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalIntroduction : MonoBehaviour
{
   
    public AnimalSelection animalSelection;

    

    public void OnConfirmIntroduction()
    {
       SceneManager.LoadScene("select1");
    }
}
