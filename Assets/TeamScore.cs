using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.Windows;

public class TeamScore : MonoBehaviour
{
    [SerializeField] private TMP_InputField m_Text;
    [SerializeField] private TMP_InputField m_Points;
    [SerializeField] private Team m_Team;

    [SerializeField] private Button m_UpButton;
    [SerializeField] private Button m_DownButton;

    public void InitScore(Team team)
    {
        m_Team = team;
        m_UpButton.onClick.AddListener(IncreaseScore);
        m_DownButton.onClick.AddListener(DecreaseScore);

        m_Text.onEndEdit.AddListener(SetName);
        m_Points.onEndEdit.AddListener(SetPoints);
    }

    public void IncreaseScore()
    {
        m_Team.Points += ActiveQuestionManager.m_ActiveQuestion.Points;
        m_Points.text = m_Team.Points.ToString();
    }

    public void DecreaseScore()
    {
        m_Team.Points -= ActiveQuestionManager.m_ActiveQuestion.Points;
        m_Points.text = m_Team.Points.ToString();
    }

    public void SetName(string name)
    {
        m_Team.Name = name;
    }

    public void SetPoints(string points)
    {
        try
        {
            int result = Int32.Parse(points);
            m_Team.Points = result;
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{points}'");
        }
    }
}
