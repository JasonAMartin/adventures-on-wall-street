using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{

	/// <summary>
	/// FieldInfo utilities.
	/// </summary>
	public static class FieldInfoUtils
	{

		/// <summary>
		/// Determines if the field is savable.
		/// </summary>
		/// <returns><c>true</c> if is savable the specified field; otherwise, <c>false</c>.</returns>
		/// <param name="field">Field.</param>
		public static bool IsSavable ( this FieldInfo field )
		{
			if ( Attribute.IsDefined ( field, typeof ( NonSavable ) ) )
			{
				return false;
			}
			if ( Attribute.IsDefined ( field, typeof ( Savable ) ) )
			{
				return true;
			}
			return !Attribute.IsDefined ( field, typeof ( ObsoleteAttribute ) ) &&
			!field.IsInitOnly && !field.IsLiteral && !field.IsNotSerialized;
		}

	}

}