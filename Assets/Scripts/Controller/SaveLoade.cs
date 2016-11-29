using UnityEngine;
using System.Collections;

public class SaveLoade : MonoBehaviour {

    //A hacky way to save data;

	public void Save()
    {
        GameControl.control.Save();
    }

    public void Loade()
    {
        GameControl.control.Load();
    }
}
