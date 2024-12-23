#include <iostream>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

// Матриця слів
vector<vector<char>> СЛОВА = {
    {'т', 'а', 'к'},
    {'к', 'і', 'т'},
    {'с', 'л', 'о', 'н'},
    {'р', 'и', 'б', 'а'}
};

// Константа для максимальних невдалих спроб
const int МАКС_СПРОБ = 5;

int main()
{
    srand(time(0)); // Ініціалізація генератора випадкових чисел

    // Випадковий вибір слова з матриці
    vector<char> вибранеСлово = СЛОВА[rand() % СЛОВА.size()];

    // Ініціалізація масиву зірочок
    vector<char> відгаданеСлово(вибранеСлово.size(), '*');

    int спроби = 0; // Лічильник невдалих спроб
    bool словоВідгадане = false; // Чи відгадано слово повністю

    cout << "Ласкаво просимо до гри Вгадай Слово!" << endl;
    cout << "Спробуйте відгадати слово. Ви можете зробити " << МАКС_СПРОБ << " невдалих спроб." << endl;

    // Цикл гри
    while (спроби < МАКС_СПРОБ && !словоВідгадане)
    {
        // Виведення слова з зірочками
        cout << "Поточне слово: ";
        for (char літера : відгаданеСлово)
        {
            cout << літера;
        }
        cout << endl;

        // Запитання літери та позиції
        cout << "Введіть літеру: ";
        char літера;
        cin >> літера;

        cout << "Введіть позицію літери (0 до " << (вибранеСлово.size() - 1) << "): ";
        int позиція;
        cin >> позиція;

        if (позиція < 0 || позиція >= вибранеСлово.size())
        {
            cout << "Неправильна позиція! Спробуйте ще раз." << endl;
            continue;
        }

        // Перевірка, чи правильно введено літеру та позицію
        if (вибранеСлово[позиція] == літера)
        {
            відгаданеСлово[позиція] = літера; // Замінюємо зірочку на літеру
            cout << "Правильна літера!" << endl;

            // Перевірка, чи всі літери відгадані
            словоВідгадане = true;
            for (char c : відгаданеСлово)
            {
                if (c == '*')
                {
                    словоВідгадане = false;
                    break;
                }
            }
        }
        else
        {
            спроби++;
            cout << "Неправильна літера! Залишилось спроб: " << (МАКС_СПРОБ - спроби) << endl;
        }
    }

    // Підсумок гри
    if (словоВідгадане)
    {
        cout << "Вітаємо! Ви відгадали слово: ";
        for (char літера : відгаданеСлово)
        {
            cout << літера;
        }
        cout << endl;
    }
    else
    {
        cout << "Гру завершено! Ви використали всі спроби." << endl;
        cout << "Правильне слово було: ";
        for (char літера : вибранеСлово)
        {
            cout << літера;
        }
        cout << endl;
    }

    return 0;
}
