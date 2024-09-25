//Варіант 3. Розробити метод класу Календар для копіювання об'єктів Події (Дата події,
//опис, секретний ключ для online сеансу зв’язку та список учасників, де кожен учасник
//– об’єкт Користувач (логін, пароль, e-mail )) в календарі на іншу дату. Передбачити
//можливість існування двох видів подій: Зустріч яка має час початку, час завершення
//та День народження, яка має контакти іменинника – об'єкт користувач.
//Основні вимоги: Секретний ключ та пароль - захищені поля, решта полів - публічні.
//Календар - об'єкт що містить список
//подій та методи: додавання нової події, та вивід всіх подій.


using System;
using System.Collections.Generic;
using System.Linq;


namespace ШП_ЛБ1
{
    class Program
    {
        static void Main()
        {

            User user1 = new User("user_1", "password1", "email1@em.com");
            User user2 = new User("user_2", "password2", "email2@em.com");

            List<User> partisipants = new List<User> { user1, user2 };

            Meetings meeting = new Meetings(
                DateTime.Now,
                "Meeting1",
                "secret111",
                partisipants,
                DateTime.Now.AddHours(1),
                DateTime.Now.AddHours(2)
                );

            Birthday birthday = new Birthday(
                DateTime.Now.AddDays(5),
                "Users birthday",
                "secret222",
                partisipants,
                user1
                );

            Calendar calendar = new Calendar();

            calendar.AddEvent(meeting);
            calendar.AddEvent(birthday);

            Console.WriteLine("Події: ");
            calendar.ShowAllEvents();

            calendar.CopyEvent(meeting, DateTime.Now.AddDays(6));

            calendar.CopyEvent(birthday, DateTime.Now.AddDays(10));

            Console.WriteLine("Події після копіювання: ");
            calendar.ShowAllEvents();

        }
    }


}










