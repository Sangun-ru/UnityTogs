using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Experimental.RestService;

[Serializable]
public class SaveData
{
    public bool[] isActive;
    public int[] highScores;
    public int[] stars;
}

public class GameData : MonoBehaviour
{

    public static GameData gameData;
    public SaveData saveData;

    // Используйте это для инициализации
    void Awake()
    {
        if (gameData == null)
        {
            DontDestroyOnLoad(this.gameObject);
            gameData = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
    }

    private void Start()
    {
        
    }

    public void Save()
    {

        // Создайте двоичный форматтер, который может читать двоичные файлы
        BinaryFormatter formatter = new BinaryFormatter();

        // Создать маршрут программы к файлу
        FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Create);

        // Создать копию данных сохранения
        SaveData data = new SaveData();
        data = saveData;

        // На самом деле сохранить данные в файле
        formatter.Serialize(file, data);

        // Закрыть поток данных
        file.Close();

        Debug.Log("Saved");
    }

    public void Load()
    {
        // Проверьте, существует ли файл сохранения игры
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            // Создайте двоичный форматтер
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            saveData = formatter.Deserialize(file) as SaveData;
            file.Close();
            Debug.Log("Loaded");
        }
        else
        {
            saveData = new SaveData();
            saveData.isActive = new bool[100];
            saveData.stars = new int[100];
            saveData.highScores = new int[100];
            saveData.isActive[0] = true;
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnDisable()
    {
        Save();
    }

    void Update()
    {
        
    }
}
