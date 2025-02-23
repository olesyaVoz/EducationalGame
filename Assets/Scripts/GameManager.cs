using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Вставляем сюда спрайты цифр для кнопок
    public GameObject[] NumberButtons;

    // Индекс текущего вопроса
    private int currentQuestionIndex = 0;

    // Список вопросов
    private List<Question> questions = new List<Question>();

    // Структура вопроса
    public struct Question
    {
        public int correctButtonIndex;
        public string questionText;
    }

    void Start()
    {
        // Добавляем вопросы в список
        Question question1;
        question1.correctButtonIndex = 2;  // Индекс кнопки "2" (правильный ответ для яблок)
        question1.questionText = "Сколько яблок?";
        questions.Add(question1);

        Question question2;
        question2.correctButtonIndex = 3; // Индекс кнопки "3" (правильный ответ для земляники)
        question2.questionText = "Сколько земляничек?";
        questions.Add(question2);

        Question question3;
        question3.correctButtonIndex = 1;
        question3.questionText = "Сколько уточек?";
        questions.Add(question3);

        Question question4;
        question4.correctButtonIndex = 4;
        question4.questionText = "Сколько кувшинок?";
        questions.Add(question4);

        Question question5;
        question5.correctButtonIndex = 4;
        question5.questionText = "Сколько грибов?";
        questions.Add(question5);

        StartQuestion();
    }

    void StartQuestion()
    {
        // Берем текущий вопрос
        Question currentQuestion = questions[currentQuestionIndex];

        // Показываем вопрос в консоли (или обновите UI здесь)
        Debug.Log(currentQuestion.questionText);
    }

    public void CheckAnswer(int selectedNumber)
    {
        // Берем текущий вопрос
        Question currentQuestion = questions[currentQuestionIndex];

        // Сравниваем выбранный номер с правильным
        if (selectedNumber == currentQuestion.correctButtonIndex)
        {
            Debug.Log("Правильно, молодец!"); // Сообщение после правильного ответа

            // Увеличиваем индекс вопроса
            currentQuestionIndex++;

            // Проверяем, есть ли еще вопросы
            if (currentQuestionIndex < questions.Count)
            {
                StartQuestion(); // Показываем следующий вопрос
            }
            else
            {
                Debug.Log("Все ответы верны, молодец!"); // Дополнительное сообщение в конце игры
            }
        }
        else
        {
            Debug.Log("Попробуй еще!"); // Ответ неверный
        }
    }
}

