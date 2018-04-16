using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StockExchangeListing : MonoBehaviour {

	public GameObject prefab;
	public IEnumerable<Company> activeCompanies;

	public List<GameObject> listing;

	// Use this for initialization
	private void Start () {
		Populate ();
	}
	public void Populate () {
		GameController gameController = GameObject.FindObjectOfType<GameController> ();
		activeCompanies = gameController.gameDataBlueprint.companyList.Where (o => o.isBeingUsed == true);
		GameObject newObj;
		foreach (Company company in activeCompanies) {
			newObj = (GameObject) Instantiate (prefab, transform);
			newObj.GetComponent<StockExchangeListItem> ().displayCompany = company;
			listing.Add (newObj);
		}
	}

	public void ResetList () {

		foreach (GameObject item in listing) {
			Destroy (item);
		}
	}
}