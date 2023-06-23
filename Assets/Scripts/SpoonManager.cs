using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class SpoonManager : MonoBehaviour
{
    public GameObject spoon;
    public List<GameObject> spoons;
    private GameObject newSpoon;
    public float spoonCount;
    private VariableStorageBehaviour variableStorage;

    void Awake()
    {
        variableStorage = GameObject.FindObjectOfType<Yarn.Unity.InMemoryVariableStorage>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        //spoonCount = QuestionScript.spoonCount;
        spoonCount = 10;
        variableStorage.SetValue("$spoonCount",spoonCount);
        generateSpoons();
    }
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in spoons)
        {
            Destroy(obj);
        }
        spoons.Clear();
        variableStorage.TryGetValue("$spoonCount", out spoonCount);
        generateSpoons();
    }

    void generateSpoons()
    {
        for (int i = 0; i < spoonCount; i++)
        {
            newSpoon = Instantiate(spoon, gameObject.transform);
            spoons.Add(newSpoon);
        }
    }
    
}
