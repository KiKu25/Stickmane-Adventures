using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    GameObject MainMenu;
    GameObject OptionsMenu;
    
    public bool showsOtionsMenu { get; protected set; }
    public bool showsMainMenu { get; protected set; }

    string lastMenu;

    void Start()
    {
        MainMenu = transform.GetChild(0).gameObject;
        OptionsMenu = transform.GetChild(1).gameObject;

        SwitchMenu("main_menu");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (showsMainMenu || lastMenu == null)
            {
                Application.Quit();
            }
            else
            {
                SwitchMenu(lastMenu);
            }
        }
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

    public void SwitchMenu(string toMenu)
    {
        toMenu.ToLower();

        if (toMenu == "main_menu" && showsMainMenu == false)
        {
            SetLasMenu();
            MainMenu.SetActive(true);
            showsMainMenu = true;
            OptionsMenu.SetActive(false);
            showsOtionsMenu = false;
        }
        else if (toMenu == "option_menu" && showsOtionsMenu == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            showsMainMenu = false;
            OptionsMenu.SetActive(true);
            showsOtionsMenu = true;
        }
    }

    void SetLasMenu()
    {
        if (showsMainMenu)
        {
            lastMenu = "main_menu";
        }
        else if (showsOtionsMenu)
        {
            lastMenu = "option_menu";
        }
    }
}
