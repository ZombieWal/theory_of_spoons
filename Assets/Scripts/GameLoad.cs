using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowStartScreen();
    }

    // Update is called once per frame
    void ShowStartScreen()
    {
        StartCoroutine(SceneLoadDelay(5.0f, "Game"));
    }

    IEnumerator SceneLoadDelay(float duration, string sceneName)
    {
        Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
        yield return new WaitForSeconds(duration);
        Debug.Log($"Ended at {Time.time}");
        SceneManager.LoadScene(sceneName);
    }

}
