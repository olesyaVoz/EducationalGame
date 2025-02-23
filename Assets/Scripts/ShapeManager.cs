using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace
{

    public class NewBehaviourScript : MonoBehaviour
    {
        public List<ClickReceiver> shapes; // ������ ���� �����
        private int circleCount = 0; // ���������� ��������� ������
        private int ovalCount = 0; // ���������� ��������� ������
        private int triangleCount = 0; // ���������� ��������� �������������
        public AudioClip circleSound; //. �������� ���� ��� ������
        public AudioClip triangleSound; //. �������� ���� ��� �������������
        void Start()
        {
            // ���������, ��� ��� ������ ��������� � ������
            foreach (var shape in shapes)
            {
                shape.OnShapeSelected += HandleShapeSelected; // �������� �� ������� ������ ������
            }
        }

        private void HandleShapeSelected(ClickReceiver selectedShape)
        {
            switch (selectedShape.shapeType)
            {
                case "Circle":
                    if (circleCount < 9) // �������� 3 �����
                    {
                        circleCount++;
                        Debug.Log("�� ������� ����. ����� ������� ������: " + circleCount);
                    }
                    else
                    {
                        Debug.Log("��� ����� �������!");
                        GetComponent<AudioSource>().PlayOneShot(circleSound);
                    }
                    break;

                case "Oval":
                    if (circleCount == 3 && ovalCount < 1) // ���� ���� ����� ���� ������
                    {
                        ovalCount++;
                        Debug.Log("�� ������� ����. ����� ������� �����: " + ovalCount);
                    }
                    else if (circleCount < 9 || ovalCount < 1)
                    {
                        Debug.Log("������� �������� ��� ������������!");
                    }
                    else
                    {
                        Debug.Log("��� ����� �������!");
                    }
                    break;

                case "Triangle":
                    if (circleCount == 9 && triangleCount < 3) // ����������� ����� 9 ������
                    {
                        triangleCount++;
                        Debug.Log("�� ������� �����������. ����� ������� �������������: " + triangleCount);
                    }
                    else if (circleCount < 9)
                    {
                        Debug.Log("������� �������� ��� �����!");
                    }
                    else
                    {
                        Debug.Log("��� ������������ �������!");
                    }
                    break;
                case "Rectangle":
                    if (circleCount < 0) // �������� 3 �����
                    {
                        circleCount++;
                        Debug.Log("�� ������� �������������. ������ ��������������� ���" + circleCount);
                    }

                    break;
                default:
                    Debug.Log("����������� ��� ������.");
                    break;
            }
        }
    }
}
