using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardQuestion : MonoBehaviour
{
    public TMP_Text TextMeshPro;
    public Button Button;

    [Space]

    [SerializeField] private Question m_Question;

    private void Awake()
    {
        TextMeshPro = GetComponentInChildren<TMP_Text>();
        Button = GetComponentInChildren<Button>();
    }

    public void InitQuestion(Question question)
    {
        this.m_Question = question;

        gameObject.name = m_Question.Catagory + " - " + m_Question.Title + " (" + m_Question.Points + ")";
        TextMeshPro.text = m_Question.Title;

        Button.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        print(m_Question.Title);
     
        ActiveQuestionManager.SetQuestion(m_Question, this);
        // Pass Question to the Question Manager
    }

}
