using Nursery.commands;
using Nursery.view;


namespace Nursery.controller
{
    internal class Controller
    {        
        View view;
        UICommands cmd;

        public Controller(View view1, UICommands cmd1)
        {
            view = view1;
            cmd = cmd1;
        }
        public void Execute()
        {
            view.Print("Добро пожаловать в приложение 'Nursery'.");
            view.Print("");
            view.Print("Вам доступны следующие команды: ");
            view.Print("");
            cmd.Help();

            while (true)
            {
                view.Print("Введите команду: ");
                var userCommand = view.GetString();
                switch (userCommand)
                {
                    case "Add":
                        cmd.AddAnimal(cmd.GetAnimalName(), cmd.GetAnimalSpecies());
                        view.Print("");
                        break;

                    case "ShowCmd":
                        cmd.PrintAnimalCommands(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        view.Print("");
                        break;

                    case "AddCmd":
                        cmd.AddNewAnimalComand(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        view.Print("");
                        break;

                    case "Help":
                        cmd.Help();
                        view.Print("");
                        break;

                    case "Exit":
                        view.Print("Работа приложения завершена. Нажмите любую кнопку...");
                        view.ReadKey();
                        return;

                    default:
                        view.Print("Неизвестная команда. Повторите ввод.");
                        view.Print("");
                        break;
                }
            }
        }
    }
}