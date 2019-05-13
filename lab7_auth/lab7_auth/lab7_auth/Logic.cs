using System;
using System.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace lab7_auth
{
    class Logic: IDisposable
    {
        VkApi Api = new VkApi();
        public void Dispose()
        {
            Api.Dispose();
        }
        public void Execute()
        {
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.Write("Password: ");

            var pass = "";
            do
            {
                var key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);

            Api.Authorize(new ApiAuthParams
            {
                ApplicationId = 6982611,
                Login = login,
                Password = pass,
                Settings = Settings.All,
                TwoFactorAuthorization = () =>
                {
                    Console.Write("Enter Code: ");
                    return Console.ReadLine();
                }
            });

            Console.WriteLine(Api.Token);

            var Users = Api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = 23332036,
                Fields = ProfileFields.FirstName,
            });

            var Names = Users.Select(x => x.FirstName);
            var Surnames = Users.Select(x => x.LastName);
            var NamesAndSurnames = Names.Zip(Surnames, (First, Second) => First + " " + Second);

            foreach (var friend in NamesAndSurnames)
            {
                Console.WriteLine(friend);
            }

            Api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = 123,
                UserId = 23332036,
                Message = "test",
            });


        }
    }
}
