using System;
using System.Collections.Generic;
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Program
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
    }

    static List<User> users = [];
    static int nextId = 1;
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Работа с таблицей Users.");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1) Посмотреть все записи");
            Console.WriteLine("2) Добавить нового пользователя");
            Console.WriteLine("3) Обновить существующего пользователя");
            Console.WriteLine("4) Удалить существующего пользователя");
            Console.WriteLine("5) Авторизоваться в системе");
            Console.WriteLine("0) Выход");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewUsers();
                    break;
                case "2":
                    AddUser();
                    break;
                case "3":
                    UpdateUser();
                    break;
                case "4":
                    DeleteUser();
                    break;
                case "5":
                    AuthenticateUser();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте ещё раз!");
                    break;
            }
        }
    }
    static void ViewUsers()
    {
        Console.Clear();
        Console.WriteLine("Список пользователей:");
        Console.WriteLine("ID    Firstname    Username    Password    Age");

        foreach (var user in users)
        {
            Console.WriteLine($"{user.Id}.    {user.Firstname}        {user.Username}  ********    {user.Age}");
        }

        Console.WriteLine("\nНажмите на любую клавишу чтобы вернуться.");
        Console.ReadKey();
    }
    static void AddUser()
    {
        Console.Clear();
        User newUser = new();
        newUser.Id = nextId++;

        Console.Write("Введите имя: ");
        newUser.Firstname = Console.ReadLine();

        Console.Write("Введите имя пользователя: ");
        newUser.Username = Console.ReadLine();

        Console.Write("Введите пароль: ");
        newUser.Password = Console.ReadLine();

        Console.Write("Введите возраст: ");
        newUser.Age = int.Parse(Console.ReadLine());

        users.Add(newUser);
        Console.WriteLine("Пользователь добавлен. Нажмите любую клавишу для возврата.");
        Console.ReadKey();
    }
    static void UpdateUser()
    {
        Console.Clear();
        Console.Write("Введите ID пользователя для обновления: ");
        int id = int.Parse(Console.ReadLine());
        User user = users.Find(u => u.Id == id);

        if (user != null)
        {
            Console.Write("Введите новое имя: ");
            user.Firstname = Console.ReadLine();

            Console.Write("Введите новое имя пользователя: ");
            user.Username = Console.ReadLine();

            Console.Write("Введите новый пароль: ");
            user.Password = Console.ReadLine();

            Console.Write("Введите новый возраст: ");
            user.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Пользователь обновлен. Нажмите любую клавишу для возврата.");
        }
        else
        {
            Console.WriteLine("Пользователь не найден. Нажмите любую клавишу для возврата.");
        }
        Console.ReadKey();
    }
    static void DeleteUser()
    {
        Console.Clear();
        Console.Write("Введите ID пользователя для удаления: ");
        int id = int.Parse(Console.ReadLine());
        User user = users.Find(u => u.Id == id);

        if (user != null)
        {
            users.Remove(user);
            Console.WriteLine("Пользователь удален. Нажмите любую клавишу для возврата.");
        }
        else
        {
            Console.WriteLine("Пользователь не найден. Нажмите любую клавишу для возврата.");
        }
        Console.ReadKey();
    }
    static void AuthenticateUser()
    {
        Console.Clear();
        Console.Write("Введите имя пользователя: ");
        string username = Console.ReadLine();

        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();

        User user = users.Find(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine($"Добро пожаловать, {user.Firstname}!");
        }
        else
        {
            Console.WriteLine("Неверные учетные данные. Нажмите любую клавишу для возврата.");
        }
        Console.ReadKey();
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////