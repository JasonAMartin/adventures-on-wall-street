using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace BayatGames.SaveGamePro.Reflection
{
	
	/// <summary>
	/// Type utilities.
	/// </summary>
	public static class TypeUtils
	{

		/// <summary>
		/// The savable binding flags.
		/// </summary>
		public const BindingFlags SavableBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		/// <summary>
		/// Determines if the type is savable.
		/// </summary>
		/// <returns><c>true</c> if is savable the specified type; otherwise, <c>false</c>.</returns>
		/// <param name="type">Type.</param>
		public static bool IsSavable ( this Type type )
		{
			List<FieldInfo> fields = type.GetSavableFields ();
			List<PropertyInfo> properties = type.GetSavableProperties ();
			return !type.IsInterface &&
			( fields.Count > 0 || properties.Count > 0 ) &&
			!Attribute.IsDefined ( type, typeof ( ObsoleteAttribute ) );
		}

		/// <summary>
		/// Gets the savable field.
		/// </summary>
		/// <returns>The savable field.</returns>
		/// <param name="type">Type.</param>
		/// <param name="name">Name.</param>
		public static FieldInfo GetSavableField ( this Type type, string name )
		{
			FieldInfo field = type.GetField ( name, TypeUtils.SavableBindingFlags );
			return field != null && field.IsSavable () ? field : null;
		}

		/// <summary>
		/// Gets the savable property.
		/// </summary>
		/// <returns>The savable property.</returns>
		/// <param name="type">Type.</param>
		/// <param name="name">Name.</param>
		public static PropertyInfo GetSavableProperty ( this Type type, string name )
		{
			PropertyInfo property = type.GetProperty ( name, TypeUtils.SavableBindingFlags );
			return property != null && property.IsSavable () ? property : null;
		}

		/// <summary>
		/// Gets the savable fields.
		/// </summary>
		/// <returns>The savable fields.</returns>
		/// <param name="type">Type.</param>
		public static List<FieldInfo> GetSavableFields ( this Type type )
		{
			FieldInfo [] fields = type.GetFields ( TypeUtils.SavableBindingFlags );
			List<FieldInfo> savableFields = new List<FieldInfo> ();
			for ( int i = 0; i < fields.Length; i++ )
			{
				FieldInfo field = fields [ i ];
				if ( field.IsSavable () )
				{
					savableFields.Add ( field );
				}
			}
			return savableFields;
		}

		/// <summary>
		/// Gets the savable properties.
		/// </summary>
		/// <returns>The savable properties.</returns>
		/// <param name="type">Type.</param>
		public static List<PropertyInfo> GetSavableProperties ( this Type type )
		{
			PropertyInfo [] properties = type.GetProperties ( TypeUtils.SavableBindingFlags );
			List<PropertyInfo> savableProperties = new List<PropertyInfo> ();
			for ( int i = 0; i < properties.Length; i++ )
			{
				PropertyInfo property = properties [ i ];
				if ( property.IsSavable () )
				{
					savableProperties.Add ( property );
				}
			}
			return savableProperties;
		}

		/// <summary>
		/// Gets the friendly name of the type.
		/// </summary>
		/// <returns>The friendly name.</returns>
		/// <param name="type">Type.</param>
		public static string GetFriendlyName ( this Type type )
		{
			string name = type.FullName;
			if ( type.IsGenericType )
			{
				name = type.FullName.Split ( '`' ) [ 0 ] + "<" + string.Join ( 
					", ",
					type.GetGenericArguments ().Select ( x => x.GetFriendlyName () ).ToArray () ) + ">";
			}
			else
			{
				name = type.FullName;
			}
			name = name.Replace ( "+", "." );
			return name;
		}

		/// <summary>
		/// Gets the default value of the type.
		/// </summary>
		/// <returns>The default.</returns>
		/// <param name="type">Type.</param>
		public static object GetDefault ( this Type type )
		{
			if ( type.IsValueType )
			{
				return Activator.CreateInstance ( type );
			}
			return null;
		}
		
	}

}