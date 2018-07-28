using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using EnhancedUI.EnhancedScroller;
using BayatGames.SaveGamePro;
using System.IO;


public class ScrollerController : MonoBehaviour, IEnhancedScrollerDelegate
{
    private List<ScrollerData> _data;

    public EnhancedScroller myScroller;
    public LoadGameCellView loadGameCellViewPrefab;
    public Button demo;

    void Start()
    {

        FileInfo[] files = SaveGame.GetFiles();

        _data = new List<ScrollerData>();
        Debug.Log("Retreived FILES: " + files.Length);

       foreach (FileInfo file in files)
        {
            _data.Add(new ScrollerData() { displayText = file.Name });
        }
      
        myScroller.Delegate = this;
        myScroller.ReloadData();
    }
    
    public int GetNumberOfCells(EnhancedScroller scroller)
    {
        return _data.Count;
    }
    public float GetCellViewSize(EnhancedScroller scroller, int dataIndex)
    {
        return 200f;
    }
    public EnhancedScrollerCellView GetCellView(EnhancedScroller scroller, int
    dataIndex, int cellIndex)
    {
        LoadGameCellView cellView = scroller.GetCellView(loadGameCellViewPrefab) as
        LoadGameCellView;
        cellView.SetData(_data[dataIndex]);
        return cellView;
    }
}
