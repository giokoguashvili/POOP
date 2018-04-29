using System;
using Qweex.Monads.Either;
using Qweex.Monads.Either.Type;
using Qweex.Unions;
using static System.Console;

namespace Samples
{
    public static class FkDb
    {
        public static UserState User => new UserState("Gio", 25);
    }

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
            var userFromSource = FkDb.User;
            return userFromSource.Name.Equals(name) 
                ? new UserByName(userFromSource) 
                : new UserByName(new UserNotFoundMessage("Not Found"));
        }) {}
        private UserByName(UserState value) : base(value) {}
        private UserByName(UserNotFoundMessage value) : base(value) {}
    }

    public class UserByAge : TUser
    {
        public UserByAge(int age) : base(() =>
        {
            var userFromSource = FkDb.User;
            return userFromSource.Age.Equals(age) 
                ? new UserByAge(userFromSource) 
                : new UserByAge(new UserNotFoundMessage("Not Found"));
        }) {}
        private UserByAge(UserState value) : base(value) {}
        private UserByAge(UserNotFoundMessage value) : base(value) {}
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
            );
        }
    }
}
