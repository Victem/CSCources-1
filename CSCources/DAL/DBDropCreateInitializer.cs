using CSCources.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CSCources.DAL
{
    public class DBDropCreateInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

           //Создаем роли admin, user, moderator, teacher, banned
            IdentityRole roleUser = new IdentityRole("user");
            roleManager.Create(roleUser);    

            IdentityRole roleAdmin = new IdentityRole("admin"); 
            roleManager.Create(roleAdmin); 

            IdentityRole roleModerator = new IdentityRole("moderator");
            roleManager.Create(roleModerator);

            IdentityRole roleTeacher = new IdentityRole("teacher");
            roleManager.Create(roleTeacher);

            IdentityRole roleBanned= new IdentityRole("banned");
            roleManager.Create(roleBanned);

            //Создаем пользователей
            ApplicationUser admin = new ApplicationUser() // создаем админа
            {
                UserName = "Admin",
                Name = "Admin",
                LastName = "Admin",
                Id = "Admin",
                Email = "admin@admin.ru",
                EmailConfirmed = true,
                UserInformation = "Администратор портала",
                BirthDate = DateTime.Now
            };

            userManager.Create(admin, "password");

            userManager.AddToRole(admin.Id, "admin");
            userManager.AddToRole(admin.Id, "teacher");
            userManager.AddToRole(admin.Id, "moderator");
            userManager.AddToRole(admin.Id, "user");
            userManager.AddToRole(admin.Id, "banned");


            ApplicationUser moderator = new ApplicationUser() // создаем модератора
            {
                UserName = "Moderator",
                Name = "Moderator",
                LastName = "Moderator",
                Id = "Moderator",
                Sex = Sex.Unset,
                UserInformation = "Модератор портала",
                Email = "moderator@moderator.ru",
                EmailConfirmed = true,
                BirthDate = DateTime.Now
            };

            userManager.Create(moderator, "password");

            userManager.AddToRole(moderator.Id, "moderator");
            userManager.AddToRole(moderator.Id, "admin");
            userManager.AddToRole(moderator.Id, "teacher");
            userManager.AddToRole(moderator.Id, "user");
            userManager.AddToRole(moderator.Id, "banned");


            // создаем Users
            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                Sex tMale;
                if (r.Next(0, 1) == 1)
                   tMale = Sex.Female;
                else tMale = Sex.Male;
                ApplicationUser user1 = new ApplicationUser() // обычные пользователи
                {
                    UserName = "User" + i,
                    Name = "User" + i,
                    LastName = "User" + i,
                    Id = "User" + i,
                    UserInformation = "Обычный пользователь с правами user",
                    AdminNotes = "Заметки админа",
                    Interests = "Блекджек, казино, безделье",
                    BirthDate = DateTime.Now,
                    Email = "user"+i+"@user.ru",
                    EmailConfirmed = true,
                    Sex = tMale
                };
                userManager.Create(user1, "password");

                userManager.AddToRole(user1.Id, "user");
                userManager.AddToRole(user1.Id, "moderator");
                userManager.AddToRole(user1.Id, "admin");
                userManager.AddToRole(user1.Id, "teacher");
                userManager.AddToRole(user1.Id, "banned");



                ApplicationUser userbanned = new ApplicationUser() // забаненные пользователи
                {
                    UserName = "Userban" + i,
                    Name = "Userban" + i,
                    LastName = "Userban" + i,
                    Id = "Userban" + i,
                    UserInformation = "Обычный пользователь с правами user",
                    AdminNotes = "Заметки админа",
                    Interests = "Блекджек, казино, banned",
                    BirthDate = DateTime.Now,
                    Email = "banned"+i+"@banned.ru",
                    EmailConfirmed = true,
                    Sex = tMale
                };
                userManager.Create(userbanned, "password");
                userManager.AddToRole(userbanned.Id, "banned");

                ApplicationUser teacher1 = new ApplicationUser() // учителя
                {
                    UserName = "Teacher" + i,
                    Name = "Teacher" + i,
                    LastName = "Teacher" + i,
                    Id = "Teacher" + i,
                    UserInformation = "Перподователь с правами teacher",
                    AdminNotes = "Заметки админа",
                    Interests = "Блекджек, казино, учеба",
                    BirthDate = DateTime.Now,
                    Email = "teacher"+i+"@teacher.ru",
                    EmailConfirmed = true,
                    Sex = tMale
                };
                userManager.Create(teacher1, "password");
                userManager.AddToRole(teacher1.Id, "teacher");
            }


            //Инициализируем потоки

            List<Thread> Threads = new List<Thread>();  // создаем форумы

            for (int i = 0; i < 5; i++)
            {
                Thread threads = new Thread()
                {
                    Id = i,
                    Title = "Новости" + i,
                    Promo = "Сюда пихаем новости" + i,
                    PublishDate = DateTime.Now
                };

                context.Threads.Add(threads);
            }

                // инициализируем сообщения
                List<Message> Messages = new List<Message>(); // создаем сообщения
                for (int i = 0; i < 12; i++)
                {
                    Message message = new Message()
                    {
                        PublishDate = DateTime.Now,
                        EditDate = DateTime.Now,
                        Text = GenerateSeedText(i),
                        User = admin
                    };

                    context.Messages.Add(message);
                }

                context.SaveChanges();
            }

            string GenerateSeedText(int i)
            {
                StringBuilder sb = new StringBuilder();
                // sb.Append("Message " + i+"\n");
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        sb.Append("текст сообщения ");
                        sb.Append(i);
                        sb.Append(" ");
                    }
                    sb.Append("\n");
                }
                return sb.ToString();
            }
        }
    }