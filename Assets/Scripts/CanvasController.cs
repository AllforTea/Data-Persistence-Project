using UnityEditor;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText,editedText;
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        EditScore(ScoreManager.Instance.maxScoreData.score,ScoreManager.Instance.maxScoreData.name);
    }
    public void Exit()
    {
        ScoreManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void EditScore(int score, string name)
    {
        Debug.Log("Editing Score");
        bestScoreText.text = "Best Score: " + name + ": " + score.ToString();
    }


    public void EditCurPlayername()
    {
        ScoreManager.Instance.curPlayerName = editedText.text;
    }
}
