using UnityEngine;
using UnityEditor;
using System.Collections;

[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
public sealed class ES2Editor_Vector3 : ES2EditorType
{
	public ES2Editor_Vector3() : base(typeof(Vector3))
	{
		key = (byte)11;
	}

	public override object DisplayGUI(object data)
	{
		return EditorGUILayout.Vector3Field("", (Vector3)data);
	}
}