using System;
using Nursery.commands;
using Nursery.view;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            view.Print("Вам доступны следующие команды: ");
            cmd.Help();
            while (true)
            {
                view.Print("Введите команду: ");
                var userCommand = view.GetString();
                switch (userCommand)
                {
                    case "AddAnimal":
                        cmd.AddAnimal(cmd.GetAnimalName(), cmd.GetAnimalSpecies());
                        break;

                    case "PrintAnimalCommands":
                        cmd.PrintAnimalCommands(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        break;

                    case "AddNewAnimalComand":
                        cmd.AddNewAnimalComand(cmd.SearchAnimalByName(cmd.GetAnimalName()));
                        break;

                    case "Help":
                        cmd.Help();
                        break;

                    case "Exit":
                        view.Print("Работа приложения завершена. Нажмите любую кнопку...");
                        view.ReadKey();
                        return;

                    default:
                        view.Print("Неизвестная команда. Повторите ввод.");
                        break;
                }
            }
        }
    }
}