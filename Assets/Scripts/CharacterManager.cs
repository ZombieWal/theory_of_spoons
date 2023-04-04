using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class CharacterManager : MonoBehaviour
{
    public List<Sprite> characters;

    float characterCount;
    Image template;
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
        setCharacter();
    }

    void setCharacter()
    {
        template = GetComponent<Image>();
        variableStorage.TryGetValue<float>("$characterCount", out float characterCount);
        int charCounter = (int)characterCount;

        if (charCounter == 0)
        {
            template.color = new Color(1, 1, 1, 0);
        }
        else
        {
            template.color = new Color(1, 1, 1, 1);
            gameObject.GetComponent<Image>().sprite = characters[charCounter - 1];
        }
    }
}
