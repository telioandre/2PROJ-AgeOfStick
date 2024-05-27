using Nobi.UiRoundedCorners;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Nobi.UiRoundedCorners {
    [ExecuteInEditMode]								//Required to do validation with OnEnable()
    [DisallowMultipleComponent]                     //You can only have one of these in every object
    [RequireComponent(typeof(RectTransform))]
	public class ImageWithIndependentRoundedCorners : MonoBehaviour {
		private static readonly int PropHalfSize = Shader.PropertyToID("_halfSize");
		private static readonly int PropRadiuses = Shader.PropertyToID("_r");
		private static readonly int PropRect2Props = Shader.PropertyToID("_rect2props");

		// Vector2.right rotated clockwise by 45 degrees
		private static readonly Vector2 WNorm = new Vector2(.7071068f, -.7071068f);
		// Vector2.right rotated counter-clockwise by 45 degrees
		private static readonly Vector2 HNorm = new Vector2(.7071068f, .7071068f);

        public Vector4 r = new Vector4(40f, 40f, 40f, 40f);
        private Material _material;

		// xy - position,
		// zw - halfSize
		[FormerlySerializedAs("rect2props")] [HideInInspector, SerializeField] private Vector4 rect2Props;
		[HideInInspector, SerializeField] private MaskableGraphic image;

		private void OnValidate() {
			Validate();
			Refresh();
		}

		private void OnEnable() {
            //You can only add either ImageWithRoundedCorners or ImageWithIndependentRoundedCorners
			//It will replace the other component when added into the object.
            var other = GetComponent<ImageWithRoundedCorners>();
            if (other != null)
            {
                r = Vector4.one * other.radius;		//When it does, transfer the radius value to this script
                DestroyHelper.Destroy(other);
            }

            Validate();
			Refresh();
		}

		private void OnRectTransformDimensionsChange() {
			if (enabled && _material != null) {
				Refresh();
			}
		}

		private void OnDestroy() {
            image.material = null;      //This makes so that when the component is removed, the UI material returns to null

            DestroyHelper.Destroy(_material);
			image = null;
			_material = null;
		}

		public void Validate() {
			if (_material == null) {
				_material = new Material(Shader.Find("UI/RoundedCorners/IndependentRoundedCorners"));
			}

			if (image == null) {
				TryGetComponent(out image);
			}

			if (image != null) {
				image.material = _material;
			}
		}

		public void Refresh() {
			var rect = ((RectTransform)transform).rect;
			RecalculateProps(rect.size);
			_material.SetVector(PropRect2Props, rect2Props);
			_material.SetVector(PropHalfSize, rect.size * .5f);
			_material.SetVector(PropRadiuses, r);
		}

		private void RecalculateProps(Vector2 size) {
			// Vector that goes from left to right sides of rect2
			var aVec = new Vector2(size.x, -size.y + r.x + r.z);

			// Project vector aVec to wNorm to get magnitude of rect2 width vector
			var halfWidth = Vector2.Dot(aVec, WNorm) * .5f;
			rect2Props.z = halfWidth;


			// Vector that goes from bottom to top sides of rect2
			var bVec = new Vector2(size.x, size.y - r.w - r.y);

			// Project vector bVec to hNorm to get magnitude of rect2 height vector
			var halfHeight = Vector2.Dot(bVec, HNorm) * .5f;
			rect2Props.w = halfHeight;


			// Vector that goes from left to top sides of rect2
			var efVec = new Vector2(size.x - r.x - r.y, 0);

			// Vector that goes from point E to point G, which is top-left of rect2
			var egVec = HNorm * Vector2.Dot(efVec, HNorm);

			// Position of point E relative to center of coord system
			var ePoint = new Vector2(r.x - (size.x / 2), size.y / 2);

			// Origin of rect2 relative to center of coord system
			// ePoint + egVec == vector to top-left corner of rect2
			// wNorm * halfWidth + hNorm * -halfHeight == vector from top-left corner to center
			var origin = ePoint + egVec + WNorm * halfWidth + HNorm * -halfHeight;
			rect2Props.x = origin.x;
			rect2Props.y = origin.y;
		}
	}
}

/// <summary>
/// Display Vector4 as 4 separate fields for each corners.
/// It's way easier to use than w,x,y,z in Vector4.
/// </summary>
#if UNITY_EDITOR 
[CustomEditor(typeof(ImageWithIndependentRoundedCorners))]
public class Vector4Editor : Editor
{
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        serializedObject.Update();

        SerializedProperty vector4Prop = serializedObject.FindProperty("r");

        EditorGUILayout.PropertyField(vector4Prop.FindPropertyRelative("x"), new GUIContent("Top Left Corner"));
        EditorGUILayout.PropertyField(vector4Prop.FindPropertyRelative("y"), new GUIContent("Top Right Corner"));
        EditorGUILayout.PropertyField(vector4Prop.FindPropertyRelative("w"), new GUIContent("Bottom Left Corner"));
        EditorGUILayout.PropertyField(vector4Prop.FindPropertyRelative("z"), new GUIContent("Bottom Right Corner"));

        serializedObject.ApplyModifiedProperties();
    }
}
#endif