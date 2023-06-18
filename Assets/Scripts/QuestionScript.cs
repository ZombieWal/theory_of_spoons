using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;

public class QuestionScript : MonoBehaviour
{
    public TMP_Text question;
    public Button[] answerButtons;
    private int currentQuestionIndex = 0;
    public static int spoonCount;
    public int rawSpoonCount;
    

    private List<string> questions = new List<string>();
    private List<string[]> answers = new List<string[]>();

    void Start()
    {
        LoadDataFromCSV();
        LoadQuestion(currentQuestionIndex);
        foreach (Button button in answerButtons)
        {
            button.onClick.AddListener(() => { ButtonClicked(button); });
        }
    }

    void LoadDataFromCSV()
    {
        string path = "Assets/Resources/beck_test.csv";
        using (var reader = new StreamReader(path))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                questions.Add(values[1]);
                answers.Add(new string[] { values[2], values[3], values[4], values[5] });
            }
        }
    }

    void LoadQuestion(int questionIndex)
    {
        question.text = questions[questionIndex];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = answers[questionIndex][i];
        }
    }

    void ButtonClicked(Button button)
    {
        Debug.Log("Clicked answer: " + button.GetComponentInChildren<TMP_Text>().text);

        if (button.name == "Option 1")
        {
            rawSpoonCount += 3;
        }
        if (button.name == "Option 2")
        {
            rawSpoonCount += 2;
        }
        if (button.name == "Option 3")
        {
            rawSpoonCount += 1;
        }
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Count)
        {
            LoadQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("Questionnaire completed!");
            if (rawSpoonCount > 40)
            {
                spoonCount = 3;
            }
            else
            {
                spoonCount = 12 - rawSpoonCount / 4;
            }
            print("Spoon count is " + spoonCount);
            print("Raw Questionnaire Count is " + rawSpoonCount);
            SceneManager.LoadScene("StartScreen");
            // Handle end of questionnaire here
        }
    }
}

