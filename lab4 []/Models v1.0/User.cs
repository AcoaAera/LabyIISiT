using System.Collections.Generic;

namespace Models_v1._0
{
    class User
    {
        public User()
        {
            GetPreferences = new List<int>();
        }

        public List<int> GetPreferences { get; }//список предпочтений пользователя

        public void AddPreference(int value)//добавить вариант в список предпочтений
        {
            GetPreferences.Add(value);
        }
    }
}