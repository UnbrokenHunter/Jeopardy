using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Transform m_CatagoryContainer;

    [SerializeField] private QuestionList m_Questions;

    [Space]
    
    [SerializeField] private GameObject m_BoardCatagoryTemplate;
    [SerializeField] private List<BoardCatagory> m_BoardCatagories = new List<BoardCatagory>();

    [Space]

    [SerializeField] private string m_FilePath = "DemoQuestions.json";

    private void Awake()
    {
        m_Questions = QuestionLoader.LoadQuestions(m_FilePath);
        
        if (m_CatagoryContainer == null)
        {
            m_CatagoryContainer = new GameObject("Catagories").transform;
            m_CatagoryContainer.parent = transform;
        }
    }

    private void Start()
    {
        ActiveQuestionManager.Init();

        string[] catagories = GetCatagories(m_Questions);

        foreach (string catagory in catagories)
        {
            var boardCatagoryObject = Instantiate(m_BoardCatagoryTemplate, m_CatagoryContainer);
            var boardCatagory = boardCatagoryObject.GetComponent<BoardCatagory>();
            boardCatagory.InitCatagory(catagory);
            m_BoardCatagories.Add(boardCatagory);
        }

        foreach (Question question in m_Questions.Questions)
        {
            m_BoardCatagories.Find(catagory => catagory.CatagoryName.Equals(question.Catagory)).AddQuestionToCatagory(question);
        }
    }

    private static string[] GetCatagories(QuestionList questions)
    {
        List<string> catagories = new List<string>();
        foreach (var item in questions.Questions)
        {
            catagories.Add(item.Catagory);
        }
        return catagories.Distinct().ToArray();
    }
}
