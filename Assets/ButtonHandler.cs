using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject kitty; // �bInspector���]�mKitty GameObject���Ѧ�

    public void OnButtonClick()
    {
        // �ˬdkitty�ѦҬO�_�w�]�m
        if (kitty != null)
        {
            // �bButton���U�ɽե�kitty���\��
            kitty.GetComponent<SpeechRecognition>().ToggleRecording();
        }
    }
}
