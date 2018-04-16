using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockExchangeListItem : MonoBehaviour {
	public string companyName;
	public int stockPrice;

	public GameObject displayCompanyName;
	public GameObject displayStockPrice;

	public Company displayCompany;

	// Use this for initialization
	void Start () {
		displayStockPrice.GetComponent<Text> ().text = "";
		DisplayData ();
	}

	// Update is called once per frame
	void Update () {
		DisplayData ();
	}

	void DisplayData () {
		displayCompanyName.GetComponent<Text> ().text = displayCompany.companyName.ToString () + " $" + displayCompany.stockPrice.ToString ();
	}
}