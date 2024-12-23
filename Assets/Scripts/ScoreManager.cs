using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string curPlayerName= "Developer";
    public SaveData maxScoreData = new SaveData();
    public void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int score;
    }
    public void SaveScore()
    {
        string json = JsonUtility.ToJson(maxScoreData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScoreData = data;
        }
        else
        {
            maxScoreData.name = ".....";
            maxScoreData.score = 0;
        }
    }

    public void EditAndSaveMaxScore(int score)
    {
        maxScoreData.name = curPlayerName;
        maxScoreData.score = score;

        SaveScore();
    }
}
