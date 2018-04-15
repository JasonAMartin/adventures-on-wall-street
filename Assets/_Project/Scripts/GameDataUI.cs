using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataUI : MonoBehaviour {
	public Text gameCalendar;
	public Text gameCycleSegment;
	public GameController gameController;

	void Start () {
		gameController = GameObject.FindObjectOfType<GameController> ();
	}

	void Update () {
		gameCalendar.text = gameController.gameDataBlueprint.gameDateTime.PrettyDate ();
		gameCycleSegment.text = gameController.gameDataBlueprint.currentGameSegment.ToString ();
	}

	public void ProcessNextTurn () {
		gameController.StartNextTurn ();
	}
}