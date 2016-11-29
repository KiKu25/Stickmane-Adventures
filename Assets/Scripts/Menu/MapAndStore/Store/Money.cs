using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    Text moneyField;

    int money;

	// Use this for initialization
	void Start () {

        moneyField = GetComponent<Text>();

        GameControl.control.Load();

        Debug.Log(GetMoney());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    int GetMoney()
    {
        return GameControl.control.moneyStolen;
    }

    void UpdateUI()
    {
        moneyField.text = "Money: " + GetMoney();
    }
}
