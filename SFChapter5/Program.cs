using System;

namespace SFChapter5
{
    internal class Program
    {
        static void Main(string[] args) //Метод принимает кортеж и выводит информацию на консоль
        {
            (string UserName, string UserSurname, int UserAge, string[] UserPetNames, string[] UserFavColor) anketa = GetData();

            Console.WriteLine();
            Console.WriteLine("Благодарим за предоставленные данные.\n");
            Console.WriteLine("Анкета пользователя.\n");

            Console.WriteLine($"Имя: {anketa.UserName}.\n");

            Console.WriteLine($"Фамилия: {anketa.UserSurname}.\n");

            Console.WriteLine($"Возраст: {anketa.UserAge}.\n");

            Console.WriteLine("Клички животных:");
            foreach(string s in anketa.UserPetNames) 
            {
                Console.Write($"{s}. ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Любимые цвета:");
            foreach (string s in anketa.UserFavColor)
            {
                Console.Write($"{s}. ");
            }

        }
        static (string, string, int, string[], string[]) GetData() //Сбор данных пользователя

        {
            Console.WriteLine("Введите ваше имя.");
            string name = Console.ReadLine();

            Console.WriteLine("Введите вашу фамилию.");
            string surname = Console.ReadLine();

            int age;
            do
            {
                Console.WriteLine("Введите ваш возраст.");
                age = int.Parse(Console.ReadLine());
            }
            while (CheckData(age));

            int petNumbers;
            string pn = "имя питомца";
            string[] namePets = new string[] {};
            Console.WriteLine("Есть ли у вас домашнее животное? (Да или Нет)");
            string hasPet = Console.ReadLine();

            if (hasPet == "Да")
            {
                do
                {
                    Console.WriteLine("Сколько у вас питомцев?");
                    petNumbers = int.Parse(Console.ReadLine());
                }
                while (CheckData(petNumbers));
                namePets = ReturnArray(petNumbers, pn);
            }


            int numberColors;
            string favCol = "любимый цвет";
            do
            {
                Console.WriteLine("Сколько у вас любимых цветов?");
                numberColors = int.Parse(Console.ReadLine());
            }
            while (CheckData(numberColors));

            string[] favColors = ReturnArray(numberColors, favCol);

            var anketa = (name, surname, age, namePets, favColors);

            return anketa;

        }
        static bool CheckData(int data) //проверка на корректность ввода
        {
            if (data <= 0)
            {
                Console.WriteLine("Введенные данные не корректны, значение должно быть > 0.");
                return true;
            }
            else { return false; }

        }
        static string[] ReturnArray(int n, string y) //возвращение массива
        {
            string[] arr = new string[n];
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Введите {y} {i + 1}: ");
                arr[i] = Console.ReadLine();
            }
            return arr;

        }
    }
}
