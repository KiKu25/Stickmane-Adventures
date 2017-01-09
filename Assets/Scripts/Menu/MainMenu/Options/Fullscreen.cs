using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour {

    bool fullscreened;

    //Toogle reference
    Toggle toogle;

    //MainMenuController refrance
    MainMenuController mainMenuC;

    //ResulutionChanger refrance
    ResulutionChanger resChanger;

    // Use this for initialization
    void Start () {
        //Atrod Toggle
        toogle = gameObject.GetComponent<Toggle>();

        //Atrod MainMenuController
        mainMenuC = transform.parent.parent.gameObject.GetComponent<MainMenuController>();

        //Atrod ResulutionChanger
        resChanger = transform.parent.GetChild(0).GetComponent<ResulutionChanger>();

        toogle.isOn = Screen.fullScreen;
        fullscreened = Screen.fullScreen;
    }

    // Update is called once per frame
    void Update () {

        //Darbojas ja skatas uz options menu
        if (mainMenuC.MainMenu.activeInHierarchy == true)
        {
            //Parbaud vai vSyncOn
            if (fullscreened != toogle.isOn)
            {
                ChangeFullscreene();
            }
        }
    }

    void ChangeFullscreene()
    {
        if (Screen.fullScreen == true)
        {
            fullscreened = false;
            resChanger.isFullscreened = fullscreened;
            resChanger.UpdateRes();
        }
        else if (Screen.fullScreen == false)
        {
            fullscreened = true;
            resChanger.isFullscreened = fullscreened;
            resChanger.UpdateRes();
        }
    }
}
