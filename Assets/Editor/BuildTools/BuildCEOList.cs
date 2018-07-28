using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class BuildCEOList
{
    [MenuItem("Assets/Create/Build Tools/BuildCEOSList")]
    public static void Create()
    {
        string buildDirectory = "Assets/_Project/Scripts/ScriptableObjects/CEOs/List";

        List<CEO> ceos = new List<CEO>();

        string[] allCEOs = AssetDatabase.FindAssets("t:ceo", null);
 
        
        // populate lists
        foreach (string guid in allCEOs)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ceos.Add(AssetDatabase.LoadAssetAtPath<CEO>(path));
        }

        CEOList asset = ScriptableObject.CreateInstance<CEOList>();
        asset.ceoList = ceos;
        AssetDatabase.CreateAsset(asset, buildDirectory + "/ceoList.asset");
        AssetDatabase.SaveAssets();
        Debug.Log("CEO List Build Completed.");
    }

}