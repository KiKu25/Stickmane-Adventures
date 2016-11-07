using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadeScene(string scene)
    {
        if (scene != null)
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.LogError("Scen not specified!");
        }
    }

    public void LoadeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
