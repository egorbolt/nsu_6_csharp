using System;
using System.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;
using VkNet.Model;

namespace lab7_auth
{
    class Logic: IDisposable
    {
        private VkApi Api = new VkApi();

        public void Dispose()
        {
            Api.Dispose();
        }

        public void Execute()
        {
            Console.Write("Login: ");
            var login = Console.ReadLine();
            Console.Write("Password: ");

            var pass = Pass.GetPassword();

            try
            {
                Api.Authorize(new ApiAuthParams
                {
                    ApplicationId = 6982611,
                    Login = login,
                    Password = pass,
                    Settings = Settings.Friends,
                    TwoFactorAuthorization = () =>
                    {
                        Console.Write("Enter Code: ");
                        return Console.ReadLine();
                    }                    
                });
            } catch (VkApiAuthorizationException err)
            {
                Console.WriteLine("Wrong login or password");
                throw;
            }

            Console.WriteLine(Api.Token);

            var Users = Api.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            {
                UserId = 23332036,
                Fields = ProfileFields.FirstName,
            });

            var friends = Users.Select(x => x.FirstName + " " + x.LastName);

            foreach (var friend in friends)
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
