using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour 
{
    public Text MessageText;
    public GameObject MessagePanel;
    public CanvasGroup cg;

    public static MessageManager Instance;

    void Awake()
    {
        Instance = this;
        MessagePanel.SetActive(false);
    }

    public void ShowMessage(string Message, float Duration)
    {
        StartCoroutine(ShowMessageCoroutine(Message, Duration));
    }

    IEnumerator ShowMessageCoroutine(string Message, float Duration)
    {
        //Debug.Log("Showing some message. Duration: " + Duration);
        MessageText.text = Message;
        MessagePanel.SetActive(true);

        cg.alpha = 1f;
        // wait for 1 second before fading
        yield return new WaitForSeconds(2f);
        // gradually fade the effect by changing its alpha value
        while (cg.alpha > 0)
        {
            cg.alpha -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(Duration);
        //Destroy(this.gameObject);
        MessagePanel.SetActive(false);
        //Command.CommandExecutionComplete();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
            ShowMessage("Your Turn", 3f);
        if (Input.GetKey(KeyCode.E))
            ShowMessage("Enemy's Turn", 3f);
    }
}
