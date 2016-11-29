using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int moneyStolen { get; set; }

    public string curentSaveGame { get; set; }
    public string defaultSaveGame { get; protected set; }

	void Awake () {

        defaultSaveGame = "deve";

        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != null)
        {
            Destroy(gameObject);
        }
	}

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (curentSaveGame == null)
        {
            curentSaveGame = defaultSaveGame;
        }

        if (File.Exists(Application.persistentDataPath + "/" + curentSaveGame) == false)
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + curentSaveGame);
        }

        if (File.Exists(Application.persistentDataPath  + "/" + curentSaveGame + "/save.dat") == false)
        {
            file = File.Create(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat");
        }
        else
        {
            file = File.Open(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat", FileMode.Open);
        }

        Data data = new Data();
        data.moneyStolen = moneyStolen;

        bf.Serialize(file, data);
        file.Close();
    }
    
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + curentSaveGame + "/save.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();

            moneyStolen = data.moneyStolen;
        }
    }	
}

[Serializable]
class Data {
    public int moneyStolen;
}
