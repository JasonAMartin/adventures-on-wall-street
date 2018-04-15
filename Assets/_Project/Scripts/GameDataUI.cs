using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataUI : MonoBehaviour {
	public Text gameCalendar;
	public GameController gameController;

	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
	}

	void Update () {
		gameCalendar.text = gameController.gameDataBlueprint.gameDateTime.PrettyDate ();
	}
}