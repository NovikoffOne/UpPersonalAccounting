using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpPersonalAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int userInput = 0;

            Dictionary<string, string> dossier = new Dictionary<string, string>()
            {
                ["Ананьев Евгений Сергеевич"] = "Крановщик",
                ["Жерандол Екатерина Гигорьевна"] = "Повар",
                ["Ян Петр Михайлович"] = "Боец",
                ["Фольфрам Олег Владимирович"] = "Учитель"
            };

            while (isWork)
            {
                Work(userInput, dossier, ref isWork);
                Console.Clear();
            }
        }

        static void DrawMenu(int addingDossier, int withdrawDossiers, int deleteDossiers, int exit)
        {
            Console.WriteLine

                ($"{addingDossier} - Добавить досье.\n" +
                $"{withdrawDossiers} - Выести все досье.\n" +
                $"{deleteDossiers} - Удалить досье.\n" +
                $"{exit} - Выход.");
        }

        static void Work(int userInput, Dictionary<string, string> dossier, ref bool isWork)
        {
            const int AddingDossier = 1;
            const int WithdrawDossiers = 2;
            const int DeleteDossiers = 3;
            const int Exit = 4;

            DrawMenu(AddingDossier, WithdrawDossiers, DeleteDossiers, Exit);

            if (int.TryParse(Console.ReadLine(), out int result))
                userInput = result;
            else
                return;

            switch (userInput)
            {
                case AddingDossier:
                    AddDossier(dossier);
                    break;

                case WithdrawDossiers:
                    ShowDossier(dossier);
                    break;

                case DeleteDossiers:
                    RemoveDossier(dossier);
                    break;

                case Exit:
                    ExitProgramm(ref isWork);
                    break;

                default:
                    Console.WriteLine("Попробуйте еще раз!!!");
                    break;
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            Console.Write("Введите ФИО : ");
            string name = Console.ReadLine();
            Console.Clear();

            Console.Write("Введите професию : ");
            string job = Console.ReadLine();
            Console.Clear();

            if (dossiers.ContainsKey(name) == false)
            {
                dossiers.Add(name, job);
                Console.WriteLine("Добавлено!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Такое досье уже добавленно");
                Console.ReadKey();
            }
        }

        static void ShowDossier(Dictionary<string, string> dossiers)
        {
            foreach (var dossier in dossiers)
            {
                Console.Write($"{dossier.Key} - {dossier.Value}, ");
            }

            Console.ReadKey();
        }

        static void RemoveDossier(Dictionary<string, string> dossier)
        {
            Console.Write("Введите ФИО, которое хотите удалить : ");
            string userInput = Console.ReadLine();

            if (dossier.ContainsKey(userInput))
            {
                dossier.Remove(userInput);
            }
            else
            {
                Console.WriteLine("Такого досье - несуществует!!!");
            }
        }

        static void ExitProgramm(ref bool isWork)
        {
            Console.WriteLine("Довстречи!!!");
            Console.ReadKey();

            isWork = false;
        }
    }
}
