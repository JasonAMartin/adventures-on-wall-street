using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TransactionHistory", menuName = "AdventuresOnWallStreet/TransactionHistory", order = 19)]
public class TransactionHistory : ScriptableObject {

	// Used to keep track of transactions player has done.
		public List<Transaction> transactionOption = new List<Transaction>();
}
