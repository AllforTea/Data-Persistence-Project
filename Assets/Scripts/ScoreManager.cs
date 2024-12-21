using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.Android.Gradle.Manifest;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public SaveData maxScoreData;
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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public string name;
        public int score;
    }
    public void SaveScore(int score, string name)
    {
        SaveData playerData = new SaveData();
        playerData.score = score;
        playerData.name = name;

        string json = JsonUtility.ToJson(playerData);

        File.WriteAllText(UnityEngine.Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = UnityEngine.Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maxScoreData = data;
        }
    }
}
