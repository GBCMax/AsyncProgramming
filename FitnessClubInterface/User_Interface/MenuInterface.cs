using System;

namespace FitnessClubInterface.User_Interface
{
    public class MenuInterface
    {
        /// <summary>
        /// Интерфейс меню
        /// </summary>
        /// <param name="ui"></param>
        public MenuInterface(UserInterface ui)
        {
            var end = false;
            Start(ui);
            ShowMainMenu(ui);
            while (end != true)
            {
                var choice = "";
                while (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    choice = ui.ReadChoice();
                }

                if (choice == "1")
                {
                    ShowInfoAboutGroups(ui);
                    ShowMainMenu(ui);
                }
                else if (choice == "2")
                {
                    JoinToGroup(ui);
                    ShowMainMenu(ui);
                }
                else if (choice == "3")
                {
                    HelpWithChoosingTraining(ui);
                    ShowMainMenu(ui);
                }
                else if (choice == "4")
                {
                    end = true;
                }
                ui.Clear();
            }
            Refresh(ui);
        }
        /// <summary>
        /// Приветственное меню
        /// </summary>
        /// <param name="ui"></param>
        private void Start(UserInterface ui)
        {
            ui.Welcomemenu();
        }
        /// <summary>
        /// Основное меню
        /// </summary>
        /// <param name="ui"></param>
        private void ShowMainMenu(UserInterface ui)
        {
            ui.Mainmenu(); //вывод меню
        }
        /// <summary>
        /// Вывод информации о группах
        /// </summary>
        /// <param name="ui"></param>
        private void ShowInfoAboutGroups(UserInterface ui)
        {
            ui.Info_about_group();
        }
        /// <summary>
        /// Запись в группу
        /// </summary>
        /// <param name="ui"></param>
        private void JoinToGroup(UserInterface ui)
        {
            ui.List_of_groups();
            var choicegr = "";
            while (choicegr != "1" && choicegr != "2" && choicegr != "3" && choicegr != "4")
            {
                choicegr = ui.ReadChoice();
            }
            var secondname = ui.ReadSecondName();
            var name = ui.ReadName();
            string age = "возраст";
            while (byte.TryParse(age, out _) != true)
            {
                age = ui.ReadAge();
            }
            ui.AddInGroup(choicegr, secondname, name, age);
        }
        /// <summary>
        /// Помощь с выбором занятия
        /// </summary>
        /// <param name="ui"></param>
        private void HelpWithChoosingTraining(UserInterface ui)
        {
            ui.AddGoals();
            ui.ShowGoals(); 
            ui.Support();
        }
        /// <summary>
        /// Очистка экрана и вывод списка групп
        /// </summary>
        /// <param name="ui"></param>
        private void Refresh(UserInterface ui)
        {
            Console.Clear();
            ui.WriteAllGroups();
        }
    }
}