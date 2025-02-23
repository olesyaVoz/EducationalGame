using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ��������� ���� ������� ���� ��� ������
    public GameObject[] NumberButtons;

    // ������ �������� �������
    private int currentQuestionIndex = 0;

    // ������ ��������
    private List<Question> questions = new List<Question>();

    // ��������� �������
    public struct Question
    {
        public int correctButtonIndex;
        public string questionText;
    }

    void Start()
    {
        // ��������� ������� � ������
        Question question1;
        question1.correctButtonIndex = 2;  // ������ ������ "2" (���������� ����� ��� �����)
        question1.questionText = "������� �����?";
        questions.Add(question1);

        Question question2;
        question2.correctButtonIndex = 3; // ������ ������ "3" (���������� ����� ��� ���������)
        question2.questionText = "������� ����������?";
        questions.Add(question2);

        Question question3;
        question3.correctButtonIndex = 1;
        question3.questionText = "������� ������?";
        questions.Add(question3);

        Question question4;
        question4.correctButtonIndex = 4;
        question4.questionText = "������� ��������?";
        questions.Add(question4);

        Question question5;
        question5.correctButtonIndex = 4;
        question5.questionText = "������� ������?";
        questions.Add(question5);

        StartQuestion();
    }

    void StartQuestion()
    {
        // ����� ������� ������
        Question currentQuestion = questions[currentQuestionIndex];

        // ���������� ������ � ������� (��� �������� UI �����)
        Debug.Log(currentQuestion.questionText);
    }

    public void CheckAnswer(int selectedNumber)
    {
        // ����� ������� ������
        Question currentQuestion = questions[currentQuestionIndex];

        // ���������� ��������� ����� � ����������
        if (selectedNumber == currentQuestion.correctButtonIndex)
        {
            Debug.Log("���������, �������!"); // ��������� ����� ����������� ������

            // ����������� ������ �������
            currentQuestionIndex++;

            // ���������, ���� �� ��� �������
            if (currentQuestionIndex < questions.Count)
            {
                StartQuestion(); // ���������� ��������� ������
            }
            else
            {
                Debug.Log("��� ������ �����, �������!"); // �������������� ��������� � ����� ����
            }
        }
        else
        {
            Debug.Log("�������� ���!"); // ����� ��������
        }
    }
}

