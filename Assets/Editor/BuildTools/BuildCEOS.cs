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
        // TODO - need to make many CEOs (any way to select # to make?)
        // first delete files in directory
        //  FileUtil.DeleteFileOrDirectory(buildDirectory);

        // ---- start script ----

        // Read from text file for random items

        // Setup Lists
        List<string> firstNamesMale = new List<string>();
        List<string> firstNamesFemale = new List<string>();
        List<string> lastNames = new List<string>();

        // Get Text Data
        firstNamesMale = new List<string>(System.IO.File.ReadAllLines("Assets\\SeedData\\PeopleNames\\FirstNames-Male.txt"));
        firstNamesFemale = new List<string>(System.IO.File.ReadAllLines("Assets\\SeedData\\PeopleNames\\FirstNames-Female.txt"));
        lastNames = new List<string>(System.IO.File.ReadAllLines("Assets\\SeedData\\PeopleNames\\LastNames.txt"));

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
        int currentFirstNameMale = Random.Range(0, firstNamesMale.Count);
        int currentFirstNameFemale = Random.Range(0, firstNamesFemale.Count);
        int currentLastName = Random.Range(0, lastNames.Count);

        // Create CEO Asset
        CEO asset = ScriptableObject.CreateInstance<CEO>();
        // is this CEO male or female?
        if (genders[currentGender].name == "MALE")
        {
            asset.firstName = firstNamesMale[currentFirstNameMale];
        } else
        {
            asset.firstName = firstNamesFemale[currentFirstNameFemale];
        }
        asset.lastName = lastNames[currentLastName];
        asset.gender = genders[currentGender];
        asset.ceoLevel = ceoLevels[currentCEOLevel];
        AssetDatabase.CreateAsset(asset, buildDirectory + "/CEO-" + asset.firstName + "-" + asset.lastName + ".asset");

        // Save Asset
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

    }

}