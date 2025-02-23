using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyGameNamespace;


namespace MyGameNamespace
{
    public class ClickReceiver : MonoBehaviour
    {
        public string shapeType;
        private bool isSelected = false;
        public GameObject outlineGameObject;
        private SpriteRenderer outlineRenderer;

        public delegate void ShapeSelected(ClickReceiver shape);
        public event ShapeSelected OnShapeSelected;

        void Start()
        {
            outlineRenderer = outlineGameObject.GetComponent<SpriteRenderer>();
            outlineRenderer.color = new Color(1, 1, 1, 0); // ���������� ������� ��������
        }

        void OnMouseEnter()
        {
            if (!isSelected)
            {
                outlineGameObject.SetActive(true);
                outlineRenderer.color = new Color(1, 1, 1, 1); // ������� ������� �������
            }
        }

        void OnMouseExit()
        {
            if (!isSelected)
            {
                outlineGameObject.SetActive(false);
            }
        }

        void OnMouseDown()
        {
            if (!isSelected)
            {
                isSelected = true;
                outlineGameObject.SetActive(true);
                outlineRenderer.color = new Color(1, 1, 1, 1); // ������� ������� �������

                OnShapeSelected?.Invoke(this); // ������� ������� ������ ������

            }
            Debug.Log("�� �������: " + shapeType);
        }
    }
}