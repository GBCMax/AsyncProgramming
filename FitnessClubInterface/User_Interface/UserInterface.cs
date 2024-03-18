using System;

namespace FitnessClubInterface.User_Interface
{
    public class UserInterface
    {
        /// <summary>
        /// Переменные для работы программы
        /// </summary>
        private readonly FitnessClub _fitnessClub1 = FitnessClubRepository.Files.FitnessClubRepository.GetGroups();
        private readonly MainGoals _mainGoals = new MainGoals();
        private readonly TrainingSupport _trainingSupport = new TrainingSupport();

        /// <summary>
        /// Вывод приветственного меню
        /// </summary>
        public void Welcomemenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Добро пожаловать на сайт фитнес-клуба!");
            Console.WriteLine("Что вы желаете выбрать?");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
        }

        /// <summary>
        /// Вывод основного меню
        /// </summary>
        public void Mainmenu()
        {
            Console.WriteLine("1 - Просмотреть информацию о занятиях");
            Console.WriteLine("2 - Записаться на занятие");
            Console.WriteLine("3 - Помощь с выбором занятия");
            Console.WriteLine("4 - Выход");
        }

        /// <summary>
        /// Вызов метода добавления целей тренировок
        /// </summary>
        public void AddGoals()
        {
            _mainGoals.AddGoals(_fitnessClub1.Trainings);
        }

        /// <summary>
        /// Методы вывода текста для пользователя
        /// </summary>
        public string ReadName()
        {
            Console.WriteLine("Ваше имя:");
            return Console.ReadLine();
        }

        public string ReadSecondName()
        {
            Console.WriteLine("Ваша фамилия:");
            return Console.ReadLine();
        }

        public string ReadAge()
        {
            Console.WriteLine("Ваш возраст(от 5 до 70):");
            return Console.ReadLine();
        }

        public string ReadChoice()
        {
            Console.WriteLine("Пример ввода: 1");
            return Console.ReadLine();
        }

        /// <summary>
        /// Вывод информации о группах
        /// </summary>
        public void Info_about_group()
        {
            var i = 0;
            foreach (var training in _fitnessClub1.Trainings)
                Console.WriteLine("Группа №" + ++i + ": Тип тренировки: " + training.TypeOfTraining + "; Описание: " +
                                  training.Description);
        }

        /// <summary>
        /// Вывод списка групп
        /// </summary>
        public void List_of_groups()
        {
            Console.WriteLine("Выберите группу:");
            Console.WriteLine("Список групп:");
            var i = 0;
            foreach (var group in _fitnessClub1.Groups) Console.WriteLine(++i + " - " + group.GroupName);
        }

        /// <summary>
        /// Вывод текста для помощи с выбором занятия
        /// </summary>
        public void Support()
        {
            Console.WriteLine("Чего вы желаете добиться от тренировок?");
            Console.WriteLine("Введите нужное");
            var helpchoice = Console.ReadLine();
            var res = _trainingSupport.HelpWithChoice(_fitnessClub1, helpchoice);
            if (res != "")
            {
                Console.WriteLine("По вашему запросу найдено следующее:");
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("Не найдено!");
            }
        }

        /// <summary>
        /// Вывод списка всех групп с участниками
        /// </summary>
        public void WriteAllGroups()
        {
            Console.WriteLine("Список всех групп:");
            foreach (var g in _fitnessClub1.Groups)
            {
                Console.WriteLine(g.GroupName);
                for (var i = 0; i < g.People.Count; i++)
                    Console.WriteLine("Фамилия: " + g.People[i].SecondName + " Имя: " + g.People[i].Name +
                                      " Возраст: " + g.People[i].Age);
            }
        }

        /// <summary>
        /// Оповещение о результате добавления в группу
        /// </summary>
        /// <param name="choiceGroup"></param>
        /// <param name="secondname"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public void AddInGroup(string choiceGroup, string secondname, string name, string age)
        {
            Console.WriteLine(_fitnessClub1.Groups[int.Parse(choiceGroup) - 1].AddPerson(new Person(secondname, name, age)));
        }

        /// <summary>
        /// Вывод целей тренировок
        /// </summary>
        public void ShowGoals()
        {
            Console.WriteLine("Выберите цель:");
            foreach (var v in _mainGoals.MainGoalsDictionary) Console.WriteLine(v.Key + " - " + v.Value);
        }

        /// <summary>
        /// Очистка словаря с целями тренировок
        /// </summary>
        public void Clear()
        {
            _mainGoals.MainGoalsDictionary.Clear();
        }
    }
}