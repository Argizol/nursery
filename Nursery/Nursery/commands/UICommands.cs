using Nursery.model;
using Nursery.model.PackAnimals;
using Nursery.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Nursery.commands
{
    internal class UICommands
    {
        View view;       

        public UICommands(View view1)
        {
            view = view1;
        }
        public void AddAnimal(string name, string species)
        {
            switch (species.ToLower().Trim())
            {
                case "cat":
                    var newCat = new Cat(name, species);
                    //to do добавление в словарь
                    break;
                case "dog":
                    var newDog = new Dogs(name, species);
                    //to do добавление в словарь
                    break;
                case "humster":
                    var newHumster = new Humsters(name, species);
                    //to do добавление в словарь
                    break;
                case "horse":
                    var newHorse = new Horses(name, species);
                    //to do добавление в словарь
                    break;
                case "camel":
                    var newCamel = new Camels(name, species);
                    //to do добавление в словарь
                    break;
                case "donkey":
                    var newDonkey = new Donkeys(name, species);
                    //to do добавление в словарь
                    break;
            }
        }
        public void PrintAnimalCommand(Animals animal)
        {
            foreach (string item in animal.Commands)
                view.Print(item);
        }
        public string GetAnimalName()
        {
            view.Print($"Введите имя животного: ");
            return view.GetString();
        }
        public string GetAnimalSpecies()
        {
            bool work;
            string result;
            do
            {
                view.Print($"Введите вид животного:" +
                    $" Cat,\n Dog,\n Humster,\n Horse, \n Camel,\n Donkey");
                result = view.GetString();
                work = Animals.petsSpecies.Contains(result.ToLower().Trim())
                    || Animals.packAnimalSpecies.Contains(result.ToLower().Trim());
                if (!work) view.Print("Необходимо ввести вид животного из списка");
            }
            while (!work);

            return result;
        }
        public void AddNewAnimalComand(Animals animal)
        {
            view.Print($"Введите название для новой команды");
            string result = view.GetString();
            animal.Commands.Add(result);
            view.Print($"Команда {result} изучена {animal.Name}");
            
        }

        //to do метод поиска животного по имени

    }
}
