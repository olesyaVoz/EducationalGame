using System.Collections.Generic;
using UnityEngine;

namespace MyGameNamespace
{

    public class NewBehaviourScript : MonoBehaviour
    {
        public List<ClickReceiver> shapes; // Список всех фигур
        private int circleCount = 0; // Количество выбранных кругов
        private int ovalCount = 0; // Количество выбранных овалов
        private int triangleCount = 0; // Количество выбранных треугольников
        public AudioClip circleSound; //. Звуковой клип для кругов
        public AudioClip triangleSound; //. Звуковой клип для треугольников
        void Start()
        {
            // Убедитесь, что все фигуры добавлены в список
            foreach (var shape in shapes)
            {
                shape.OnShapeSelected += HandleShapeSelected; // Подписка на событие выбора фигуры
            }
        }

        private void HandleShapeSelected(ClickReceiver selectedShape)
        {
            switch (selectedShape.shapeType)
            {
                case "Circle":
                    if (circleCount < 9) // Максимум 3 круга
                    {
                        circleCount++;
                        Debug.Log("Вы выбрали круг. Всего выбрано кругов: " + circleCount);
                    }
                    else
                    {
                        Debug.Log("Все круги выбраны!");
                        GetComponent<AudioSource>().PlayOneShot(circleSound);
                    }
                    break;

                case "Oval":
                    if (circleCount == 3 && ovalCount < 1) // Один овал после трех кругов
                    {
                        ovalCount++;
                        Debug.Log("Вы выбрали овал. Всего выбрано овала: " + ovalCount);
                    }
                    else if (circleCount < 9 || ovalCount < 1)
                    {
                        Debug.Log("Сначала выберите все треугольники!");
                    }
                    else
                    {
                        Debug.Log("Все овалы выбраны!");
                    }
                    break;

                case "Triangle":
                    if (circleCount == 9 && triangleCount < 3) // треугольнии после 9 кругов
                    {
                        triangleCount++;
                        Debug.Log("Вы выбрали треугольник. Всего выбрано треугольников: " + triangleCount);
                    }
                    else if (circleCount < 9)
                    {
                        Debug.Log("Сначала выберите все круги!");
                    }
                    else
                    {
                        Debug.Log("Все треугольники выбраны!");
                    }
                    break;
                case "Rectangle":
                    if (circleCount < 0) // Максимум 3 круга
                    {
                        circleCount++;
                        Debug.Log("Вы выбрали прямоугольник. Больше прямоугольников нет" + circleCount);
                    }

                    break;
                default:
                    Debug.Log("Неизвестный тип фигуры.");
                    break;
            }
        }
    }
}
