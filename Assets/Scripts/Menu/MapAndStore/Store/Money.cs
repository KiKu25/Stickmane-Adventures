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

        if (money == 0)
        {
            curentMoney = 0;
            UpdateUI(curentMoney);
        }
        else if (curentMoney != money )
        {
            curentMoney = GetMoney();
            UpdateUI(curentMoney);
        }
	}

    int GetMoney()
    {
        return GameControl.control.moneyStolen;
    }

    void UpdateUI(int money)
    {
        moneyField.text = "Money: " + money;
    }
}
