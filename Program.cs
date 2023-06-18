using System;
using System.Collections.Generic;

namespace UpPersonalAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

            Dictionary<string, string> dossiers = new Dictionary<string, string>()
            {
                ["Ананьев Евгений Сергеевич"] = "Крановщик",
                ["Жерандол Екатерина Гигорьевна"] = "Повар",
                ["Ян Петр Михайлович"] = "Боец",
                ["Фольфрам Олег Владимирович"] = "Учитель"
            };

            while (isWork)
            {
                Work(dossiers,ref isWork);
                Console.Clear();
            }
        }

        static void DrawMenu(int addingDossier, int withdrawDossiers, int deleteDossier, int exit)
        {
            Console.WriteLine

                ($"{addingDossier} - Добавить досье.\n" +
                $"{withdrawDossiers} - Выести все досье.\n" +
                $"{deleteDossier} - Удалить досье.\n" +
                $"{exit} - Выход.");
        }

        static void Work(Dictionary<string, string> dossiers, ref bool isWork)
        {
            const int AddingDossierCommand = 1;
            const int WithdrawDossiersCommand = 2;
            const int DeleteDossierCommand = 3;
            const int ExitCommand = 4;

            int userInput;

            DrawMenu(AddingDossierCommand, WithdrawDossiersCommand, DeleteDossierCommand, ExitCommand);

            if (int.TryParse(Console.ReadLine(), out int result))
                userInput = result;
            else
                return;

            switch (userInput)
            {
                case AddingDossierCommand:
                    AddDossier(dossiers);
                    break;

                case WithdrawDossiersCommand:
                    ShowDossier(dossiers);
                    break;

                case DeleteDossierCommand:
                    RemoveDossier(dossiers);
                    break;

                case ExitCommand:
                    isWork = ExitProgramm();
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

        static bool ExitProgramm()
        {
            Console.WriteLine("Довстречи!!!");
            Console.ReadKey();

            return false;
        }
    }
}
