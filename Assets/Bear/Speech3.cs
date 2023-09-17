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

    private bool isListening = false; // 追蹤語音辨識狀態
    private float listeningDuration = 5f; // 語音辨識時間限制

    private void Start()
    {
        actions.Add("貓貓", CallOut);
        actions.Add("疑惑", Confuse);
        actions.Add("坐下", Sit);
        actions.Add("跳", Jump);
//        actions.Add("摸摸", Caress);

        SpeakBtn.onClick.AddListener(StartListening);

        // 創建KeywordRecognizer，但不要立即開始
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
    }

    public void StartListening()
    {
        if (!isListening)
        {
            keywordRecognizer.Start();
            isListening = true;

            // 啟動協程，用於停止語音辨識
            StartCoroutine(StopListeningAfterDuration());
        }
    }

    private IEnumerator StopListeningAfterDuration()
    {
        yield return new WaitForSeconds(listeningDuration);

        // 5秒後停止語音辨識
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

        // 檢查語音文字是否在 actions 字典中
        if (actions.ContainsKey(speech.text))
        {
            actions[speech.text].Invoke();
        }
        else
        {
            Debug.Log("無法識別的語音: " + speech.text);
            // 執行 "疑惑" 動畫
            Confuse();
        }

        // 辨識完畢後停止語音辨識
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

        // 動畫完成後，返回站立狀態
        StartCoroutine(ReturnToStand());
    }

    // 協程用於返回站立狀態
    private IEnumerator ReturnToStand()
    {
        yield return new WaitForSeconds(1f); // 停留一秒以觀察動畫

        // 返回站立狀態
        kittyAnimator.SetBool("isWalking", false);
        kittyAnimator.SetBool("isJumping", false);
        kittyAnimator.SetBool("isSitting", false);
        kittyAnimator.SetBool("isStanding", true);
    }
}
