#if UNITY_EDITOR 

using UnityEditor;
using UnityEngine.UI;

namespace Nobi.UiRoundedCorners.Editor {
    [CustomEditor(typeof(ImageWithIndependentRoundedCorners))]
    public class ImageWithIndependentRoundedCornersInspector : UnityEditor.Editor {
        private ImageWithIndependentRoundedCorners _script;

        private void OnEnable() {
            _script = (ImageWithIndependentRoundedCorners)target;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            if (!_script.TryGetComponent<Image>(out var _)) {
                EditorGUILayout.HelpBox("This script requires an Image component on the same gameobject", MessageType.Warning);
            }
        }
    }
}

#endif