using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchChoice()
    {
        SceneManager.LoadScene(3);
    }

    public void SwitchIntro1()
    {
        SceneManager.LoadScene(4);
    }

    public void SwitchSelect1()
    {
        SceneManager.LoadScene(10);
    }

    public void SwitchIntro2()
    {
        SceneManager.LoadScene(5);
    }

    public void SwitchSelect2()
    {
        SceneManager.LoadScene(11);
    }

    public void SwitchIntro3()
    {
        SceneManager.LoadScene(6);
    }

    public void SwitchSelect3()
    {
        SceneManager.LoadScene(12);
    }

    public void SwitchIntro4()
    {
        SceneManager.LoadScene(7);
    }

    public void SwitchSelect4()
    {
        SceneManager.LoadScene(13);
    }

    public void SwitchIntro5()
    {
        SceneManager.LoadScene(8);
    }

    public void SwitchSelect5()
    {
        SceneManager.LoadScene(14);
    }

    public void SwitchIntro6()
    {
        SceneManager.LoadScene(9);
    }

    public void SwitchSelect6()
    {
        SceneManager.LoadScene(15);
    }

    public void SwitchMain()
    {
        SceneManager.LoadScene("main");
    }

    public void Switchsignup_login()
    {
        SceneManager.LoadScene("signup&login");
    }

    public void Switch0()
    {
        SceneManager.LoadScene("0");
    }

    public void Switchknowledge()
    {
        SceneManager.LoadScene("knowledge");
    }

    public void Switchdog1()
    {
        SceneManager.LoadScene("dog1");
    }

    public void Switchdog2()
    {
        SceneManager.LoadScene("dog2");
    }

    public void Switchdog3()
    {
        SceneManager.LoadScene("dog3");
    }

    public void Switchdog4()
    {
        SceneManager.LoadScene("dog4");
    }

    public void Switchcat1()
    {
        SceneManager.LoadScene("cat1");
    }

    public void Switchcat2()
    {
        SceneManager.LoadScene("cat2");
    }

    public void Switchcat3()
    {
        SceneManager.LoadScene("cat3");
    }

    public void Switchcat4()
    {
        SceneManager.LoadScene("cat4");
    }

    public void Switchcat5()
    {
        SceneManager.LoadScene("cat5");
    }

    public void Switchbag()
    {
        SceneManager.LoadScene("bag");
    }

    public void Switchcamera()
    {
        SceneManager.LoadScene("camera");
    }

    public void Switchsetting()
    {
        SceneManager.LoadScene("setting");
    }

    public void Switchphoto()
    {
        SceneManager.LoadScene("photo");
    }


}
