using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TMP_InputField nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        displayHighscore();
    }

    public void GoToGame()
    {
        if(NameManager.Instance != null)
        {
            NameManager.Instance.naam = (string) nameText.text;
            NameManager.Instance.SaveNaam();
        }
        SceneManager.LoadScene(1);
    }

    void displayHighscore()
    {
        if (ItemsToSave.Instance != null)
        {
            ItemsToSave.Instance.LoadScore();
            highscoreText.text = $"Best Score: {ItemsToSave.Instance.highScore}";
        }
    }

    public void ResetScore()
    {
        ItemsToSave.Instance.highScore = 0;
        ItemsToSave.Instance.SaveScore();
    }
}
