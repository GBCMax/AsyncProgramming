using System;

namespace FitnessClubPatterns
{
    /// <summary>
    /// Класс, служащий продуктом(человеком). Содержит три части(имя, фамилия, возраст).
    /// </summary>
    public class ProductPerson
    {
        /// <summary>
        /// внутренние переменные
        /// </summary>
        private string name, secondName, age;


        /// <summary>
        /// Конструктор
        /// </summary>
        public ProductPerson()
        {
            name = "";
            secondName = "";
            age = "";
        }


        /// <summary>
        /// Методы доступа
        /// </summary>
        /// <returns></returns>
        public string GetSecondName() { return secondName; }
        public string GetName() { return name; }
        public string GetAge() { return age; }
        
        public void SetSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAge(string age)
        {
            this.age = age;
        }
    }
}
