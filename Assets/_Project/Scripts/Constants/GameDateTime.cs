using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GameDateTime", menuName = "AdventuresOnWallStreet/GameDateTime", order = 29)]

public class GameDateTime : ScriptableObject {
	public int startingMonth = 1;
	public int startingDay = 1;
	public int startingYear = 1984;

	public int currentMonth = 1;
	public int currentDay = 1;
	public int currentYear = 1984;

	public enum monthNames { JANUARY, FEBRUARY, MARCH, APRIL, MAY, JUNE, JULY, AUGUST, SEPTEMBER, OCTOBER, NOVEMBER, DECEMBER };

	public Dictionary<int, monthNames> monthMap = new Dictionary<int, monthNames> () { { 1, monthNames.JANUARY }, { 2, monthNames.FEBRUARY }, { 3, monthNames.MARCH }, { 4, monthNames.APRIL }, { 5, monthNames.MAY }, { 6, monthNames.JUNE }, { 7, monthNames.JULY }, { 8, monthNames.AUGUST }, { 9, monthNames.SEPTEMBER }, { 10, monthNames.OCTOBER }, { 11, monthNames.NOVEMBER }, { 12, monthNames.DECEMBER }
	};

	public Dictionary<monthNames, int> maxMonthDays = new Dictionary<monthNames, int> () { { monthNames.JANUARY, 31 }, { monthNames.FEBRUARY, 28 }, { monthNames.MARCH, 31 }, { monthNames.APRIL, 30 }, { monthNames.MAY, 31 }, { monthNames.JUNE, 30 }, { monthNames.JULY, 31 }, { monthNames.AUGUST, 31 }, { monthNames.SEPTEMBER, 30 }, { monthNames.OCTOBER, 31 }, { monthNames.NOVEMBER, 30 }, { monthNames.DECEMBER, 31 },
	};

	public void NextDay () {
		int nextDay = currentDay + 1;
		int nextMonth = currentMonth + 1;
		Debug.Log ("Keys: " + currentMonth + " map len " + monthMap.Count);
		monthNames currentMonthName = monthMap[currentMonth];
		int lastMonthDay = maxMonthDays[currentMonthName];
		Debug.Log ("LMD: " + lastMonthDay + " nextDay: " + nextDay);
		if (lastMonthDay <= nextDay) {
			// go to next month
			currentDay = 1;

			if (nextMonth > 12) {
				// new year + JAN
				// setting Jan 1 of new year
				currentMonth = 1;
				currentYear++;
			} else {
				currentMonth = nextMonth;
			}
		} else {
			// next day is ok and in same month
			currentDay++;
		}
	}
}