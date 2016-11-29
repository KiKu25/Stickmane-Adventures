using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSwicher : MonoBehaviour {

    GameObject MapMenu;
    GameObject StoreMenu;

    public bool showsMapMenu { get; protected set; }
    public bool showsStoreMenu { get; protected set; }

    string lastMenu;

	// Use this for initialization
	void Start () {
        MapMenu = transform.GetChild(0).gameObject;
        StoreMenu = transform.GetChild(1).gameObject;

        SwitchMenu("map_menu");        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            if (showsMapMenu || lastMenu == null)
            {
                SceneManager.LoadScene("MAIN_MENU");
            }
            else
            {
                SwitchMenu(lastMenu);
            }
        }
    }

    public void SwitchMenu(string toMenu)
    {
        toMenu.ToLower();

        if (toMenu == "map_menu" && showsMapMenu == false)
        {
            SetLasMenu();
            MapMenu.SetActive(true);
            showsMapMenu = true;

            StoreMenu.SetActive(false);
            showsStoreMenu = false;

            GameControl.control.Save();
        }
        else if (toMenu == "store_menu" && showsStoreMenu == false)
        {
            SetLasMenu();
            MapMenu.SetActive(false);
            showsMapMenu = false;

            StoreMenu.SetActive(true);
            showsStoreMenu = true;

            GameControl.control.Load();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("_SCENE");
    }

    void SetLasMenu()
    {
        if (showsMapMenu)
        {
            lastMenu = "map_menu";
        }
        else if (showsStoreMenu)
        {
            lastMenu = "store_menu";
        }
    }
}
