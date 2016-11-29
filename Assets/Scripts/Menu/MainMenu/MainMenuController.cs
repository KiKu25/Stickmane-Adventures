using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    GameObject MainMenu;
    GameObject OptionsMenu;
    GameObject NewGameMenu;
    GameObject LoadGameMenu;
    
    public bool showsOtionsMenu { get; protected set; }
    public bool showsMainMenu { get; protected set; }
    public bool showsNewGameMenu { get; protected set; }
    public bool showsLoadeMenu { get; protected set; }

    string lastMenu;

    void Start()
    {
        MainMenu = transform.GetChild(0).gameObject;
        OptionsMenu = transform.GetChild(1).gameObject;
        NewGameMenu = transform.GetChild(2).gameObject;
        LoadGameMenu = transform.GetChild(3).gameObject;

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

    //Lai uztaisitu jaunu speli
    public void NewGame(string saveName)
    {
        GameControl.control.curentSaveGame = saveName;
        //TODO: Make this make a new game
        LoadeScene("MAP");
    }

    public void LoadeGame(string saveName)
    {
        GameControl.control.curentSaveGame = saveName;
    }

    //Izet no speles
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

            NewGameMenu.SetActive(false);
            showsNewGameMenu = false;

            LoadGameMenu.SetActive(false);
            showsLoadeMenu = false;
        }
        else if (toMenu == "option_menu" && showsOtionsMenu == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            showsMainMenu = false;

            OptionsMenu.SetActive(true);
            showsOtionsMenu = true;

            NewGameMenu.SetActive(false);
            showsNewGameMenu = false;

            LoadGameMenu.SetActive(false);
            showsLoadeMenu = false;
        }
        else if (toMenu == "new_game" && showsNewGameMenu == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            showsMainMenu = false;

            OptionsMenu.SetActive(false);
            showsOtionsMenu = false;

            NewGameMenu.SetActive(true);
            showsNewGameMenu = true;

            LoadGameMenu.SetActive(false);
            showsLoadeMenu = false;
        }
        else if (toMenu == "loade_game" && showsLoadeMenu == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            showsMainMenu = false;

            OptionsMenu.SetActive(false);
            showsOtionsMenu = false;

            NewGameMenu.SetActive(false);
            showsNewGameMenu = false;

            LoadGameMenu.SetActive(true);
            showsLoadeMenu = true;
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
        else if (showsNewGameMenu)
        {
            lastMenu = "new_game";
        }
        else if (showsLoadeMenu)
        {
            lastMenu = "loade_game";
        }
    }

    //Ieladet scene ar string
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

    //Ieladet scene ar int
    public void LoadeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
