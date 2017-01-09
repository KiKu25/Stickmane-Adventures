using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu { get; protected set; }
    public GameObject OptionsMenu { get; protected set; }
    public GameObject NewGameMenu { get; protected set; }
    public GameObject LoadGameMenu { get; protected set; }

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
            if (MainMenu.activeInHierarchy || lastMenu == null)
            {
                Application.Quit();
            }
            else
            {
                SwitchMenu(lastMenu);
            }
        }

        //TODO: Remove this for realese
        if (LoadGameMenu.activeInHierarchy == true)
        {
            if (Input.GetKeyDown("f5"))
            {
                LoadDeve();
            }
        }
    }    

    //Lai uztaisitu jaunu speli
    public void NewGame(string saveName)
    {
        GameControl.control.curentSaveGame = saveName;  //Set kuru save game izvlelejas
        //TODO: Make this make a new game
        Debug.Log("Delete save game");
        GameControl.control.DeleteFolder(saveName); //Izdzes ieprieksejo save game 
        LoadeScene("MAP");  //Ielade MAP
    }

    //Lai ieladetu speli
    public void LoadeGame(string saveName)
    {
        GameControl.control.curentSaveGame = saveName;  //Set kuru save game izvlelejas
        SceneManager.LoadScene("MAP");  //Ielade MAP
    }

    //TODO: Remove this for realese
    void LoadDeve()
    {
        GameControl.control.curentSaveGame = "deve";  //Lai varetu izmantot deve files
        SceneManager.LoadScene("MAP");  //Ielade MAP
    }

    //Izet no speles
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void SwitchMenu(string toMenu)
    {
        toMenu.ToLower();

        if (toMenu == "main_menu" && MainMenu.activeInHierarchy == false)
        {
            SetLasMenu();
            MainMenu.SetActive(true);
            OptionsMenu.SetActive(false);
            NewGameMenu.SetActive(false);
            LoadGameMenu.SetActive(false);
        }
        else if (toMenu == "option_menu" && OptionsMenu.activeInHierarchy == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            OptionsMenu.SetActive(true);
            NewGameMenu.SetActive(false);
            LoadGameMenu.SetActive(false);
        }
        else if (toMenu == "new_game" && NewGameMenu.activeInHierarchy == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            NewGameMenu.SetActive(true);
            LoadGameMenu.SetActive(false);
        }
        else if (toMenu == "loade_game" && LoadGameMenu.activeInHierarchy == false)
        {
            SetLasMenu();
            MainMenu.SetActive(false);
            OptionsMenu.SetActive(false);
            NewGameMenu.SetActive(false);
            LoadGameMenu.SetActive(true);
        }
    }

    void SetLasMenu()
    {
        if (MainMenu.activeInHierarchy)
        {
            lastMenu = "main_menu";
        }
        else if (OptionsMenu.activeInHierarchy)
        {
            lastMenu = "option_menu";
        }
        else if (NewGameMenu.activeInHierarchy)
        {
            lastMenu = "new_game";
        }
        else if (LoadGameMenu.activeInHierarchy)
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
