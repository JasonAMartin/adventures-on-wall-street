using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

public class ReportCEOs
{
    [MenuItem("Assets/Create/Report Tools/ReportCEOs")]
    public static void Create()
    {        

        // create List of CEOs
        List<CEO> ceos = new List<CEO>();

        // find assets
        string[] guids = AssetDatabase.FindAssets("t:ceo", null);

        // populate lists
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ceos.Add(AssetDatabase.LoadAssetAtPath<CEO>(path));
        }

        // get counts
        var maleResults = ceos.Where(o => o.gender.name == "MALE");
        var femaleResults = ceos.Where(o => o.gender.name == "FEMALE");
        var greatResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelGreat");
        var goodResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelGood");
        var averageResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelAverage");
        var mediocreResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelMediocre");
        var terribleResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelTerrible");

        Debug.Log("TOTAL CEOS: " + ceos.Count);
        Debug.Log("MALE CEOS: " + maleResults.Count());
        Debug.Log("FEMALE CEOS: " + femaleResults.Count());
        Debug.Log("------ SKILL BREAKDOWN -----");
        Debug.Log("GREAT: " + greatResults.Count());
        Debug.Log("GOOD: " + goodResults.Count());
        Debug.Log("AVERAGE: " + averageResults.Count());
        Debug.Log("MEDIOCRE: " + mediocreResults.Count());
        Debug.Log("TERRIBLE: " + terribleResults.Count());
        // EditorUtility.FocusProjectWindow();
        // Selection.activeObject = asset;

    }

}