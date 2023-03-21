using Nursery.model;
using Nursery.model.PackAnimals;
using Nursery.view;

namespace Nursery.commands
{
    internal class UICommands
    {
        View view;
        private static Dictionary<string, string> listCommands = new()
        {
             {"AddAnimal", "Добавляет животное в базу данных питомника."},
             {"PrintAnimalCommands", "Выводит на экран команды, которые знает животное."},
             {"AddNewAnimalComand", "Обучает животное новой команде."},
             {"Help", "Выводит список доступных команд для пользователя."},
             {"Exit", "Выйти из программы."}
        };

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
                    var result = new List<Animals>();
                    if (!Animals.pets.ContainsKey(newCat.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newCat);
                        Animals.pets.Add(newCat.Specias,list);
                    }
                    else if(Animals.pets.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newCat);                        
                    }

                    break;
                case "dog":
                    var newDog = new Dogs(name, species);
                    if (!Animals.pets.ContainsKey(newDog.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newDog);
                        Animals.pets.Add(newDog.Specias, list);
                    }
                    else if (Animals.pets.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newDog);
                    }
                    break;
                case "humster":
                    var newHumster = new Humsters(name, species);
                    if (!Animals.pets.ContainsKey(newHumster.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newHumster);
                        Animals.pets.Add(newHumster.Specias, list);
                    }
                    else if (Animals.pets.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newHumster);
                    }
                    break;
                case "horse":
                    var newHorse = new Horses(name, species);
                    if (!Animals.packedAnimals.ContainsKey(newHorse.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newHorse);
                        Animals.packedAnimals.Add(newHorse.Specias, list);
                    }
                    else if (Animals.packedAnimals.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newHorse);
                    }
                    break;
                case "camel":
                    var newCamel = new Camels(name, species);
                    if (!Animals.packedAnimals.ContainsKey(newCamel.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newCamel);
                        Animals.packedAnimals.Add(newCamel.Specias, list);
                    }
                    else if (Animals.packedAnimals.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newCamel);
                    }
                    break;
                case "donkey":
                    var newDonkey = new Donkeys(name, species);
                    if (!Animals.packedAnimals.ContainsKey(newDonkey.Specias))
                    {
                        var list = new List<Animals>();
                        list.Add(newDonkey);
                        Animals.packedAnimals.Add(newDonkey.Specias, list);
                    }
                    else if (Animals.packedAnimals.TryGetValue(species, out result))
                    {
                        var list = result;
                        list.Add(newDonkey);
                    }
                    break;
            }
        }

        public void PrintAnimalCommands(Animals animal)
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
                ShowSpecies();
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

        public Animals SearchAnimalByName(string name)
        {
            var list = new List<Animals>();
            var result = new List<Animals>();

            string animalName = GetAnimalName();
            string species = GetSpecies();

            if (Animals.pets.ContainsKey(species))
                if (Animals.pets.TryGetValue(species, out result))
                    list = result;
                else if (Animals.packedAnimals.ContainsKey(species))
                    if (Animals.packedAnimals.TryGetValue(species, out result))
                        list = result;
                    else return default;

            foreach (Animals animals in list)
            {
                if (animals.Name.Equals(animalName))
                {
                    return animals;
                }
            }

            return default;
        }

        public void Help()
        {
            view.Print("Список команд:");
            foreach (var command in UICommands.listCommands)
                view.Print($"{command.Key} {command.Value}");
        }

        public  void ShowSpecies()
        {
            view.Print($"Введите вид животного:" +
                   $" Cat,\n Dog,\n Humster,\n Horse, \n Camel,\n Donkey");
        }

        public string GetSpecies()
        {
            bool work;
            string result;

            do
            {
                ShowSpecies();
                result = view.GetString();
                work = Animals.pets.ContainsKey(result.ToLower().Trim())
                    || Animals.packedAnimals.ContainsKey(result.ToLower().Trim());
                if (!work) view.Print("Необходимо ввести вид животного из списка");
                else break;
            }
            while (!work);
            return result;
        }
    }
}
