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
	}
	
	// Update is called once per frame
	void Update () {

        money = GetMoney();

        int curentMoney = 0;

        if (curentMoney != money )
        {
            curentMoney = GetMoney();
            UpdateUI();
        }
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
