using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Practic.Controllers;
using Practic.Data.Models;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Practic.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent appDBContent)
        {
            if (!appDBContent.Category.Any())
            {
                appDBContent.Category.AddRange(Categories.Select(cont => cont.Value));
                //appDBContent.Users.AddRange(Users.Select(cont => cont.Value));
            }
            /*if (!appDBContent.Category.Any())
            {
                var applicationUserId = appDBContent.Users.Select(user => user.Id).FirstOrDefault();
                appDBContent.AddRange(
                    new Aim
                    {
                        Name = "Ознаколмление",
                        //shortDescription = "Изучение типов данных в языке C#",
                        TextField = "Создайте переменниую int",
                        AimTextField = "Создайте переменную integer",
                        Image = "/img/datatypes.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"],
                        ApplicationUserId = applicationUserId
                        //applicationUser = appDBContent.Users.OrderBy(user => user.Id).Last()
                        //applicationUser = appDBContent.Users.FirstOrDefault(user => user.Id != null)
                    }
                /*new Aim
                {
                    Name = "Математические операции",
                    shortDescription = "Математические операции с числами",
                    Image = "/img/mathoperations.jpg",
                    Avaliable = true,
                    category = Categories["Первая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                },
                new Aim
                {
                    Name = "Условные операторы",
                    shortDescription = "Изучение if/else",
                    Image = "/img/ifelse.jpg",
                    Avaliable = true,
                    category = Categories["Первая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                },
                new Aim
                {
                    Name = "Циклы",
                    shortDescription = "Изучение while, do, for",
                    Image = "/img/cycles.jpg",
                    Avaliable = true,
                    category = Categories["Первая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                },
                new Aim
                {
                    Name = "Конструкция switch",
                    shortDescription = "Изучение while, do, for",
                    Image = "/img/switch.jpg",
                    Avaliable = true,
                    category = Categories["Первая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                },
                new Aim
                {
                    Name = "Массивы",
                    shortDescription = "Изучение массивов",
                    Image = "/img/array.jpg",
                    Avaliable = true,
                    category = Categories["Первая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                },
                new Aim
                {
                    Name = "Классы",
                    shortDescription = "Изучение классов",
                    Image = "/img/class.jpg",
                    Avaliable = true,
                    category = Categories["Вторая часть"]
                    //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                }
            //var userId = int.Parse(ApplicationUser.FindFirst(ClaimTypes.NameIdentifier));/*appDBContent.Users.Find(User.Identity.GetUserId());*/
                /*if (userId != null)
                {
                    //,
                    /*new Aim
                    {
                        Name = "Математические операции",
                        shortDescription = "Математические операции с числами",
                        Image = "/img/mathoperations.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    },
                    new Aim
                    {
                        Name = "Условные операторы",
                        shortDescription = "Изучение if/else",
                        Image = "/img/ifelse.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    },
                    new Aim
                    {
                        Name = "Циклы",
                        shortDescription = "Изучение while, do, for",
                        Image = "/img/cycles.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    },
                    new Aim
                    {
                        Name = "Конструкция switch",
                        shortDescription = "Изучение while, do, for",
                        Image = "/img/switch.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    },
                    new Aim
                    {
                        Name = "Массивы",
                        shortDescription = "Изучение массивов",
                        Image = "/img/array.jpg",
                        Avaliable = true,
                        category = Categories["Первая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    },
                    new Aim
                    {
                        Name = "Классы",
                        shortDescription = "Изучение классов",
                        Image = "/img/class.jpg",
                        Avaliable = true,
                        category = Categories["Вторая часть"]
                        //applicationUser = appDBContent.Users.FirstOrDefault(u => u.Id >= 1)
                    }
                );
            }*/
            appDBContent.SaveChanges();

        }
        public static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (Category == null)
                {
                    var list = new Category[]
                    {
                        new Category{ CategoryName = "Первая часть", Description = "Ознакомление с языкос программирования C#"},
                        new Category{ CategoryName = "Вторая часть", Description = "Изучение классов в языке C#"}
                    };
                    Category = new Dictionary<string, Category>();
                    foreach (Category value in list)
                    {
                        Category.Add(value.CategoryName, value);
                    }
                }
                return Category;
            }
        }
    }
}
