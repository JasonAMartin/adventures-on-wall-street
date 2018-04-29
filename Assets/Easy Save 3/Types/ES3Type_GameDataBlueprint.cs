using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("ceoLevel", "ceoList", "companyList", "npcList", "gameDifficulty", "daysPlayed", "gameSaveFile", "currentGameSegment", "gameDateTime", "player", "transactionHistory")]
	public class ES3Type_GameDataBlueprint : ES3ObjectType
	{
		public static ES3Type Instance = null;

		public ES3Type_GameDataBlueprint() : base(typeof(GameDataBlueprint)){ Instance = this; }

		protected override void WriteObject(object obj, ES3Writer writer)
		{
			var instance = (GameDataBlueprint)obj;

// 			writer.WritePropertyByRef("ceoLevel", instance.ceoLevel);
// 			writer.WriteProperty("ceoList", instance.ceoList);
// 			writer.WriteProperty("companyList", instance.companyList);
// 			writer.WriteProperty("npcList", instance.npcList);
// 			writer.WritePropertyByRef("gameDifficulty", instance.gameDifficulty);
// 			writer.WriteProperty("daysPlayed", instance.daysPlayed, ES3Type_int.Instance);
// 			writer.WriteProperty("gameSaveFile", instance.gameSaveFile, ES3Type_string.Instance);
// 			writer.WriteProperty("currentGameSegment", instance.currentGameSegment);
// 			writer.WritePropertyByRef("gameDateTime", instance.gameDateTime);
// 			writer.WritePropertyByRef("player", instance.player);
// //			writer.WriteProperty("transactionHistory", instance.transactionHistory);
		}

		protected override void ReadObject<T>(ES3Reader reader, object obj)
		{
			var instance = (GameDataBlueprint)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{

					case "ceoLevel":
						instance.ceoLevel = reader.Read<CEOLevel>();
						break;
					case "ceoList":
						instance.ceoList = reader.Read<System.Collections.Generic.List<CEO>>();
						break;
					case "companyList":
						instance.companyList = reader.Read<System.Collections.Generic.List<Company>>();
						break;
					case "npcList":
						instance.npcList = reader.Read<System.Collections.Generic.List<NPC>>();
						break;
					case "gameDifficulty":
						instance.gameDifficulty = reader.Read<GameDifficulty>();
						break;
					case "daysPlayed":
						instance.daysPlayed = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "gameSaveFile":
						instance.gameSaveFile = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "currentGameSegment":
						instance.currentGameSegment = reader.Read<GameDataBlueprint.GameSegments>();
						break;
					case "gameDateTime":
						instance.gameDateTime = reader.Read<GameDateTime>();
						break;
					case "player":
						instance.player = reader.Read<Player>();
						break;
					case "transactionHistory":
//						instance.transactionHistory = reader.Read<System.Collections.Generic.List<Transaction>>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}

		protected override object ReadObject<T>(ES3Reader reader)
		{
			var instance = new GameDataBlueprint();
			ReadObject<T>(reader, instance);
			return instance;
		}
	}

	public class ES3Type_GameDataBlueprintArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_GameDataBlueprintArray() : base(typeof(GameDataBlueprint[]), ES3Type_GameDataBlueprint.Instance)
		{
			Instance = this;
		}
	}
}