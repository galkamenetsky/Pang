using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEditor;

[AddComponentMenu("UI/Extended Button")]
    public class ExtendedButton : Button, IPointerDownHandler, IPointerUpHandler
    {
        [System.Serializable]
        public class ButtonPressEvent : UnityEvent { }

        [SerializeField]
        private ButtonPressEvent onPointerDownEvent = new ButtonPressEvent();
        [SerializeField]
        private ButtonPressEvent onPointerUpEvent = new ButtonPressEvent();

        public ButtonPressEvent OnPointerDownEvent
        {
            get { return onPointerDownEvent; }
            set { onPointerDownEvent = value; }
        }

        public ButtonPressEvent OnPointerUpEvent
        {
            get { return onPointerUpEvent; }
            set { onPointerUpEvent = value; }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            onPointerDownEvent.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            onPointerUpEvent.Invoke();
        }
#if UNITY_EDITOR
    [CustomEditor(typeof(ExtendedButton))]
    public class ExtendedButtonEditor : UnityEditor.UI.ButtonEditor
    {
        SerializedProperty onPointerDownEvent;
        SerializedProperty onPointerUpEvent;

        protected override void OnEnable()
        {
            base.OnEnable();
            onPointerDownEvent = serializedObject.FindProperty("onPointerDownEvent");
            onPointerUpEvent = serializedObject.FindProperty("onPointerUpEvent");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(onPointerDownEvent);
            EditorGUILayout.PropertyField(onPointerUpEvent);
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}