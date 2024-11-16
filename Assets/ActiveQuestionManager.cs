using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ActiveQuestionManager : MonoBehaviour
{
    public static ActiveQuestionManager instance;

    public ActiveQuestionManager() { instance = this; }

    [SerializeField] private GameObject m_Board;
    [SerializeField] private GameObject m_QuestionScreen;

    [Space]

    [SerializeField] private TMP_Text m_Title;
    [SerializeField] private TMP_Text m_Prompt;
    [SerializeField] private TMP_Text m_Answer;

    [SerializeField] private Button m_RevealButton;
    [SerializeField] private Button m_ContinueButton;
    [SerializeField] private Button m_CancelButton;

    public static Question m_ActiveQuestion { get; private set; }
    public static BoardQuestion m_ActiveQuestionObject { get; private set; }

    public static void Init()
    {
        instance.m_CancelButton.onClick.AddListener(CancelQuestion);

        instance.m_Board.gameObject.SetActive(true);
        instance.m_QuestionScreen.gameObject.SetActive(false);
    }

    public static void SetQuestion(Question question, BoardQuestion questionObject)
    {
        m_ActiveQuestion = question;
        m_ActiveQuestionObject = questionObject;

        instance.m_Board.SetActive(false);
        instance.m_QuestionScreen.SetActive(true);

        instance.m_Title.transform.parent.gameObject.SetActive(true);
        instance.m_Title.text = question.Title;

        instance.m_Prompt.transform.parent.gameObject.SetActive(true);
        instance.m_Prompt.text = question.Prompt;

        instance.m_Answer.transform.parent.gameObject.SetActive(false);
        instance.m_Answer.text = question.Answer;

        instance.m_RevealButton.onClick.RemoveAllListeners();
        instance.m_RevealButton.onClick.AddListener(RevealQuestion);
    }

    public static void RevealQuestion()
    {
        instance.m_Title.transform.parent.gameObject.SetActive(false);
        instance.m_Prompt.transform.parent.gameObject.SetActive(false);

        instance.m_Answer.transform.parent.gameObject.SetActive(true);

        instance.m_ContinueButton.onClick.RemoveAllListeners();
        instance.m_ContinueButton.onClick.AddListener(ContinueQuestion);
    }

    public static void ContinueQuestion()
    {
        m_ActiveQuestionObject.TextMeshPro.text = "";
        m_ActiveQuestionObject.Button.onClick.RemoveAllListeners();

        instance.m_Board.gameObject.SetActive(true);
        instance.m_QuestionScreen.gameObject.SetActive(false);
    }

    public static void CancelQuestion()
    {
        instance.m_Board.gameObject.SetActive(true);
        instance.m_QuestionScreen.gameObject.SetActive(false);
    }
}
