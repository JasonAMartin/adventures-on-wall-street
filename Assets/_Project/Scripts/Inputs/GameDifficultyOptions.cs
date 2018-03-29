using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDifficultyOptions : MonoBehaviour {
    public List<GameDifficulty> gameOptions = new List<GameDifficulty>();
    public Dropdown dropDown;

    void Start()
    {
        dropDown.ClearOptions();
        foreach (GameDifficulty difficulty in gameOptions)
        {
            dropDown.options.Add(new Dropdown.OptionData(difficulty.gameDifficultyName));
        }
        dropDown.RefreshShownValue();
    }
}
