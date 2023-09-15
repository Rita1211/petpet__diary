using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
  public void LoadSceneMain()
  {
    SceneManager.LoadScene("main 1");
  }
   public void LoadSceneCat1()
  {
    SceneManager.LoadScene("main 2");
  }
 /* public void LoadSceneAR()
  {
    SceneManager.LoadScene("SampleScene");
  }*/
}