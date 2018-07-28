using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using EnhancedUI.EnhancedScroller;
using UnityEngine.EventSystems;

public class LoadGameCellView : EnhancedScrollerCellView
{
    public Text displayText;

    public void SetData(ScrollerData data)
    {
        displayText.text = data.displayText;

        Button btn = this.GetComponent<Button>();
        data.cellButton = btn;
        data.cellButton.onClick.AddListener(ClickMe);
        data.cellButton.name = displayText.text;
    }

    public void ClickMe()
    {
        var colors = this.GetComponent<Button>().colors;
        colors.normalColor = Color.yellow;
        this.GetComponent<Button>().colors = colors;

        LoadGameButton loadButton = GameObject.Find("LoadGameButton").GetComponent<LoadGameButton>();
        loadButton.gameSaveName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("I am 2clicked -> " + EventSystem.current.currentSelectedGameObject.name);
    }

}
