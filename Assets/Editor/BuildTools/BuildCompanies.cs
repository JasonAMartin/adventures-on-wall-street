using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

[System.Serializable]
public struct CompanyJSON
{
    public string companyName;
    public string stockSymbol;
    public string companyType;
    public int stockPrice;
    public int earliestStartDay;
    public string companyDescription;
}

public class BuildCompanies
{
    [MenuItem("Assets/Create/Build Tools/BuildCompanies")]
    public static void Create()
    {

        // TODO add company strength as well. If it's NULL, leave alone, otherwise add the SO

        string buildDirectory = "Assets/_Project/Scripts/ScriptableObjects/Company";

        string dataAsJson = File.ReadAllText("Assets\\_Project\\SeedData\\Companies\\companies.json");
        CompanyJSON[] companies = JSONHelper.getJsonArray<CompanyJSON>(dataAsJson);
        string[] companyTypesGUID = AssetDatabase.FindAssets("t:companytype", null);
        List<CompanyType> companyTypes = new List<CompanyType>();

        // populate company types list
        foreach (string guid in companyTypesGUID)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            companyTypes.Add(AssetDatabase.LoadAssetAtPath<CompanyType>(path));
        }

        foreach (CompanyJSON company in companies)
        {
            Company companySO = ScriptableObject.CreateInstance<Company>();
            companySO.companyName = company.companyName;
            companySO.stockSymbol = company.stockSymbol;
            companySO.stockPrice = company.stockPrice;
            companySO.earliestStartingDay = company.earliestStartDay;
            companySO.companyDescription = company.companyDescription;


            // find company type
            foreach (CompanyType cType in companyTypes)
            {
                if (cType.companyType == company.companyType) companySO.companyType = cType;
            }

            AssetDatabase.CreateAsset(companySO, buildDirectory + "/Company-" + companySO.companyName.Replace(" ","") + ".asset");

            // Save Asset
            AssetDatabase.SaveAssets();
        }

        Debug.Log("COMPLETED! Built " + companies.Length + " Companies.");
    }
}