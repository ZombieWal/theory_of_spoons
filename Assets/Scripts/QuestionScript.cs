using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class QuestionScript : MonoBehaviour
{
    public TMP_Text question;
    public Button[] answerButtons;
    private int currentQuestionIndex = 0;

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

                questions.Add(values[0]);
                answers.Add(new string[] { values[1], values[2], values[3] });
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
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            LoadQuestion(currentQuestionIndex);
        }
        else
        {
            Debug.Log("Questionnaire completed!");
            // Handle end of questionnaire here
        }
    }
}

