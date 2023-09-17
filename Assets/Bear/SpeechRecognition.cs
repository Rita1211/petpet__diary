using System.IO;
using HuggingFace.API;
using UnityEngine;
using UnityEngine.UI;

public class SpeechRecognition : MonoBehaviour
{
    [SerializeField] private Button startStopButton;
    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource kittySource;
    [SerializeField] private AudioClip meowSound;
    [SerializeField] private AudioClip purrrSound;
    [SerializeField] private AudioClip hisssSound;
    [SerializeField] private AudioClip LookAtMeSound;
    [SerializeField] private AudioClip PooPooSounds;

    private AudioClip clip;
    private byte[] bytes;
    private bool recording;

    private void Start()
    {
        startStopButton.onClick.AddListener(ToggleRecording);
    }

    private void Update()
    {
        if (recording && Microphone.GetPosition(null) >= clip.samples)
        {
            ToggleRecording();
        }
    }

    public void ToggleRecording()
    {
        if (!recording)
        {
            StartRecording();
        }
        else
        {
            StopRecording();
        }
    }

    private void StartRecording()
    {
        startStopButton.interactable = false;
        clip = Microphone.Start(null, false, 10, 44100);
        recording = true;
    }

    private void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        if (position < 0 || position >= clip.samples)
        {
            // 在這裡處理錯誤，例如記錄錯誤消息
            Debug.LogError("Invalid audio data received.");
            return;
        }
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        recording = false;
        SendRecording();
    }

    private void SendRecording()
    {
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response => {
            if (response.Contains("���U"))
            {
                animator.SetTrigger("SitTrigger"); // ���� "���U" �ʵe
            }
            else if (response.Contains("�߿�"))
            {
                kittySource.PlayOneShot(meowSound);
                animator.SetTrigger("ShakeHeadTrigger"); // ���� "�n�Y" �ʵe
            }
            else if(response.Contains("�L��"))
            {
                kittySource.PlayOneShot(LookAtMeSound);
                animator.SetTrigger("WalkTrigger");
            }
            else
            {
                animator.SetTrigger("ShakeHeadTrigger"); // �p�G�L�k���ѡA�]���� "�n�Y" �ʵe
            }
        }, error => {
            // �b���~���p�U�A���� "�n�Y" �ʵe
            animator.SetTrigger("ShakeHeadTrigger");
        });
    }

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream))
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }
}
