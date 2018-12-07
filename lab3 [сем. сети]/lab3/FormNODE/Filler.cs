using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormNODE
{
    class Filler
    {
        //Кораблев Алексей - AcoaAera
        private static List<Node> nodes;
        private static List<Question> questions;

        public static List<Node> NodesFill()
        {
            nodes = new List<Node>();

            #region Узлы

            #region Категория_11
            Node Категория = new Node("Категория");
            #region Гуманитарный
            Node Гуманитарный = new Node("Гуманитарный");
            Node Социология = new Node("Социология");
            Node История = new Node("История");
            #endregion
            #region Медицинский
            Node Медицинский = new Node("Медицинский");
            Node Биология = new Node("Биология");
            Node Химия = new Node("Химия");
            #endregion
            #region Технический
            Node Технический = new Node("Технический");
            Node Математика = new Node("Математика");
            Node Физика = new Node("Физика");
            Node Информатика = new Node("Информатика");
            #endregion
            #endregion

            #region Вуз_14
            Node Вуз = new Node("ВУЗ");
            #region Топ5
            Node Топ5 = new Node("Топ-5");
            Node СПбГу = new Node("СПбГУ");
            Node МГУ = new Node("МГУ");
            Node Баумана = new Node("Баумана");
            #endregion
            #region Топ6_20
            Node Топ6_20 = new Node("Топ 6-20");
            Node МГИМО = new Node("МГИМО");
            Node РУДН = new Node("РУДН");
            Node УрФУ = new Node("УрФУ");
            Node ТГУ = new Node("ТГУ");
            #endregion
            #region ПрочиеВузы
            Node ПрочиеВузы = new Node("Прочие ВУЗы");
            Node ПНИПУ = new Node("ПНИПУ");
            Node ПГФА = new Node("ПГФА");
            Node КГТУ = new Node("КГТУ");
            #endregion
            #endregion

            #region Город_7
            Node Город = new Node("Город");
            Node Санкт_Петербург = new Node("Санкт-Петербург");
            Node Москва = new Node("Москва");
            Node Екатеринбург = new Node("Екатеринбург");
            Node Томск = new Node("Томск");
            Node Пермь = new Node("Пермь");
            Node Калининград = new Node("Калининград");
            #endregion

            #region Опытность_7
            Node Опыт_работы = new Node("Опыт работы");
            Node Старше_21_года = new Node("Старше 21 года");
            Node Высокий_уровень = new Node("Высокий уровень");
            Node Средний_уровень1 = new Node("Средний уровень 1");
            Node Средний_уровень2 = new Node("Средний уровень 2");
            Node Низкий_уровень = new Node("Низкий уровень");
            Node Уровень_опыта = new Node("Уровень опыта");
            #endregion

            #region Наличие_наград
            Node Наличие_наград = new Node("Наличие наград");
            #endregion

            #endregion

            #region Добавлене узлов в список
            nodes.Add(Категория);
            nodes.Add(Гуманитарный);
            nodes.Add(Социология);
            nodes.Add(История);
            nodes.Add(Медицинский);
            nodes.Add(Биология);
            nodes.Add(Химия);
            nodes.Add(Технический);
            nodes.Add(Математика);
            nodes.Add(Физика);
            nodes.Add(Информатика);
            nodes.Add(Вуз);
            nodes.Add(Топ5);
            nodes.Add(СПбГу);
            nodes.Add(МГУ);
            nodes.Add(Баумана);
            nodes.Add(Топ6_20);
            nodes.Add(МГИМО);
            nodes.Add(РУДН);
            nodes.Add(УрФУ);
            nodes.Add(ТГУ);
            nodes.Add(ПрочиеВузы);
            nodes.Add(ПНИПУ);
            nodes.Add(ПГФА);
            nodes.Add(КГТУ);
            nodes.Add(Город);
            nodes.Add(Санкт_Петербург);
            nodes.Add(Москва);
            nodes.Add(Екатеринбург);
            nodes.Add(Томск);
            nodes.Add(Пермь);
            nodes.Add(Калининград);
            nodes.Add(Опыт_работы);
            nodes.Add(Старше_21_года);
            nodes.Add(Высокий_уровень);
            nodes.Add(Средний_уровень1);
            nodes.Add(Средний_уровень2);
            nodes.Add(Низкий_уровень);
            nodes.Add(Уровень_опыта);
            nodes.Add(Наличие_наград);
            #endregion

            #region Связи

            #region Категория_11

            #region Категория
            Категория.LinkAdd(new Link(Гуманитарный, Категория, LinksTypes.AKO));
            Категория.LinkAdd(new Link(Медицинский, Категория, LinksTypes.AKO));
            Категория.LinkAdd(new Link(Технический, Категория, LinksTypes.AKO));
            #endregion

            #region Гуманитарный
            Гуманитарный.LinkAdd(new Link(СПбГу, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(МГУ, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(Баумана, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(МГИМО, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(РУДН, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(УрФУ, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(ТГУ, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(ПНИПУ, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(КГТУ, Гуманитарный, LinksTypes.Contains));
            Гуманитарный.LinkAdd(new Link(История, Гуманитарный, LinksTypes.Required));
            Гуманитарный.LinkAdd(new Link(Социология, Гуманитарный, LinksTypes.Required));
            #endregion

            #region Медицинский
            Медицинский.LinkAdd(new Link(СПбГу, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(МГУ, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(МГИМО, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(РУДН, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(УрФУ, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(ПГФА, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(КГТУ, Медицинский, LinksTypes.Contains));
            Медицинский.LinkAdd(new Link(Биология, Медицинский, LinksTypes.Required));
            Медицинский.LinkAdd(new Link(Химия, Медицинский, LinksTypes.Required));
            #endregion

            #region Технический
            Технический.LinkAdd(new Link(СПбГу, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(МГУ, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(Баумана, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(МГИМО, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(РУДН, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(УрФУ, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(ТГУ, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(ПНИПУ, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(КГТУ, Технический, LinksTypes.Contains));
            Технический.LinkAdd(new Link(Математика, Технический, LinksTypes.Required));
            Технический.LinkAdd(new Link(Физика, Технический, LinksTypes.Required));
            Технический.LinkAdd(new Link(Информатика, Технический, LinksTypes.Required));
            #endregion

            #endregion

            #region Вуз_14

            #region Вуз
            Вуз.LinkAdd(new Link(Топ5, Вуз, LinksTypes.AKO));
            Вуз.LinkAdd(new Link(Топ6_20, Вуз, LinksTypes.AKO));
            Вуз.LinkAdd(new Link(ПрочиеВузы, Вуз, LinksTypes.AKO));
            #endregion

            #region Топ5
            Топ5.LinkAdd(new Link(Баумана, Топ5, LinksTypes.Is_Instance));
            Топ5.LinkAdd(new Link(МГУ, Топ5, LinksTypes.Is_Instance));
            Топ5.LinkAdd(new Link(СПбГу, Топ5, LinksTypes.Is_Instance));
            Топ5.LinkAdd(new Link(Наличие_наград, Топ5, LinksTypes.Required));
            Топ5.LinkAdd(new Link(Высокий_уровень, Топ5, LinksTypes.Required));
            #endregion

            #region Топ6_20
            Топ6_20.LinkAdd(new Link(Средний_уровень1, Топ6_20, LinksTypes.Required));
            Топ6_20.LinkAdd(new Link(Средний_уровень2, Топ6_20, LinksTypes.Required));
            Топ6_20.LinkAdd(new Link(МГИМО, Топ6_20, LinksTypes.Is_Instance));
            Топ6_20.LinkAdd(new Link(РУДН, Топ6_20, LinksTypes.Is_Instance));
            Топ6_20.LinkAdd(new Link(УрФУ, Топ6_20, LinksTypes.Is_Instance));
            Топ6_20.LinkAdd(new Link(ТГУ, Топ6_20, LinksTypes.Is_Instance));
            #endregion

            #region Прочие_Вузы
            ПрочиеВузы.LinkAdd(new Link(ПНИПУ, ПрочиеВузы, LinksTypes.Is_Instance));
            ПрочиеВузы.LinkAdd(new Link(ПГФА, ПрочиеВузы, LinksTypes.Is_Instance));
            ПрочиеВузы.LinkAdd(new Link(КГТУ, ПрочиеВузы, LinksTypes.Is_Instance));
            ПрочиеВузы.LinkAdd(new Link(Низкий_уровень, ПрочиеВузы, LinksTypes.Required));
            #endregion

            #endregion

            #region Город_7

            #region Город
            Город.LinkAdd(new Link(Санкт_Петербург, Город, LinksTypes.Is_Instance));
            Город.LinkAdd(new Link(Москва, Город, LinksTypes.Is_Instance));
            Город.LinkAdd(new Link(Пермь, Город, LinksTypes.Is_Instance));
            Город.LinkAdd(new Link(Калининград, Город, LinksTypes.Is_Instance));
            Город.LinkAdd(new Link(Томск, Город, LinksTypes.Is_Instance));
            Город.LinkAdd(new Link(Екатеринбург, Город, LinksTypes.Is_Instance));
            #endregion

            #region Санкт_Петербург
            Санкт_Петербург.LinkAdd(new Link(СПбГу, Санкт_Петербург, LinksTypes.Located));
            #endregion

            #region Москва
            Москва.LinkAdd(new Link(МГУ, Москва, LinksTypes.Located));
            Москва.LinkAdd(new Link(Баумана, Москва, LinksTypes.Located));
            Москва.LinkAdd(new Link(МГИМО, Москва, LinksTypes.Located));
            Москва.LinkAdd(new Link(РУДН, Москва, LinksTypes.Located));
            #endregion

            #region Пермь
            Пермь.LinkAdd(new Link(ПНИПУ, Пермь, LinksTypes.Located));
            Пермь.LinkAdd(new Link(ПГФА, Пермь, LinksTypes.Located));
            #endregion

            #region Калининград
            Калининград.LinkAdd(new Link(КГТУ, Калининград, LinksTypes.Located));
            #endregion

            #region Томск
            Томск.LinkAdd(new Link(ТГУ, Томск, LinksTypes.Located));
            #endregion

            #region Екатеринбург
            Екатеринбург.LinkAdd(new Link(УрФУ, Город, LinksTypes.Located));
            #endregion

            #endregion

            #region Опытность_7

            #region Уровень_опыта
            Уровень_опыта.LinkAdd(new Link(Высокий_уровень, Уровень_опыта, LinksTypes.Is_Instance));
            Уровень_опыта.LinkAdd(new Link(Средний_уровень1, Уровень_опыта, LinksTypes.Is_Instance));
            Уровень_опыта.LinkAdd(new Link(Средний_уровень2, Уровень_опыта, LinksTypes.Is_Instance));
            Уровень_опыта.LinkAdd(new Link(Низкий_уровень, Уровень_опыта, LinksTypes.Is_Instance));
            #endregion

            #region Высокий_уровень
            Высокий_уровень.LinkAdd(new Link(Старше_21_года, Высокий_уровень, LinksTypes.Required));
            Высокий_уровень.LinkAdd(new Link(Опыт_работы, Высокий_уровень, LinksTypes.Required));
            #endregion

            #region Средний_уровень1
            Средний_уровень1.LinkAdd(new Link(Старше_21_года, Средний_уровень1, LinksTypes.NotRequired));
            Средний_уровень1.LinkAdd(new Link(Опыт_работы, Средний_уровень1, LinksTypes.Required));
            #endregion

            #region Средний_уровень2
            Средний_уровень2.LinkAdd(new Link(Старше_21_года, Средний_уровень2, LinksTypes.Required));
            Средний_уровень2.LinkAdd(new Link(Опыт_работы, Средний_уровень2, LinksTypes.NotRequired));
            #endregion

            #region Низкий_уровень
            Низкий_уровень.LinkAdd(new Link(Старше_21_года, Низкий_уровень, LinksTypes.NotRequired));
            Низкий_уровень.LinkAdd(new Link(Опыт_работы, Низкий_уровень, LinksTypes.NotRequired));
            #endregion

            #endregion

            #endregion

            return nodes;
        }

        public static List<Question> QuestionsListFill()
        {
            questions = new List<Question>();

            Question AKOandIsInstance = new Question("Является ли: AKO, IS-INSTANCE");
            AKOandIsInstance.LinkAdd(LinksTypes.Is_Instance);
            AKOandIsInstance.LinkAdd(LinksTypes.AKO);

            Question required = new Question("Обязателен");
            required.LinkAdd(LinksTypes.Required);

            Question located = new Question("Находится");
            located.LinkAdd(LinksTypes.Located);

            Question contains = new Question("Содержит");
            contains.LinkAdd(LinksTypes.Contains);

            Question notRequired = new Question("Необязателен");
            notRequired.LinkAdd(LinksTypes.NotRequired);

            questions.Add(AKOandIsInstance);
            questions.Add(required);
            questions.Add(located);
            questions.Add(contains);
            questions.Add(notRequired);

            return questions;
        }
    }
}
