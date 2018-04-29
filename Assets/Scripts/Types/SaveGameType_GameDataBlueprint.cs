using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type GameDataBlueprint serialization implementation.
	/// </summary>
	public class SaveGameType_GameDataBlueprint : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( GameDataBlueprint );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			GameDataBlueprint gameDataBlueprint = ( GameDataBlueprint )value;
			Debug.Log("CEO LIST: " +  gameDataBlueprint.companyList.Count);
			writer.WriteProperty ( "ceoLevel", gameDataBlueprint.ceoLevel );
			writer.WriteProperty ( "ceoList", gameDataBlueprint.ceoList );
			writer.WriteProperty ( "companyList", gameDataBlueprint.companyList );
			writer.WriteProperty ( "npcList", gameDataBlueprint.npcList );
			writer.WriteProperty ( "gameDifficulty", gameDataBlueprint.gameDifficulty );
			writer.WriteProperty ( "daysPlayed", gameDataBlueprint.daysPlayed );
			writer.WriteProperty ( "gameSaveFile", gameDataBlueprint.gameSaveFile );
			writer.WriteProperty ( "currentGameSegment", gameDataBlueprint.currentGameSegment );
			writer.WriteProperty ( "gameDateTime", gameDataBlueprint.gameDateTime );
			writer.WriteProperty ( "player", gameDataBlueprint.player );
			writer.WriteProperty ( "transactionHistory", gameDataBlueprint.transactionHistory );
			// writer.WriteProperty ( "GameDateTime", gameDataBlueprint.GameDateTime );
			// writer.WriteProperty ( "CEOLevel", gameDataBlueprint.CEOLevel );
			// writer.WriteProperty ( "Player", gameDataBlueprint.Player );
			// writer.WriteProperty ( "CEOList", gameDataBlueprint.CEOList );
			// writer.WriteProperty ( "CompanyList", gameDataBlueprint.CompanyList );
			// writer.WriteProperty ( "NPCList", gameDataBlueprint.NPCList );
			// writer.WriteProperty ( "GameDifficulty", gameDataBlueprint.GameDifficulty );
			// writer.WriteProperty ( "DaysPlayed", gameDataBlueprint.DaysPlayed );
			// writer.WriteProperty ( "GameSaveFile", gameDataBlueprint.GameSaveFile );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			GameDataBlueprint gameDataBlueprint = new GameDataBlueprint ();
			ReadInto ( gameDataBlueprint, reader );
			return gameDataBlueprint;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			GameDataBlueprint gameDataBlueprint = ( GameDataBlueprint )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "ceoLevel":
						if ( gameDataBlueprint.ceoLevel == null )
						{
							gameDataBlueprint.ceoLevel = reader.ReadProperty<CEOLevel> ();
						}
						else
						{
							reader.ReadIntoProperty<CEOLevel> ( gameDataBlueprint.ceoLevel );
						}
						break;
					case "ceoList":
						gameDataBlueprint.ceoList = reader.ReadProperty<System.Collections.Generic.List<CEO>> ();
						break;
					case "companyList":
						gameDataBlueprint.companyList = reader.ReadProperty<System.Collections.Generic.List<Company>> ();
						break;
					case "npcList":
						gameDataBlueprint.npcList = reader.ReadProperty<System.Collections.Generic.List<NPC>> ();
						break;
					case "gameDifficulty":
						if ( gameDataBlueprint.gameDifficulty == null )
						{
							gameDataBlueprint.gameDifficulty = reader.ReadProperty<GameDifficulty> ();
						}
						else
						{
							reader.ReadIntoProperty<GameDifficulty> ( gameDataBlueprint.gameDifficulty );
						}
						break;
					case "daysPlayed":
						gameDataBlueprint.daysPlayed = reader.ReadProperty<System.Int32> ();
						break;
					case "gameSaveFile":
						gameDataBlueprint.gameSaveFile = reader.ReadProperty<System.String> ();
						break;
					case "currentGameSegment":
						gameDataBlueprint.currentGameSegment = reader.ReadProperty<GameDataBlueprint.GameSegments> ();
						break;
					case "gameDateTime":
						if ( gameDataBlueprint.gameDateTime == null )
						{
							gameDataBlueprint.gameDateTime = reader.ReadProperty<GameDateTime> ();
						}
						else
						{
							reader.ReadIntoProperty<GameDateTime> ( gameDataBlueprint.gameDateTime );
						}
						break;
					case "player":
						if ( gameDataBlueprint.player == null )
						{
							gameDataBlueprint.player = reader.ReadProperty<Player> ();
						}
						else
						{
							reader.ReadIntoProperty<Player> ( gameDataBlueprint.player );
						}
						break;
					case "transactionHistory":
						gameDataBlueprint.transactionHistory = reader.ReadProperty<System.Collections.Generic.List<Transaction>> ();
						break;
					case "GameDateTime":
						if ( gameDataBlueprint.GameDateTime == null )
						{
							gameDataBlueprint.GameDateTime = reader.ReadProperty<GameDateTime> ();
						}
						else
						{
							reader.ReadIntoProperty<GameDateTime> ( gameDataBlueprint.GameDateTime );
						}
						break;
					case "CEOLevel":
						if ( gameDataBlueprint.CEOLevel == null )
						{
							gameDataBlueprint.CEOLevel = reader.ReadProperty<CEOLevel> ();
						}
						else
						{
							reader.ReadIntoProperty<CEOLevel> ( gameDataBlueprint.CEOLevel );
						}
						break;
					case "Player":
						if ( gameDataBlueprint.Player == null )
						{
							gameDataBlueprint.Player = reader.ReadProperty<Player> ();
						}
						else
						{
							reader.ReadIntoProperty<Player> ( gameDataBlueprint.Player );
						}
						break;
					case "CEOList":
						gameDataBlueprint.CEOList = reader.ReadProperty<System.Collections.Generic.List<CEO>> ();
						break;
					case "CompanyList":
						gameDataBlueprint.CompanyList = reader.ReadProperty<System.Collections.Generic.List<Company>> ();
						break;
					case "NPCList":
						gameDataBlueprint.NPCList = reader.ReadProperty<System.Collections.Generic.List<NPC>> ();
						break;
					case "GameDifficulty":
						if ( gameDataBlueprint.GameDifficulty == null )
						{
							gameDataBlueprint.GameDifficulty = reader.ReadProperty<GameDifficulty> ();
						}
						else
						{
							reader.ReadIntoProperty<GameDifficulty> ( gameDataBlueprint.GameDifficulty );
						}
						break;
					case "DaysPlayed":
						gameDataBlueprint.DaysPlayed = reader.ReadProperty<System.Int32> ();
						break;
					case "GameSaveFile":
						gameDataBlueprint.GameSaveFile = reader.ReadProperty<System.String> ();
						break;
				}
			}
		}

	}

}