using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//TODO: Make this houl class ues xml
public class ResulutionChanger : MonoBehaviour {

    Dropdown dropdown;

    int selectedRes;
    int resWidth;
    int resHeight;
    int refreshRate;

    public bool isFullscreened { get; set; }

    //MainMenuController refrance
    MainMenuController mainMenuC;

    // Use this for initialization
    void Start () {
        dropdown = gameObject.GetComponent<Dropdown>();

        //Atrod MainMenuController
        mainMenuC = transform.parent.parent.gameObject.GetComponent<MainMenuController>();

        resWidth = Screen.width;
        resHeight = Screen.height;
        isFullscreened = Screen.fullScreen;
    }
	
	// Update is called once per frame
	void Update() {
        //Darbojas ja skats uz options menu
        if (mainMenuC.showsOtionsMenu == true)
        {
            if (selectedRes != dropdown.value)
            {
                CheckValue();
            }
        }
	}

    void CheckValue()
    {
        SelectResulution(dropdown.value, isFullscreened);
        selectedRes = dropdown.value;
    }

    public void UpdateRes()
    {
        ChangeRes(resWidth, resHeight, isFullscreened, refreshRate);
    }

    void SelectResulution(int value, bool fullscreened)
    {
        switch (value)
        {
            case 0:
                ChangeRes(1920, 1080, fullscreened, 60);
                break;
            case 1:
                ChangeRes(1920, 1080, fullscreened, 120);
                break;
            case 2:
                ChangeRes(1920, 1080, fullscreened, 144);
                break;
            case 3:
                ChangeRes(1240, 720, fullscreened, 60);
                break;
            case 4:
                ChangeRes(640, 480, fullscreened, 60);
                break;
            default:
                Debug.LogError("Specified value can't be found: " + value);
                break;
        }
    }

    void ChangeRes(int width, int height, bool fullscreened, int refrasheRate)
    {
        Screen.SetResolution(width, height, fullscreened, refrasheRate);
        resWidth = width;
        resHeight = height;
        isFullscreened = fullscreened;
        refreshRate = refrasheRate;
    }
}
