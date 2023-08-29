using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimalNaming : MonoBehaviour
{
    
    
    public AnimalSelection animalSelection;

    

    public void OnConfirmNaming()
    {
        // Save the name and proceed to the main screen
        SceneManager.LoadScene("main");
    }
}
