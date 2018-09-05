using System.Collections.Generic;
using System.Globalization;

namespace Hard_Task_Evaluation.Utilities
{
    public static class NationalitiesHelper
    {
        public static List<string> GetNationalities()
        {
            List<string> CultureList = new List<string>();
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var getCulutre in cultureInfos)
            {
                RegionInfo regionInfo = new RegionInfo(getCulutre.LCID);
                if (!CultureList.Contains(regionInfo.EnglishName))
                {
                    CultureList.Add(regionInfo.EnglishName);
                }
            }
            CultureList.Sort();
            return CultureList;
        }
    }
}