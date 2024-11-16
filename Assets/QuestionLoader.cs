using System.IO;
using UnityEngine;

public class QuestionLoader : MonoBehaviour
{
    public static QuestionList LoadQuestions(string jsonFilePath, bool printQuestions = false)
    {
        // Load the JSON file
        string filePath = Path.Combine(Application.dataPath, jsonFilePath);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            // Parse the JSON into QuestionList
            QuestionList questionList = JsonUtility.FromJson<QuestionList>("{\"Questions\":" + json + "}");

            // Log the questions
            if (printQuestions) 
                foreach (Question question in questionList.Questions)
                    Debug.Log($"Title: {question.Title}, Prompt: {question.Prompt}, Answer: {question.Answer}, Catagory: {question.Catagory}, Points: {question.Points}");
            
            return questionList;
        }
        else
        {
            Debug.LogError($"File not found: {filePath}");
        }

        return null;
    }
}
