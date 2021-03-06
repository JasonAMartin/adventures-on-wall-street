using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ES3Types
{
	internal class ES3ReflectedComponentType : ES3ComponentType
	{
		public ES3ReflectedComponentType(Type type) : base(type)
		{
			this.type = type;
			this.isValueType = false;
			isReflectedType = true;
			GetMembers(true);
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			WriteProperties(obj, writer);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			ReadProperties(reader, obj);
		}
	}
}