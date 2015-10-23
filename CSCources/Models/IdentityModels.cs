using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CSCources.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public enum Sex { Unset = 0, Male = 1, Female = 2 }

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Sex Sex { get; set; } = Sex.Unset;

        /// <summary>
        /// текст о пользователе, пользователь его сам заполняет
        /// </summary>
        public string UserInformation { get; set; }

        /// <summary>
        /// интересы пользователя, пользователь заполняет их сам
        /// </summary>
        public string Interests { get; set; }

        /// <summary>
        /// заметки администратора о пользователе
        /// </summary>
        public string AdminNotes { get; set; }

        //public UInt16 Telefon { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    
}