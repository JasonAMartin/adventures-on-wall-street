using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class BuildCompanyList
{
    [MenuItem("Assets/Create/Build Tools/BuildCompanyList")]
    public static void Create()
    {
        string buildDirectory = "Assets/_Project/Scripts/ScriptableObjects/Company/List";

        List<Company> companies = new List<Company>();

        string[] allCompanies = AssetDatabase.FindAssets("t:company", null);
 
        
        // populate lists
        foreach (string guid in allCompanies)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            companies.Add(AssetDatabase.LoadAssetAtPath<Company>(path));
        }

        CompanyList asset = ScriptableObject.CreateInstance<CompanyList>();
        asset.companyList = companies;
        AssetDatabase.CreateAsset(asset, buildDirectory + "/companyList.asset");
        AssetDatabase.SaveAssets();
        Debug.Log("Company List Build Completed.");
    }

}