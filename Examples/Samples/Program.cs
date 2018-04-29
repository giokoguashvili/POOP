using System;
using Qweex.Monads.Either;
using Qweex.Monads.Either.Type;
using Qweex.Unions;
using static System.Console;

namespace Samples
{
    public class UserState
    {
        public UserState(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; }
        public int Age { get; }

        public string Info()
        {
            return $"{Name} {Age}";
        }
    }

    public class UserNotFoundMessage
    {
        public UserNotFoundMessage(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public abstract class TUser : TEither<UserNotFoundMessage, UserState>.P<TUser>
    {
        protected TUser(Func<TUser> factory) : base(factory) {}
        protected TUser(UserState value) : base(value) {}
        protected TUser(UserNotFoundMessage value) : base(value) {}
    }

    public class UserByName : TUser
    {
        public UserByName(string name) : base(() =>
        {
            var userFromSource = new UserState("Gio", 12);
            return userFromSource.Name.Equals(name) 
                ? new UserByName(userFromSource) 
                : new UserByName(new UserNotFoundMessage("Not Found"));
        }) {}
        public UserByName(UserState value) : base(value) {}
        public UserByName(UserNotFoundMessage value) : base(value) {}
    }

    public class UserByAge : TUser
    {
        public UserByAge(int age) : base(() =>
        {
            var userFromSource = new UserState("Gio", 25);
            return userFromSource.Age.Equals(age) 
                ? new UserByAge(userFromSource) 
                : new UserByAge(new UserNotFoundMessage("Not Found"));
        }) {}
        public UserByAge(UserState value) : base(value) {}
        public UserByAge(UserNotFoundMessage value) : base(value) {}
    }

    class Program
    {
        static void Main(string[] args)
        { 
            new Display(
                new UserByName("Gio")
            ).Show(); // Gio 25

            new Display(
                new UserByName("Saba")
            ).Show(); // Not Found

            new Display(
                new UserByAge(25)
            ).Show(); // Gio 25

            new Display(
                new UserByAge(26)
            ).Show(); // Not Found
        }
    }

    public class Display
    {
        private readonly TUser _user;

        public Display(TUser user)
        {
            _user = user;
        }

        public void Show()
        {
            WriteLine(
                _user
                    .Match(
                        e => e.Message,
                        u => u.Info()
                    )
            ); // Gio 25
        }
    }
}
