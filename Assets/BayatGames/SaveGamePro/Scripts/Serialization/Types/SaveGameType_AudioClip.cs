using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BayatGames.SaveGamePro.Serialization.Types
{

	/// <summary>
	/// Save Game Type AudioClip serialization implementation.
	/// </summary>
	public class SaveGameType_AudioClip : SaveGameType
	{

		/// <summary>
		/// Gets the associated type for this custom type.
		/// </summary>
		/// <value>The type of the associated.</value>
		public override Type AssociatedType
		{
			get
			{
				return typeof ( UnityEngine.AudioClip );
			}
		}

		/// <summary>
		/// Write the specified value using the writer.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="writer">Writer.</param>
		public override void Write ( object value, ISaveGameWriter writer )
		{
			UnityEngine.AudioClip audioClip = ( UnityEngine.AudioClip )value;
			float [] data = new float[audioClip.samples];
			audioClip.GetData ( data, 0 );
			writer.WriteProperty ( "data", data );
			writer.WriteProperty ( "name", audioClip.name );
			writer.WriteProperty ( "hideFlags", audioClip.hideFlags );
		}

		/// <summary>
		/// Read the data using the reader.
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override object Read ( ISaveGameReader reader )
		{
			UnityEngine.AudioClip audioClip = new UnityEngine.AudioClip ();
			ReadInto ( audioClip, reader );
			return audioClip;
		}

		/// <summary>
		/// Read the data into the specified value.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <param name="reader">Reader.</param>
		public override void ReadInto ( object value, ISaveGameReader reader )
		{
			UnityEngine.AudioClip audioClip = ( UnityEngine.AudioClip )value;
			foreach ( string property in reader.Properties )
			{
				switch ( property )
				{
					case "data":
						audioClip.SetData ( reader.ReadProperty<float []> (), 0 );
						break;
					case "name":
						audioClip.name = reader.ReadProperty<System.String> ();
						break;
					case "hideFlags":
						audioClip.hideFlags = reader.ReadProperty<UnityEngine.HideFlags> ();
						break;
				}
			}
		}
		
	}

}