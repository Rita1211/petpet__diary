using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public GameObject kitty; // 在Inspector中設置Kitty GameObject的參考

    public void OnButtonClick()
    {
        // 檢查kitty參考是否已設置
        if (kitty != null)
        {
            // 在Button按下時調用kitty的功能
            kitty.GetComponent<SpeechRecognition>().ToggleRecording();
        }
    }
}
