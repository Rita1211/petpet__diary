using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class Speech3 : MonoBehaviour
{
    [SerializeField] private Button SpeakBtn;

    [SerializeField] private Animator kittyAnimator;

    [SerializeField] private AudioSource kittySource;
    [SerializeField] private AudioClip meowSound;
    [SerializeField] private AudioClip purrrSound;
    [SerializeField] private AudioClip hisssSound;
    [SerializeField] private AudioClip LookAtMeSound;
    [SerializeField] private AudioClip PooPooSounds;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    private bool isListening = false; // �l�ܻy�����Ѫ��A
    private float listeningDuration = 5f; // �y�����Ѯɶ�����

    private void Start()
    {
        actions.Add("�߿�", CallOut);
        actions.Add("�ôb", Confuse);
        actions.Add("���U", Sit);
        actions.Add("��", Jump);
//        actions.Add("�N�N", Caress);

        SpeakBtn.onClick.AddListener(StartListening);

        // �Ы�KeywordRecognizer�A�����n�ߧY�}�l
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
    }

    public void StartListening()
    {
        if (!isListening)
        {
            keywordRecognizer.Start();
            isListening = true;

            // �Ұʨ�{�A�Ω󰱤�y������
            StartCoroutine(StopListeningAfterDuration());
        }
    }

    private IEnumerator StopListeningAfterDuration()
    {
        yield return new WaitForSeconds(listeningDuration);

        // 5��ᰱ��y������
        StopListening();
    }

    private void StopListening()
    {
        if (isListening)
        {
            keywordRecognizer.Stop();
            isListening = false;
        }
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();

        // �ˬd�y����r�O�_�b actions �r�夤
        if (actions.ContainsKey(speech.text))
        {
            actions[speech.text].Invoke();
        }
        else
        {
            Debug.Log("�L�k�ѧO���y��: " + speech.text);
            // ���� "�ôb" �ʵe
            Confuse();
        }

        // ���ѧ����ᰱ��y������
        StopListening();
    }

    private void CallOut()
    {
        kittySource.PlayOneShot(meowSound);
        kittyAnimator.SetBool("isWalking", true);
        kittyAnimator.SetBool("isStanding", false);
        StartCoroutine(ReturnToStand());
    }

    private void Confuse()
    {
        kittyAnimator.SetBool("isTilting", true);
        kittyAnimator.SetBool("isSitting", false);
        StartCoroutine(ReturnToStand());
    }

    private void Sit()
    {
        kittyAnimator.SetBool("isSitting", true);
        kittyAnimator.SetBool("isStanding", false);
        StartCoroutine(ReturnToStand());
    }

    private void Jump()
    {
        kittyAnimator.SetBool("isJumping", true);
        kittyAnimator.SetBool("isStanding", false);

        // �ʵe������A��^���ߪ��A
        StartCoroutine(ReturnToStand());
    }

    // ��{�Ω��^���ߪ��A
    private IEnumerator ReturnToStand()
    {
        yield return new WaitForSeconds(1f); // ���d�@��H�[��ʵe

        // ��^���ߪ��A
        kittyAnimator.SetBool("isWalking", false);
        kittyAnimator.SetBool("isJumping", false);
        kittyAnimator.SetBool("isSitting", false);
        kittyAnimator.SetBool("isStanding", true);
    }
}
