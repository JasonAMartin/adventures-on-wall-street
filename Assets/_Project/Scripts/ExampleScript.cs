using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleScript : MonoBehaviour {
    public string PlayerName = "Jason";
    public Button myButton;
	// Use this for initialization
	void Start () {
        // Button btn = myButton.GetComponent<Button>();
        // btn.onClick.AddListener(TaskOnClick);
        setData();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        print("The player's name is: " + PlayerName);
    }

    private void OnMouseDown()
    {
        Debug.Log("hi....");
    }

    public string setData()
    {
        return "JASON IS HERE";
    }
}
