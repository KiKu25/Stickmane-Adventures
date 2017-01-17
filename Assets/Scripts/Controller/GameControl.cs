using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int moneyStolen { get; set; }

    public string curentSaveGame { get; set; }
    public string defaultSaveGame { get; protected set; }

    public string playerAnimationName { get; set; }
    public string defaultPlayerAnimationName { get; protected set; }

    void Awake () {

        defaultSaveGame = "deve";
        defaultPlayerAnimationName = "Player_Christmas";

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != null)
        {
            Destroy(gameObject);
        }

        if (curentSaveGame == null)
        {
            curentSaveGame = defaultSaveGame;
        }

        if (playerAnimationName == null)
        {
            playerAnimationName = defaultPlayerAnimationName;
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        Data data = new Data();

        Debug.Log("Saving data");
        if (CheckIfaFolderExists(curentSaveGame) == false)
        {
            Debug.Log("Create a folder where to save data");
            CreateFolder(curentSaveGame);
        }

        if (CheckIfaFileExists(curentSaveGame + "/save.dat") == false)
        {
            Debug.Log("Create a file where to save data");
            file = File.Create(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat");
        }
        else
        {
            Debug.Log("Open a file where to save data");
            file = File.Open(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat", FileMode.Open);
        }

        
        data.moneyStolen += moneyStolen;
        data.selectedPlayerAnimationName = playerAnimationName;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (curentSaveGame == "deve")
        {
            if (CheckIfaFileExists(curentSaveGame + "/save.dat") == false)
            {
                CreateDeveGame(); 
            }
        }

        if (CheckIfaFileExists(curentSaveGame + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();

            moneyStolen = data.moneyStolen;
            playerAnimationName = data.selectedPlayerAnimationName;
        }
    }

    void CreateDeveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        Data data = new Data();

        if (curentSaveGame == null)
        {
            curentSaveGame = defaultSaveGame;
        }

        if (CheckIfaFolderExists(curentSaveGame) == false)
        {
            CreateFolder(curentSaveGame);
        }

        if (CheckIfaFileExists(curentSaveGame + "/save.dat") == false)
        {
            Debug.Log("Create a file where to save data");
            file = File.Create(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat");

            data.moneyStolen = 999999999;
            bf.Serialize(file, data);

            file.Close();
        }       
    }

    public void DeleteFolder(string pathFromPersistentDataPath)
    {
        if (CheckIfaFolderExists(Application.persistentDataPath + "/" + pathFromPersistentDataPath))
        {
            FileUtil.DeleteFileOrDirectory(Application.persistentDataPath + "/" + pathFromPersistentDataPath);
        }
    }

    public void DeleteFile(string pathFromPersistentDataPath)
    {
        if (CheckIfaFileExists(Application.persistentDataPath + "/" + pathFromPersistentDataPath))
        {
            FileUtil.DeleteFileOrDirectory(Application.persistentDataPath + "/" + pathFromPersistentDataPath);
        }
    }

    public bool CheckIfaFolderExists(string pathFromPersistentDataPath)
    {
        if (Directory.Exists(Application.persistentDataPath + "/" + pathFromPersistentDataPath) == false)
        {
            return false;
        }

        return true;
    }

    public bool CheckIfaFileExists(string pathFromPersistentDataPath)
    {
        if (File.Exists(Application.persistentDataPath + "/" + pathFromPersistentDataPath) == false)
        {
            return false;
        }

        return true;
    }

    public void CreateFolder(string pathFromPersistentDataPath)
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/" + pathFromPersistentDataPath);
    }

    public void CreateFile(string pathFromPersistentDataPath)
    {
        File.Create(Application.persistentDataPath + "/" + pathFromPersistentDataPath);
    }
}

[Serializable]
class Data {
    public int moneyStolen;

    public string selectedPlayerAnimationName;
}
