using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class BuildCEOS
{
    [MenuItem("Assets/Create/Build Tools/BuildCEOS")]
    public static void Create()
    {
     string buildDirectory = "Assets/Build/CEOs";

        // TODO - need to clean out directory each run (make it optional?)
        // first delete files in directory
        //  FileUtil.DeleteFileOrDirectory(buildDirectory);

        // ---- start script ----

        // create List of Gender
        List<Gender> genders = new List<Gender>();

        // create list of CEO levels
        List<CEOLevel> ceoLevels = new List<CEOLevel>();

        // find assets
        string[] guidsGender = AssetDatabase.FindAssets("t:gender", null);
        string[] guidsCEOLevel = AssetDatabase.FindAssets("t:ceolevel", null);

        // populate lists
        foreach (string guid in guidsGender)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            genders.Add(AssetDatabase.LoadAssetAtPath<Gender>(path));
        }

        foreach (string guid in guidsCEOLevel)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ceoLevels.Add(AssetDatabase.LoadAssetAtPath<CEOLevel>(path));
        }

        // pick random items
        int currentGender = Random.Range(0, genders.Count);
        int currentCEOLevel = Random.Range(0, ceoLevels.Count);

        // Create CEO Asset
        CEO asset = ScriptableObject.CreateInstance<CEO>();
        asset.firstName = "Jason";
        asset.lastName = "Martin";
        asset.gender = genders[currentGender];
        asset.ceoLevel = ceoLevels[currentCEOLevel];
        AssetDatabase.CreateAsset(asset, buildDirectory + "/" + asset.firstName + asset.lastName + ".asset");

        // Save Asset
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

}