using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CEO", menuName = "AdventuresOnWallStreet/CEO", order = 7)]
public class CEO : ScriptableObject {
    public string firstName;
    public string lastName;
    public Gender gender;
    public CEOLevel ceoLevel;
    public bool isEmployed = false;
    public Company employedBy;
    public List<Company> employmentHistory; // ideally make this more, like company + time, etc.
}
