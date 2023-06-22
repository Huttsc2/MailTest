using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yandexTests.Helpers;

namespace yandexTests.MailData
{
    public class UserList
    {
        private static List<User>? UsersData { get; set; }
        private static User? User { get; set; }
        private static int Couter { get; set; }

        public UserList()
        {
            UsersData = new TestDataReader().GetTestUsers();
            Couter = 0;
        }

        public User GetNewTestUser()
        {
            User = UsersData[Couter];
            Couter++;
            return User;
        }
    }
}
