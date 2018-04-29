using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Transaction", menuName = "AdventuresOnWallStreet/Transaction", order = 9)]
public class Transaction : ScriptableObject {
	public int transactionTurn;
	public int quantity;
	public int pricePerItem;
	public int totalAmount;

	public enum ActionType { BUY, SELL };

	public ActionType actionType;
	public TransactionType transactionType; // name, transaction fee, liquidation cost

	public bool isComplete = false; // set to true when no more actions can take place, such as stock being sold, item being sold, etc

 public void SetTotal () {
	// TODO: finish after TT is done.
	int transactionCost = (int)((quantity * pricePerItem) * transactionType.transactionCost);
	if (actionType == ActionType.BUY) {
		totalAmount = (quantity * pricePerItem) + transactionCost;
	}

	if (actionType == ActionType.SELL) {
		totalAmount = (int)(quantity * transactionType.liquidationCost) - transactionCost;
	}
 }
}