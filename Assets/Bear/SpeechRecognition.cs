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
            if (response.Contains("坐下"))
            {
                animator.SetTrigger("SitTrigger"); // 播放 "坐下" 動畫
            }
            else if (response.Contains("貓貓"))
            {
                kittySource.PlayOneShot(meowSound);
                animator.SetTrigger("ShakeHeadTrigger"); // 播放 "搖頭" 動畫
            }
            else if(response.Contains("過來"))
            {
                kittySource.PlayOneShot(LookAtMeSound);
                animator.SetTrigger("WalkTrigger");
            }
            else
            {
                animator.SetTrigger("ShakeHeadTrigger"); // 如果無法辨識，也執行 "搖頭" 動畫
            }
        }, error => {
            // 在錯誤情況下，執行 "搖頭" 動畫
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
