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
  public void LoadSceneDogKnow()
  {
    SceneManager.LoadScene("knowledge 1");
  }
   public void LoadSceneCat1()
  {
    SceneManager.LoadScene("main 3");//cat1
  }
  public void LoadSceneCat2()
  {
    SceneManager.LoadScene("main 3cat2");
  }
  public void LoadSceneCat3()
  {
    SceneManager.LoadScene("main 3cat3");
  }
  public void LoadSceneDog1()
  {
    SceneManager.LoadScene("mainDog1 1");
  }
  public void LoadSceneDog2()
  {
    SceneManager.LoadScene("mainDog2");
  }
  public void LoadSceneDog3()
  {
    SceneManager.LoadScene("mainDog3");
  }
  public void LoadSceneDog0()
  {
    SceneManager.LoadScene("mainDog");
  }
  public void LoadSceneSound()
  {
    SceneManager.LoadScene("testMain");
  }
 /* public void LoadSceneAR()
  {
    SceneManager.LoadScene("SampleScene");
  }*/
}