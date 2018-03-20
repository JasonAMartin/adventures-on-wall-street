using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{

	/// <summary>
	/// PropertyInfo utilities.
	/// </summary>
	public static class PropertyInfoUtils
	{

		/// <summary>
		/// Determines if the property is savable.
		/// </summary>
		/// <returns><c>true</c> if is savable the specified property; otherwise, <c>false</c>.</returns>
		/// <param name="property">Property.</param>
		public static bool IsSavable ( this PropertyInfo property )
		{
			if ( Attribute.IsDefined ( property, typeof ( NonSavable ) ) )
			{
				return false;
			}
			if ( Attribute.IsDefined ( property, typeof ( Savable ) ) )
			{
				return true;
			}
			return !Attribute.IsDefined ( property, typeof ( ObsoleteAttribute ) ) &&
			property.CanRead && property.CanWrite && property.GetIndexParameters ().Length == 0;
		}

	}

}