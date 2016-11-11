using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VSync : MonoBehaviour {

    //TODO: Make me ues xml
    //Lai zinatu kas tagat vai VSync ir ieslegts 
    bool vSyncOn = true;

    //Toggle refrance
    Toggle vSyncToggle;

    //MainMenuController refrance
    MainMenuController mainMenuC;

    // Use this for initialization
    void Start () {
        //Atrod Toggle
        vSyncToggle = gameObject.GetComponent<Toggle>();

        //Atrod MainMenuController
        mainMenuC = transform.parent.parent.gameObject.GetComponent<MainMenuController>();
	}
	
	// Update is called once per frame
	void Update () {
        //Darbojas ja skatas uz options menu
        if (mainMenuC.showsOtionsMenu == true)
        {
            //Parbaud vai vSyncOn
            if (vSyncOn != vSyncToggle.isOn)
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
