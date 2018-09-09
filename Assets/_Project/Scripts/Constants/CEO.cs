using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "CEO", menuName = "AdventuresOnWallStreet/CEO", order = 7)]
public class CEO : ScriptableObject {
    public string firstName;
    public string lastName;
    public Gender gender;
    public CEOLevel ceoLevel;
    public bool isEmployed = false;
    public Company employedBy;
    public List<Company> employmentHistory; // ideally make this more, like company + time, etc.
    public int employmentTermCapacity; // how many turns this CEO is willing to be employed for
    public int employedTurns; // how many turns this CEO has been employed with current company

    public void SetInitialEmploymentCapacity (Company company) {
        // TODO: Need to consider company strength in the formula for setting term capacity!!
        int minDays = ceoLevel.employmentDaysMinimum;
        int maxDays = ceoLevel.employmentDaysMaximum;
        System.Random rnd = new System.Random ();
        int diceRoll = rnd.Next (minDays, maxDays);
        employmentTermCapacity = diceRoll;
    }

    public void ResetInitialEmployementCapacity () {
        employmentTermCapacity = 0;
    }

    public void AddEmploymentTurn () {
        employedTurns++;
    }

    public void UpdateEmploymentTermCapacity (Company company) {
        System.Random rnd = new System.Random ();

        // whatever
        int canBePositive = company.companyStrength.chanceToAffectCEOPositve;
        int canBeNegative = company.companyStrength.chanceToAffectCEONegative;

        if (canBePositive > 0) {
            int positiveDice = rnd.Next (1, 100);
            if (positiveDice <= canBePositive) {
                employmentTermCapacity++;
                Debug.Log ("Adding Employment Turn for: " + firstName + " " + lastName);
            }
        }
        if (canBeNegative > 0) {
            int negativeDice = rnd.Next (1, 100);
            if (negativeDice <= canBeNegative) {
                employmentTermCapacity--;
                Debug.Log ("Removing Employment Turn for: " + firstName + " " + lastName);
            }
        }
    }

    public bool IsQuitting () {
        return (employmentTermCapacity >= employedTurns);
    }

    public void SpecialUpdateToEmploymentCapacity (int modifiedTurns) {
        if (modifiedTurns > 0) employmentTermCapacity += modifiedTurns;
        if (modifiedTurns < 0) employmentTermCapacity += modifiedTurns;
    }
}