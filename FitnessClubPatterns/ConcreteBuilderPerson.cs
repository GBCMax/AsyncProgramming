using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessClubPatterns
{
    /// <summary>
    /// Класс - конкретный строитель, наследует абстрактный класс Builder
    /// </summary>
    public class ConcreteBuilderPerson : BuilderPerson
    {
        /// <summary>
        /// Внутренняя переменная - ссылка на продукт
        /// </summary>
        private ProductPerson currentBuilder;


        /// <summary>
        /// Методы, которые объявляются а абстрактном классе Builder, их нужно реализовывать.
        /// </summary>
        public override void CreateProduct()
        {
            currentBuilder = new ProductPerson();
        }
        public override void BuildSecondName(string item)
        {
            currentBuilder.SetSecondName(item);
        }
        public override void BuildName(string item)
        {
            currentBuilder.SetName(item);
        }
        
        public override void BuildAge(string item)
        {
            currentBuilder.SetAge(item);
        }
        public override ProductPerson GetProduct()
        {
            return currentBuilder;
        }
    }
}
