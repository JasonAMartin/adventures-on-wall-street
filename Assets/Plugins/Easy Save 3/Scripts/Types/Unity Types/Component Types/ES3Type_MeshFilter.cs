using System;
using UnityEngine;

namespace ES3Types
{
	[ES3PropertiesAttribute("sharedMesh")]
	public class ES3Type_MeshFilter : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3Type_MeshFilter() : base(typeof(UnityEngine.MeshFilter))
		{
			Instance = this;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.MeshFilter)obj;
			
			writer.WriteProperty("sharedMesh", instance.sharedMesh, ES3Type_Mesh.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.MeshFilter)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "sharedMesh":
						instance.sharedMesh = reader.Read<UnityEngine.Mesh>(ES3Type_Mesh.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}

		public class ES3Type_MeshFilterArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3Type_MeshFilterArray() : base(typeof(UnityEngine.MeshFilter[]), ES3Type_MeshFilter.Instance)
		{
			Instance = this;
		}
	}
}