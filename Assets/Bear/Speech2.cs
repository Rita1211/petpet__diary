using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.Windows;
using UnityEngine.UI;

public class Speech2 : MonoBehaviour
{
    [SerializeField] private Button SpeakBtn;

    [SerializeField] private Animator kittyAnimator;

    [SerializeField] private AudioSource kittySource;
    [SerializeField] private AudioClip meowSound;
    [SerializeField] private AudioClip purrrSound;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private void Start()
    {
        actions.Add("�߿�", CallOut);
        actions.Add("�ôb", Confuse);
        actions.Add("���U", Sit);
        actions.Add("��", Jump);
        actions.Add("�N�N", Caress);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }


    private void CallOut()
    {
        kittySource.PlayOneShot(meowSound);
        kittyAnimator.SetBool("isCallingOut", true);
    }

    private void Confuse()
    {
        kittyAnimator.SetBool("isConfuse", true);
    }

    private void Sit()
    {
        kittyAnimator.SetBool("isSitting", true);
    }

    private void Jump()
    {
        kittyAnimator.SetBool("isJumping", true);
    }

    private void Caress()
    {
        kittySource.PlayOneShot(purrrSound);
    }
}
