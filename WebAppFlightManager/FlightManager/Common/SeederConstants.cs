using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Common
{
    public static class SeederConstants
    {
        public static List<string> firstNames = new List<string>() { "Adolpho", "Alex", "Berenice", "Jack", "Jane", "John", "Joe", "Judye", "Ivan", "Viki", "Ailina", "Kingsly" };
        public static List<string> lastNames = new List<string>() { "Alexandrov", "Borrel", "Gras", "Veldman", "Johnson", "Geram", "Ivanov", "Petrov", "Romera", "Oneal", "Woof", "Waine" };
        public static List<string> mails = new List<string>() { "mail.bg", "abv.bg", "live.com", "gmail.com", "mail.ru", "outlook.com" };
        public static List<string> towns = new List<string>() { "Sofia", "Plovdiv", "Varna", "Ruse", "Vidin", "Burgas" };

        public const string Password = "123456";

        public const string AdminEmail = "admin@admin.bg";
        public const string AdminFirstName = "Admin";
        public const string AdminLastName = "Admin";
        public static string username = "{0}{1}{2}@{3}";
    }
}