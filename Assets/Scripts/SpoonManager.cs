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
        bool test;
        test = variableStorage.TryGetValue<float>("$spoonCount", out float spoonCount);
        generateSpoons();
    }
    // Update is called once per frame
    void Update()
    {
        variableStorage.TryGetValue("$spoonCount", out spoonCount);
        foreach (GameObject obj in spoons)
        {
            Destroy(obj);
        }
        spoons.Clear();
        generateSpoons();
    }

    void generateSpoons()
    {
        variableStorage.TryGetValue("$spoonCount", out spoonCount);
        for (int i = 0; i < spoonCount; i++)
        {
            newSpoon = Instantiate(spoon, gameObject.transform);
            spoons.Add(newSpoon);
        }
    }
    
}
