using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
			writer.WriteProperty ( "ceoLevel", gameDataBlueprint.ceoLevel );
			writer.WriteProperty ( "ceoList", gameDataBlueprint.ceoList );
			writer.WriteProperty ( "companyList", gameDataBlueprint.companyList );
			writer.WriteProperty ( "npcList", gameDataBlueprint.npcList );
			writer.WriteProperty ( "gameDifficulty", gameDataBlueprint.gameDifficulty );
			writer.WriteProperty ( "daysPlayed", gameDataBlueprint.daysPlayed );
			writer.WriteProperty ( "player", gameDataBlueprint.player);
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

                    case "player":
                        if (gameDataBlueprint.player == null)
                        {
                            gameDataBlueprint.player = reader.ReadProperty<Player>();
                        }
                        else
                        {
                            reader.ReadIntoProperty<Player>(gameDataBlueprint.player);
                        }
                        break;
				}
			}
		}
		
	}

}