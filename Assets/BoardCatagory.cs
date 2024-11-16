using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardCatagory : MonoBehaviour
{
    private TMP_Text m_TextMeshPro;

    [SerializeField] private Transform m_QuestionContainer;

    public string CatagoryName { get; private set; }

    [Space]

    [SerializeField] private GameObject m_BoardQuestionTemplate;

    [SerializeField] private List<Question> m_Questions = new List<Question>();

    [SerializeField] private List<BoardQuestion> m_BoardQuestions = new List<BoardQuestion>();

    private void Awake()
    {
        m_TextMeshPro = GetComponentInChildren<TMP_Text>();
        if (m_QuestionContainer == null)
        {
            m_QuestionContainer = new GameObject("Questions").transform;
            m_QuestionContainer.parent = transform;
        }
    }

    public void InitCatagory(string catagoryName)
    {
        this.CatagoryName = catagoryName;

        gameObject.name = CatagoryName;
        m_TextMeshPro.text = CatagoryName;
    }

    public void AddQuestionToCatagory(Question question)
    {
        m_Questions.Add(question);
        var boardQuestionObject = Instantiate(m_BoardQuestionTemplate, m_QuestionContainer);
        var boardQuestion = boardQuestionObject.AddComponent<BoardQuestion>();
        boardQuestion.InitQuestion(question);
        m_BoardQuestions.Add(boardQuestion);
    }

}
