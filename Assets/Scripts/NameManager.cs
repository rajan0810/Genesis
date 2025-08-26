using UnityEngine;
using TMPro;
using System.IO;
public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string naam;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveName
    {
        public string naam;
    }

    public void SaveNaam()
    {
        SaveName data = new SaveName();
        data.naam = naam;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }

    public void LoadNaam()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveName data = JsonUtility.FromJson<SaveName>(json);

            naam = data.naam;
        }
    }



}
