using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Linq;

public class CompanyTypeReport
{
    public CompanyType companyType;
    public int amount;
}

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
         * 7. Report if all companies have stock ticker.
         * 8. Report if all companies have company name.
         * 9. Report if at least 20 companies have 0 as earliest date.
         * 10. Report if at least 5 companies have 10 as earliest date.
         * 11. Report if any company has more than 999 as earliest date (should be 1).
         * 12. Report if any company has CanBeUsed as false.
         * 13. Report if any company has Went Bankrupt as false.
         * 14. Report if any company has IsBeingUsed as false.
         * 15. Report if any company has assigned CEO (should be 1)
         * 16. Report if any company is missing company type.
         >>* 17. Report # of stock price starting points (thinking levels like Level0 = 0-10, Level1 = 11-50, etc).
         * 18. Report # of companies per stock price levels.
         * 19. Report if a company doesn't have a stock price level.
         * 20. Report on desired breakdown of levels (unknown right now), such as 30 companies level0, 20 companies level1 and so forth.
         */

        // create List of CEOs
        List<Company> companies = new List<Company>();
        List<CompanyType> companyTypes = new List<CompanyType>();
        List<CompanyTypeReport> companyTypeReports = new List<CompanyTypeReport>();
        int zeroStartDate = 0;
        int tenStartDate = 0;
        int maxStartDate = 0;

        // find assets
        string[] guids = AssetDatabase.FindAssets("t:company", null);
        string[] guids2 = AssetDatabase.FindAssets("t:companytype", null);

        // populate lists
        foreach (string guid in guids2)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            companyTypes.Add(AssetDatabase.LoadAssetAtPath<CompanyType>(path));
            // add company type to report
            CompanyTypeReport ctr = new CompanyTypeReport();
            ctr.companyType = AssetDatabase.LoadAssetAtPath<CompanyType>(path);
            ctr.amount = 0;
            companyTypeReports.Add(ctr);
        }

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Company currentCompany = AssetDatabase.LoadAssetAtPath<Company>(path);
            companies.Add(currentCompany);

            // check company type and ++
            var cReport = companyTypeReports.Find(r => r.companyType == currentCompany.companyType);
            cReport.amount = cReport.amount + 1;

            if (currentCompany.earliestStartingDay == 0) zeroStartDate = zeroStartDate + 1;
            if (currentCompany.earliestStartingDay == 10) tenStartDate = tenStartDate + 1;
            if (currentCompany.earliestStartingDay == 999) maxStartDate = maxStartDate + 1;

        }

        // get counts
        //var maleResults = ceos.Where(o => o.gender.name == "MALE");
        //var femaleResults = ceos.Where(o => o.gender.name == "FEMALE");
        //var greatResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelGreat");
        //var goodResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelGood");
        //var averageResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelAverage");
        //var mediocreResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelMediocre");
        //var terribleResults = ceos.Where(o => o.ceoLevel.name == "CEOLevelTerrible");

        // Report
        Debug.Log("TOTAL CEOS: " + companies.Count);
        Debug.Log("TOTAL COMPANY TYPES: " + companyTypes.Count);

        // Report Company Types & Counts
        foreach (CompanyTypeReport report in companyTypeReports)
        {
           Debug.Log("COMPANY TYPE: " + report.companyType + " > COUNT : " + report.amount);
            if (report.amount >= report.companyType.minimumRequired)
            {
                Debug.Log("SUCCESS! PASSED>> :: " + report.companyType);
            } else
            {
                Debug.LogError("FAIL: Company Type Amount -> " + report.companyType + " " + report.amount + " out of " + report.companyType.minimumRequired + " required.");
            }
            Debug.Log("------------------------------------");
        }

        // Stock ticker check, description check
        foreach (Company c in companies)
        {
            var tickerResults = companies.Where(o => o.stockSymbol == c.stockSymbol);
            if (tickerResults.Count() > 1)
            {
                Debug.LogError("FAIL: Duplicate stock symbol with symbol: " + c.stockSymbol + " :: " + c.companyName);
            }

            if (c.companyDescription.Length < 10)
            {
                Debug.LogError("FAIL: Missing description for company -> " + c.companyName);
            }

            if (c.stockSymbol.Length < 1)
            {
                Debug.LogError("FAIL: Missing stock ticker for company -> " + c.companyName);
            }

            if (c.companyName.Length < 3)
            {
                Debug.LogError("FAIL: Missing name for company -> " + c.companyName);
            }

            if (!c.canBeUsed) Debug.LogError("FAIL: canBeUsed is set to false for company -> " + c.companyName);
            if (c.wentBankrupt) Debug.LogError("FAIL: wentBankrupt is set to true for company -> " + c.companyName);
            if (c.isBeingUsed) Debug.LogError("FAIL: isBeingUsed is set to true for company -> " + c.companyName);
            if (c.ceo != null) Debug.LogError("FAIL: Company has assigned CEO! Company: " + c.companyName);
            if (c.companyType == null) Debug.LogError("FAIL: Company doesn't have a type! Company: " + c.companyName);
        }

        // Report on Start Dates

        if (zeroStartDate < 20) Debug.LogError("FAIL: Fewer than 20 companies can start game.");
        if (tenStartDate < 10) Debug.LogError("FAIL: Fewer than 10 companies have starting date of 10.");
        if (maxStartDate > 1) Debug.LogError("FAIL: too many companies with max start date.");
    }
}
