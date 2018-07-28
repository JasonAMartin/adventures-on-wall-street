using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransactionOptionsList", menuName = "AdventuresOnWallStreet/TransactionOptionsList", order = 19)]

public class TransactionOptionsList : ScriptableObject {
	public List<Transaction> transactionOption = new List<Transaction>();
}
