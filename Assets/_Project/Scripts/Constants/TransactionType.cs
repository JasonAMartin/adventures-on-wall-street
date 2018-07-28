using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TransactionType", menuName = "AdventuresOnWallStreet/TransactionType", order = 9)]
public class TransactionType : ScriptableObject {
	public float transactionCost = 0.01f; // default stock cost
	public float liquidationCost = 0.10f; // detault goods cost

	public GoodsType goodsType;
}
