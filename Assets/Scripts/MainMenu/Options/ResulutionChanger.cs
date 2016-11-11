using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//TODO: Make this houl class ues xml
public class ResulutionChanger : MonoBehaviour {

    Dropdown dropdown;

    int selectedRes = 0;
    int resX;
    int resY;
    int refreshRate;

    bool fullscreened = true;

    //MainMenuController refrance
    MainMenuController mainMenuC;

    // Use this for initialization
    void Start () {
        dropdown = gameObject.GetComponent<Dropdown>();

        //Atrod MainMenuController
        mainMenuC = transform.parent.parent.gameObject.GetComponent<MainMenuController>();
    }
	
	// Update is called once per frame
	void Update() {
        //Darbojas ja skats uz options menu
        if (mainMenuC.showsOtionsMenu == true)
        {
            if (selectedRes != dropdown.value)
            {
                ChangeResulution(dropdown.value);
                selectedRes = dropdown.value;
            }
        }
	}

    void ChangeResulution(int res)
    {
        if (res == 0)
        {
            Screen.SetResolution(1920, 1080, fullscreened, 60);
            resX = 1920;
            resY = 1080;
            refreshRate = 60;
        }
        else if (res == 1)
        {
            Screen.SetResolution(1920, 1080, fullscreened, 120);
            resX = 1920;
            resY = 1080;
            refreshRate = 120;
        }
        else if (res == 2)
        {
            Screen.SetResolution(1920, 1080, fullscreened, 144);
            resX = 1920;
            resY = 1080;
            refreshRate = 144;
        }
        else if (res == 3)
        {
            Screen.SetResolution(1240, 720, fullscreened, 60);
            resX = 1240;
            resY = 720;
            refreshRate = 60;
        }
        else if (res == 4)
        {
            Screen.SetResolution(640, 480, fullscreened, 60);
            resX = 640;
            resY = 480;
            refreshRate = 60;
        }
    }
}
