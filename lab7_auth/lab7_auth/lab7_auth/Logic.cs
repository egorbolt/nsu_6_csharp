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
            Api.Authorize(new ApiAuthParams
            {
                ApplicationId = 6982611,
                Login = "boldyreved@gmail.com",
                Password = "d3eml)@t9a5sw0Rd1sCool",
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
