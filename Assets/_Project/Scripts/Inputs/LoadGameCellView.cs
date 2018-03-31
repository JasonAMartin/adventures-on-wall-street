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
        Debug.Log("I am clicked -> " + EventSystem.current.currentSelectedGameObject.name);
    }

}
