using System.Collections;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CompanyTradeListCellView : EnhancedScrollerCellView {
	public Text displayText;

	public void SetData (ScrollerData data) {
		displayText.text = data.displayText;

		Button btn = this.GetComponent<Button> ();
		data.cellButton = btn;
		data.cellButton.onClick.AddListener (ClickMe);
		data.cellButton.name = displayText.text;
	}

	public void ClickMe () {
		var colors = this.GetComponent<Button> ().colors;
		colors.normalColor = Color.yellow;
		this.GetComponent<Button> ().colors = colors;

		Debug.Log ("I am 2clicked -> " + EventSystem.current.currentSelectedGameObject.name);
	}

}