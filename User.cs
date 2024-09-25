using System;
using System.Collections.Concurrent;
namespace ШП_ЛБ1
{
    public interface ICloneable<T>
    {
        T Clone();
    }

	public class User : ICloneable
	{
        public string Login { get; set; }
        protected string Password { get; set; }
        public string Email { get; set; }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public object Clone()
        {
            return new User(Login, Password, Email);
        }

    }

    public abstract class Events
    {
        public DateTime EventDate { get; set; }
        public string Information { get; set; }
        protected string SecretKey { get; set; }
        public List<User> Partisipants { get; set; }


        public Events(DateTime eventDate, string information, string secretKey, List<User> partisipants)

        {
            EventDate = eventDate;
            Information = information;
            SecretKey = secretKey;
            Partisipants = partisipants;
        }

        public abstract void ShowInfo();
        public abstract Events Clone(DateTime newDate);

    }



    public class Meetings : Events, ICloneable
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Meetings(DateTime eventDate, string information, string secretKey, List<User> partisipants, DateTime startTime, DateTime endTime)
            : base(eventDate, information, secretKey, partisipants)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Зустрія: {Information}, {EventDate}, з {StartTime} до {EndTime}");

        }

        public object Clone()
        {
            List<User> clonedPartisipants = new List<User>();
            foreach (var partisipant in Partisipants)
            {
                clonedPartisipants.Add((User)partisipant.Clone());
            }
            return new Meetings(EventDate, Information, SecretKey, clonedPartisipants, StartTime, EndTime);
        }

        public override Events Clone(DateTime newDate)
        {
            Meetings cloned = (Meetings)Clone();
            cloned.EventDate = newDate;
            return cloned;

        }
    }

    public class Birthday : Events
    {
        public User BirthdayUser { get; set; }

        public Birthday(DateTime eventDate, string information, string secretkey, List<User> partisipants, User birthdayUser)
            : base(eventDate, information, secretkey, partisipants)
        {
            BirthdayUser = birthdayUser;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"День народження {BirthdayUser.Login}, {EventDate}. Опис: {Information}");
        }

        public override Events Clone(DateTime newDate)
        {
            List<User> clonedPartisipants = new List<User>();
            foreach (var partisipant in Partisipants)
            {
                clonedPartisipants.Add((User)partisipant.Clone());
            }
            return new Birthday(newDate, this.Information, this.SecretKey, new List<User>(this.Partisipants), this.BirthdayUser);
        }
    }
}

