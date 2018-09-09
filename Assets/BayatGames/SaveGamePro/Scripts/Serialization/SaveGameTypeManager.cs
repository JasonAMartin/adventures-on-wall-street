using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

using BayatGames.SaveGamePro.Serialization.Types;

namespace BayatGames.SaveGamePro.Serialization
{

	/// <summary>
	/// Save Game Type Manager.
	/// Manage custom types using this API.
	/// </summary>
	public static class SaveGameTypeManager
	{

		private static Dictionary<Type, SaveGameType> m_Types;

		/// <summary>
		/// Gets the types.
		/// </summary>
		/// <value>The types.</value>
		public static Dictionary<Type, SaveGameType> Types
		{
			get
			{
				if ( m_Types == null )
				{
					Initialize ();
				}
				return m_Types;
			}
		}

		/// <summary>
		/// Initialize the manager and load all custom types.
		/// </summary>
		[RuntimeInitializeOnLoadMethod ( RuntimeInitializeLoadType.BeforeSceneLoad )]
		private static void Initialize ()
		{
			m_Types = new Dictionary<Type, SaveGameType> ();
			#if (UNITY_WSA || UNITY_WINRT) && !UNITY_EDITOR
			AddType ( typeof ( GameDataBlueprint ), new SaveGameType_GameDataBlueprint () );
			AddType ( typeof ( AnchoredJoint2D ), new SaveGameType_AnchoredJoint2D () );
			AddType ( typeof ( Animation ), new SaveGameType_Animation () );
			AddType ( typeof ( AnimationClip ), new SaveGameType_AnimationClip () );
			AddType ( typeof ( AnimationCurve ), new SaveGameType_AnimationCurve () );
			AddType ( typeof ( AnimationEvent ), new SaveGameType_AnimationEvent () );
			AddType ( typeof ( AnimationState ), new SaveGameType_AnimationState () );
			AddType ( typeof ( AnimationTriggers ), new SaveGameType_AnimationTriggers () );
			AddType ( typeof ( Animator ), new SaveGameType_Animator () );
			AddType ( typeof ( AnimatorControllerParameter ), new SaveGameType_AnimatorControllerParameter () );
			AddType ( typeof ( AnimatorOverrideController ), new SaveGameType_AnimatorOverrideController () );
			AddType ( typeof ( AreaEffector2D ), new SaveGameType_AreaEffector2D () );
			AddType ( typeof ( AspectRatioFitter ), new SaveGameType_AspectRatioFitter () );
			AddType ( typeof ( AudioChorusFilter ), new SaveGameType_AudioChorusFilter () );
			AddType ( typeof ( AudioClip ), new SaveGameType_AudioClip () );
			AddType ( typeof ( AudioConfiguration ), new SaveGameType_AudioConfiguration () );
			AddType ( typeof ( AudioDistortionFilter ), new SaveGameType_AudioDistortionFilter () );
			AddType ( typeof ( AudioEchoFilter ), new SaveGameType_AudioEchoFilter () );
			AddType ( typeof ( AudioHighPassFilter ), new SaveGameType_AudioHighPassFilter () );
			AddType ( typeof ( AudioListener ), new SaveGameType_AudioListener () );
			AddType ( typeof ( AudioLowPassFilter ), new SaveGameType_AudioLowPassFilter () );
			AddType ( typeof ( AudioMixer ), new SaveGameType_AudioMixer () );
			AddType ( typeof ( AudioMixerGroup ), new SaveGameType_AudioMixerGroup () );
			AddType ( typeof ( AudioReverbFilter ), new SaveGameType_AudioReverbFilter () );
			AddType ( typeof ( AudioReverbZone ), new SaveGameType_AudioReverbZone () );
			AddType ( typeof ( AudioSource ), new SaveGameType_AudioSource () );
			AddType ( typeof ( Avatar ), new SaveGameType_Avatar () );
			AddType ( typeof ( AvatarMask ), new SaveGameType_AvatarMask () );
			AddType ( typeof ( BillboardAsset ), new SaveGameType_BillboardAsset () );
			AddType ( typeof ( BillboardRenderer ), new SaveGameType_BillboardRenderer () );
			AddType ( typeof ( BoneWeight ), new SaveGameType_BoneWeight () );
			AddType ( typeof ( Bounds ), new SaveGameType_Bounds () );
			AddType ( typeof ( BoxCollider ), new SaveGameType_BoxCollider () );
			AddType ( typeof ( BoxCollider2D ), new SaveGameType_BoxCollider2D () );
			AddType ( typeof ( BuoyancyEffector2D ), new SaveGameType_BuoyancyEffector2D () );
			AddType ( typeof ( Button ), new SaveGameType_Button () );
			AddType ( typeof ( Camera ), new SaveGameType_Camera () );
			AddType ( typeof ( CanvasScaler ), new SaveGameType_CanvasScaler () );
			AddType ( typeof ( CapsuleCollider ), new SaveGameType_CapsuleCollider () );
			AddType ( typeof ( CapsuleCollider2D ), new SaveGameType_CapsuleCollider2D () );
			AddType ( typeof ( CharacterController ), new SaveGameType_CharacterController () );
			AddType ( typeof ( CharacterInfo ), new SaveGameType_CharacterInfo () );
			AddType ( typeof ( CharacterJoint ), new SaveGameType_CharacterJoint () );
			AddType ( typeof ( CircleCollider2D ), new SaveGameType_CircleCollider2D () );
			AddType ( typeof ( Cloth ), new SaveGameType_Cloth () );
			AddType ( typeof ( Collider ), new SaveGameType_Collider () );
			AddType ( typeof ( Collider2D ), new SaveGameType_Collider2D () );
			AddType ( typeof ( CollisionModule ), new SaveGameType_CollisionModule () );
			AddType ( typeof ( Color ), new SaveGameType_Color () );
			AddType ( typeof ( Color32 ), new SaveGameType_Color32 () );
			AddType ( typeof ( ColorBlock ), new SaveGameType_ColorBlock () );
			AddType ( typeof ( ColorBySpeedModule ), new SaveGameType_ColorBySpeedModule () );
			AddType ( typeof ( ColorOverLifetimeModule ), new SaveGameType_ColorOverLifetimeModule () );
			AddType ( typeof ( CompositeCollider2D ), new SaveGameType_CompositeCollider2D () );
			AddType ( typeof ( ConfigurableJoint ), new SaveGameType_ConfigurableJoint () );
			AddType ( typeof ( ConstantForce ), new SaveGameType_ConstantForce () );
			AddType ( typeof ( ConstantForce2D ), new SaveGameType_ConstantForce2D () );
			AddType ( typeof ( ContentSizeFitter ), new SaveGameType_ContentSizeFitter () );
			AddType ( typeof ( CullingGroup ), new SaveGameType_CullingGroup () );
			AddType ( typeof ( CustomDataModule ), new SaveGameType_CustomDataModule () );
			AddType ( typeof ( DetailPrototype ), new SaveGameType_DetailPrototype () );
			AddType ( typeof ( DistanceJoint2D ), new SaveGameType_DistanceJoint2D () );
			AddType ( typeof ( Dropdown ), new SaveGameType_Dropdown () );
			AddType ( typeof ( EdgeCollider2D ), new SaveGameType_EdgeCollider2D () );
			AddType ( typeof ( Effector2D ), new SaveGameType_Effector2D () );
			AddType ( typeof ( EmissionModule ), new SaveGameType_EmissionModule () );
			AddType ( typeof ( EventSystem ), new SaveGameType_EventSystem () );
			AddType ( typeof ( EventTrigger ), new SaveGameType_EventTrigger () );
			AddType ( typeof ( ExternalForcesModule ), new SaveGameType_ExternalForcesModule () );
			AddType ( typeof ( FixedJoint ), new SaveGameType_FixedJoint () );
			AddType ( typeof ( FixedJoint2D ), new SaveGameType_FixedJoint2D () );
			AddType ( typeof ( Flare ), new SaveGameType_Flare () );
			AddType ( typeof ( FlareLayer ), new SaveGameType_FlareLayer () );
			AddType ( typeof ( Font ), new SaveGameType_Font () );
			AddType ( typeof ( FontData ), new SaveGameType_FontData () );
			AddType ( typeof ( ForceOverLifetimeModule ), new SaveGameType_ForceOverLifetimeModule () );
			AddType ( typeof ( FrictionJoint2D ), new SaveGameType_FrictionJoint2D () );
			AddType ( typeof ( Gradient ), new SaveGameType_Gradient () );
			AddType ( typeof ( GradientAlphaKey ), new SaveGameType_GradientAlphaKey () );
			AddType ( typeof ( GradientColorKey ), new SaveGameType_GradientColorKey () );
			AddType ( typeof ( GraphicRaycaster ), new SaveGameType_GraphicRaycaster () );
			AddType ( typeof ( GridLayoutGroup ), new SaveGameType_GridLayoutGroup () );
			AddType ( typeof ( HingeJoint ), new SaveGameType_HingeJoint () );
			AddType ( typeof ( HingeJoint2D ), new SaveGameType_HingeJoint2D () );
			AddType ( typeof ( HorizontalLayoutGroup ), new SaveGameType_HorizontalLayoutGroup () );
			AddType ( typeof ( Image ), new SaveGameType_Image () );
			AddType ( typeof ( InheritVelocityModule ), new SaveGameType_InheritVelocityModule () );
			AddType ( typeof ( InputField ), new SaveGameType_InputField () );
			AddType ( typeof ( JointAngleLimits2D ), new SaveGameType_JointAngleLimits2D () );
			AddType ( typeof ( JointDrive ), new SaveGameType_JointDrive () );
			AddType ( typeof ( JointLimits ), new SaveGameType_JointLimits () );
			AddType ( typeof ( JointMotor ), new SaveGameType_JointMotor () );
			AddType ( typeof ( JointMotor2D ), new SaveGameType_JointMotor2D () );
			AddType ( typeof ( JointSpring ), new SaveGameType_JointSpring () );
			AddType ( typeof ( JointSuspension2D ), new SaveGameType_JointSuspension2D () );
			AddType ( typeof ( JointTranslationLimits2D ), new SaveGameType_JointTranslationLimits2D () );
			AddType ( typeof ( Keyframe ), new SaveGameType_Keyframe () );
			AddType ( typeof ( LayerMask ), new SaveGameType_LayerMask () );
			AddType ( typeof ( LayoutElement ), new SaveGameType_LayoutElement () );
			AddType ( typeof ( LensFlare ), new SaveGameType_LensFlare () );
			AddType ( typeof ( Light ), new SaveGameType_Light () );
			AddType ( typeof ( LightmapData ), new SaveGameType_LightmapData () );
			AddType ( typeof ( LightProbeGroup ), new SaveGameType_LightProbeGroup () );
			AddType ( typeof ( LightProbeProxyVolume ), new SaveGameType_LightProbeProxyVolume () );
			AddType ( typeof ( LightProbes ), new SaveGameType_LightProbes () );
			AddType ( typeof ( LightsModule ), new SaveGameType_LightsModule () );
			AddType ( typeof ( LimitVelocityOverLifetimeModule ), new SaveGameType_LimitVelocityOverLifetimeModule () );
			AddType ( typeof ( LineRenderer ), new SaveGameType_LineRenderer () );
			AddType ( typeof ( MainModule ), new SaveGameType_MainModule () );
			AddType ( typeof ( Mask ), new SaveGameType_Mask () );
			AddType ( typeof ( Material ), new SaveGameType_Material () );
			AddType ( typeof ( Matrix4x4 ), new SaveGameType_Matrix4x4 () );
			AddType ( typeof ( Mesh ), new SaveGameType_Mesh () );
			AddType ( typeof ( MeshCollider ), new SaveGameType_MeshCollider () );
			AddType ( typeof ( MeshFilter ), new SaveGameType_MeshFilter () );
			AddType ( typeof ( MeshRenderer ), new SaveGameType_MeshRenderer () );
			AddType ( typeof ( MinMaxCurve ), new SaveGameType_MinMaxCurve () );
			AddType ( typeof ( MinMaxGradient ), new SaveGameType_MinMaxGradient () );
			AddType ( typeof ( Motion ), new SaveGameType_Motion () );
			AddType ( typeof ( Navigation ), new SaveGameType_Navigation () );
			AddType ( typeof ( NavMeshAgent ), new SaveGameType_NavMeshAgent () );
			AddType ( typeof ( NavMeshData ), new SaveGameType_NavMeshData () );
			AddType ( typeof ( NavMeshDataInstance ), new SaveGameType_NavMeshDataInstance () );
			AddType ( typeof ( NavMeshHit ), new SaveGameType_NavMeshHit () );
			AddType ( typeof ( NavMeshLinkData ), new SaveGameType_NavMeshLinkData () );
			AddType ( typeof ( NavMeshLinkInstance ), new SaveGameType_NavMeshLinkInstance () );
			AddType ( typeof ( NavMeshObstacle ), new SaveGameType_NavMeshObstacle () );
			AddType ( typeof ( NavMeshQueryFilter ), new SaveGameType_NavMeshQueryFilter () );
			AddType ( typeof ( NavMeshTriangulation ), new SaveGameType_NavMeshTriangulation () );
			AddType ( typeof ( NoiseModule ), new SaveGameType_NoiseModule () );
			AddType ( typeof ( OcclusionArea ), new SaveGameType_OcclusionArea () );
			AddType ( typeof ( OcclusionPortal ), new SaveGameType_OcclusionPortal () );
			AddType ( typeof ( OffMeshLink ), new SaveGameType_OffMeshLink () );
			AddType ( typeof ( OptionData ), new SaveGameType_OptionData () );
			AddType ( typeof ( OptionDataList ), new SaveGameType_OptionDataList () );
			AddType ( typeof ( Outline ), new SaveGameType_Outline () );
			AddType ( typeof ( ParticleSystem ), new SaveGameType_ParticleSystem () );
			AddType ( typeof ( PhysicMaterial ), new SaveGameType_PhysicMaterial () );
			AddType ( typeof ( Physics2DRaycaster ), new SaveGameType_Physics2DRaycaster () );
			AddType ( typeof ( PhysicsMaterial2D ), new SaveGameType_PhysicsMaterial2D () );
			AddType ( typeof ( PhysicsRaycaster ), new SaveGameType_PhysicsRaycaster () );
			AddType ( typeof ( PlatformEffector2D ), new SaveGameType_PlatformEffector2D () );
			AddType ( typeof ( PointEffector2D ), new SaveGameType_PointEffector2D () );
			AddType ( typeof ( PolygonCollider2D ), new SaveGameType_PolygonCollider2D () );
			AddType ( typeof ( Projector ), new SaveGameType_Projector () );
			AddType ( typeof ( Quaternion ), new SaveGameType_Quaternion () );
			AddType ( typeof ( RawImage ), new SaveGameType_RawImage () );
			AddType ( typeof ( Ray ), new SaveGameType_Ray () );
			AddType ( typeof ( Ray2D ), new SaveGameType_Ray2D () );
			AddType ( typeof ( RaycastHit ), new SaveGameType_RaycastHit () );
			AddType ( typeof ( RaycastHit2D ), new SaveGameType_RaycastHit2D () );
			AddType ( typeof ( Rect ), new SaveGameType_Rect () );
			AddType ( typeof ( RectMask2D ), new SaveGameType_RectMask2D () );
			AddType ( typeof ( RectTransform ), new SaveGameType_RectTransform () );
			AddType ( typeof ( RelativeJoint2D ), new SaveGameType_RelativeJoint2D () );
			AddType ( typeof ( RenderTexture ), new SaveGameType_RenderTexture () );
			AddType ( typeof ( RenderTextureDescriptor ), new SaveGameType_RenderTextureDescriptor () );
			AddType ( typeof ( Rigidbody ), new SaveGameType_Rigidbody () );
			AddType ( typeof ( Rigidbody2D ), new SaveGameType_Rigidbody2D () );
			AddType ( typeof ( RotationBySpeedModule ), new SaveGameType_RotationBySpeedModule () );
			AddType ( typeof ( RotationOverLifetimeModule ), new SaveGameType_RotationOverLifetimeModule () );
			AddType ( typeof ( RuntimeAnimatorController ), new SaveGameType_RuntimeAnimatorController () );
			AddType ( typeof ( Scrollbar ), new SaveGameType_Scrollbar () );
			AddType ( typeof ( ScrollRect ), new SaveGameType_ScrollRect () );
			AddType ( typeof ( Shader ), new SaveGameType_Shader () );
			AddType ( typeof ( Shadow ), new SaveGameType_Shadow () );
			AddType ( typeof ( ShapeModule ), new SaveGameType_ShapeModule () );
			AddType ( typeof ( SizeBySpeedModule ), new SaveGameType_SizeBySpeedModule () );
			AddType ( typeof ( SizeOverLifetimeModule ), new SaveGameType_SizeOverLifetimeModule () );
			AddType ( typeof ( SkinnedMeshRenderer ), new SaveGameType_SkinnedMeshRenderer () );
			AddType ( typeof ( Skybox ), new SaveGameType_Skybox () );
			AddType ( typeof ( Slider ), new SaveGameType_Slider () );
			AddType ( typeof ( SliderJoint2D ), new SaveGameType_SliderJoint2D () );
			AddType ( typeof ( SoftJointLimit ), new SaveGameType_SoftJointLimit () );
			AddType ( typeof ( SoftJointLimitSpring ), new SaveGameType_SoftJointLimitSpring () );
			AddType ( typeof ( SortingGroup ), new SaveGameType_SortingGroup () );
			AddType ( typeof ( SparseTexture ), new SaveGameType_SparseTexture () );
			AddType ( typeof ( SphereCollider ), new SaveGameType_SphereCollider () );
			AddType ( typeof ( SpringJoint ), new SaveGameType_SpringJoint () );
			AddType ( typeof ( SpringJoint2D ), new SaveGameType_SpringJoint2D () );
			AddType ( typeof ( Sprite ), new SaveGameType_Sprite () );
			AddType ( typeof ( SpriteMask ), new SaveGameType_SpriteMask () );
			AddType ( typeof ( SpriteRenderer ), new SaveGameType_SpriteRenderer () );
			AddType ( typeof ( SpriteState ), new SaveGameType_SpriteState () );
			AddType ( typeof ( StandaloneInputModule ), new SaveGameType_StandaloneInputModule () );
			AddType ( typeof ( SubEmittersModule ), new SaveGameType_SubEmittersModule () );
			AddType ( typeof ( SurfaceEffector2D ), new SaveGameType_SurfaceEffector2D () );
			AddType ( typeof ( TargetJoint2D ), new SaveGameType_TargetJoint2D () );
			AddType ( typeof ( Terrain ), new SaveGameType_Terrain () );
			AddType ( typeof ( TerrainCollider ), new SaveGameType_TerrainCollider () );
			AddType ( typeof ( TerrainData ), new SaveGameType_TerrainData () );
			AddType ( typeof ( Text ), new SaveGameType_Text () );
			AddType ( typeof ( TextMesh ), new SaveGameType_TextMesh () );
			AddType ( typeof ( Texture ), new SaveGameType_Texture () );
			AddType ( typeof ( Texture2D ), new SaveGameType_Texture2D () );
			AddType ( typeof ( Texture2DArray ), new SaveGameType_Texture2DArray () );
			AddType ( typeof ( Texture3D ), new SaveGameType_Texture3D () );
			AddType ( typeof ( TextureSheetAnimationModule ), new SaveGameType_TextureSheetAnimationModule () );
			AddType ( typeof ( Toggle ), new SaveGameType_Toggle () );
			AddType ( typeof ( ToggleGroup ), new SaveGameType_ToggleGroup () );
			AddType ( typeof ( Touch ), new SaveGameType_Touch () );
			AddType ( typeof ( TrailModule ), new SaveGameType_TrailModule () );
			AddType ( typeof ( TrailRenderer ), new SaveGameType_TrailRenderer () );
			AddType ( typeof ( Transform ), new SaveGameType_Transform () );
			AddType ( typeof ( Tree ), new SaveGameType_Tree () );
			AddType ( typeof ( TreeInstance ), new SaveGameType_TreeInstance () );
			AddType ( typeof ( TreePrototype ), new SaveGameType_TreePrototype () );
			AddType ( typeof ( TriggerModule ), new SaveGameType_TriggerModule () );
			AddType ( typeof ( Vector2 ), new SaveGameType_Vector2 () );
			AddType ( typeof ( Vector3 ), new SaveGameType_Vector3 () );
			AddType ( typeof ( Vector4 ), new SaveGameType_Vector4 () );
			AddType ( typeof ( VelocityOverLifetimeModule ), new SaveGameType_VelocityOverLifetimeModule () );
			AddType ( typeof ( VerticalLayoutGroup ), new SaveGameType_VerticalLayoutGroup () );
			AddType ( typeof ( VideoClip ), new SaveGameType_VideoClip () );
			AddType ( typeof ( VideoPlayer ), new SaveGameType_VideoPlayer () );
			AddType ( typeof ( WheelCollider ), new SaveGameType_WheelCollider () );
			AddType ( typeof ( WheelFrictionCurve ), new SaveGameType_WheelFrictionCurve () );
			AddType ( typeof ( WheelHit ), new SaveGameType_WheelHit () );
			AddType ( typeof ( WheelJoint2D ), new SaveGameType_WheelJoint2D () );
			AddType ( typeof ( WindZone ), new SaveGameType_WindZone () );

			#else
			Type type = typeof ( SaveGameType );
			Type [] typesFound = AppDomain.CurrentDomain.GetAssemblies ()
			.SelectMany ( s => s.GetTypes () )
			.Where ( p => type.IsAssignableFrom ( p ) && !p.IsInterface && !p.IsAbstract ).ToArray ();
			for ( int i = 0; i < typesFound.Length; i++ )
			{
				SaveGameType saveGameType = ( SaveGameType )Activator.CreateInstance ( typesFound [ i ] );
				m_Types.Add ( saveGameType.AssociatedType, saveGameType );
			}
			#endif
		}

		/// <summary>
		/// Add the custom type.
		/// </summary>
		/// <param name="type">Type.</param>
		/// <param name="saveGameType">Save game type.</param>
		public static void AddType ( Type type, SaveGameType saveGameType )
		{
			if ( !HasType ( type ) )
			{
				Types.Add ( type, saveGameType );
			}
		}

		/// <summary>
		/// Remove the type.
		/// </summary>
		/// <param name="type">Type.</param>
		public static void RemoveType ( Type type )
		{
			Types.Remove ( type );
		}

		/// <summary>
		/// Get the type.
		/// </summary>
		/// <returns>The type.</returns>
		/// <param name="type">Type.</param>
		public static SaveGameType GetType ( Type type )
		{
			return Types [ type ];
		}

		/// <summary>
		/// Determines if the type exists.
		/// </summary>
		/// <returns><c>true</c> if has type the specified type; otherwise, <c>false</c>.</returns>
		/// <param name="type">Type.</param>
		public static bool HasType ( Type type )
		{
			return Types.ContainsKey ( type );
		}

	}

}