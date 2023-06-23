using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class GameLoad : MonoBehaviour
{
    public TMP_Text panel;
    public GameObject backgroundObject;
    // Start is called before the first frame update
    void Start()
    {
        ShowStartScreen();
    }

    // Update is called once per frame
    void ShowStartScreen()
    {
        panel.text = "Congratulations! You've finished the test! Let's learn some bits of ...";
        StartCoroutine(ScreenDelay(3.0f));
        StartCoroutine(SceneLoadDelay(5.0f, "Game"));
    }

    IEnumerator SceneLoadDelay(float duration, string sceneName)
    {
        Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
        yield return new WaitForSeconds(duration);
        Debug.Log($"Ended at {Time.time}");
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator ScreenDelay(float duration)
    {
        Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
        yield return new WaitForSeconds(duration);
        Debug.Log($"Ended at {Time.time}");
        Destroy(backgroundObject);
    }
}
