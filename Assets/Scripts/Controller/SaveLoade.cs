using UnityEngine;
using System.Collections;

public class SaveLoade : MonoBehaviour {

	public void Save()
    {
        GameControl.control.Save();
    }

    public void Loade()
    {
        GameControl.control.Load();
    }
}
