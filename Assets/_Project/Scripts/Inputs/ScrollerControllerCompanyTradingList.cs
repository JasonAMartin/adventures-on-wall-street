using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BayatGames.SaveGamePro;
using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

public class ScrollerControllerCompanyTradingList : MonoBehaviour, IEnhancedScrollerDelegate {
    private List<ScrollerData> _data;

    public EnhancedScroller myScroller;
    public CompanyTradeListCellView cellPrefab;
    public Button demo;

    public GameController gameController;

    void Start () {
        GameController gameController = GameObject.FindObjectOfType<GameController> ();

        var companies = gameController.gameDataBlueprint.companyList.Where ((o) => o.isBeingUsed == true);

        FileInfo[] files = SaveGame.GetFiles ();

        _data = new List<ScrollerData> ();

        foreach (Company company in companies) {
            _data.Add (new ScrollerData () { displayText = company.companyName });
        }

        myScroller.Delegate = this;
        myScroller.ReloadData ();
    }

    public int GetNumberOfCells (EnhancedScroller scroller) {
        return _data.Count;
    }
    public float GetCellViewSize (EnhancedScroller scroller, int dataIndex) {
        return 200f;
    }
    public EnhancedScrollerCellView GetCellView (EnhancedScroller scroller, int dataIndex, int cellIndex) {
        CompanyTradeListCellView cellView = scroller.GetCellView (cellPrefab) as
        CompanyTradeListCellView;
        cellView.SetData (_data[dataIndex]);
        return cellView;
    }
}