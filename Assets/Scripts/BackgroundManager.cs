using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BackgroundManager : MonoBehaviour
{
    public List<Sprite> backgrounds;

    float sceneCount;
    private VariableStorageBehaviour variableStorage;

    void Awake()
    {
        variableStorage = GameObject.FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        setBackground();
    }

    void setBackground()
    {
        variableStorage.TryGetValue<float>("$sceneCount", out float sceneCount);
        int backgroundCounter = (int)sceneCount;
        Debug.Log(backgroundCounter+"background counter");
        gameObject.GetComponent<Image>().sprite = backgrounds[backgroundCounter];
    }
}
