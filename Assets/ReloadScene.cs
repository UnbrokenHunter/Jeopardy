using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public static ReloadScene Instance { get; private set; }

    public string input_data;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetInputData(string inp)
    {
        input_data = inp;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
