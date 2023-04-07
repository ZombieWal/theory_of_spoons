using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;
using Yarn.Unity;


public class RestartButton : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public string resetNode = "Start";
    public Button restartButton;
    void Start()
    {
        Button btn = restartButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("button clicked");
        dialogueRunner.Stop();
        dialogueRunner.StartDialogue(resetNode);
    }
}
