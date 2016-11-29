using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PausMenu : MonoBehaviour {

    GameObject menu;

	// Use this for initialization
	void Start () {

        menu = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            ToggleMenu();
        }
	}

    void ToggleMenu()
    {
        if (menu.activeInHierarchy == true)
        {
            ResumeGame();
        }
        else
        {
            StopGame();
        }
    }

    public void ExitToOS()
    {
        GameControl.control.Save();
        Application.Quit();
    }

    public void ExitToMainMenu()
    {
        GameControl.control.Save();
        SceneManager.LoadScene("MAIN_MENU");
    }

    public void QuitHeist()
    {
        GameControl.control.Save();
        SceneManager.LoadScene("MAP");
    }

    public void StopGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
