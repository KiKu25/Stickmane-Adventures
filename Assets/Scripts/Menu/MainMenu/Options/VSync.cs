using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VSync : MonoBehaviour {

    //Lai zinatu kas tagat vai VSync ir ieslegts 
    bool vSyncOn;

    //Toggle refrance
    Toggle toogle;

    //MainMenuController refrance
    MainMenuController mainMenuC;

    // Use this for initialization
    void Start () {
        //Atrod Toggle
        toogle = gameObject.GetComponent<Toggle>();

        //Atrod MainMenuController
        mainMenuC = transform.parent.parent.gameObject.GetComponent<MainMenuController>();

        toogle.isOn = Screen.fullScreen;
        vSyncOn = Screen.fullScreen;
    }
	
	// Update is called once per frame
	void Update () {
        //Darbojas ja skatas uz options menu
        if (mainMenuC.showsOtionsMenu == true)
        {
            //Parbaud vai vSyncOn
            if (vSyncOn != toogle.isOn)
            {
                ChangeVSync();
            }
        }  
	}

    //Maina VSync
    void ChangeVSync()
    {
        //Ja VSync ir ieslegts to izsledz
        if (QualitySettings.vSyncCount == 1)
        {
            QualitySettings.vSyncCount = 0;
            vSyncOn = false;
        }
        else if (QualitySettings.vSyncCount == 0) //Ja VSync ir izslegts to iesledz
        {
            QualitySettings.vSyncCount = 1;
            vSyncOn = true;
        }
    }
}
