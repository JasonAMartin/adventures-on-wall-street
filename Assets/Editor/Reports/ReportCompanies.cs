using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;
public class ReportCompanies
{
    [MenuItem("Assets/Create/Report Tools/ReportCompanies")]
    public static void Create()
    {
        // TODO:
        /*
         * 1. Report # of companies
         * 2. Report # of company types
         * 3. Report # of companies per company type
         * 4. Report pass/fail for counts, like 10 companies per type and so forth
         * 5. Report if all companies pass stock ticker check (no dupes)
         * 6. Report if all companies have company description.
         * 7. Report if all companies have stock sticker.
         * 8. Report if all companies have company name.
         * 9. Report if at least 20 companies have 0 as earliest date.
         * 10. Report if at least 5 companies have 10 as earliest date.
         * 11. Report if any company has more than 999 as earliest date (should be 1).
         * 12. Report if any company has CanBeUsed as false.
         * 13. Report if any company has Went Bankrupt as false.
         * 14. Report if any company has IsBeingUsed as false.
         * 15. Report if any company has assigned CEO (should be 1)
         * 16. Report if any company is missing company type.
         * 17. Report # of stock price starting points (thinking levels like Level0 = 0-10, Level1 = 11-50, etc).
         * 18. Report # of companies per stock price levels.
         * 19. Report if a company doesn't have a stock price level.
         * 20. Report on desired breakdown of levels (unknown right now), such as 30 companies level0, 20 companies level1 and so forth.
         */

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
