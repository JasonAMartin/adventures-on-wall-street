using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CEO", menuName = "AdventuresOnWallStreet/CEO", order = 7)]
public class CEO : ScriptableObject {
    public string firstName;
    public string lastName;
    public Gender gender;
    public CEOLevel ceoLevel;
}
