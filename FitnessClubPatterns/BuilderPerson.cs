using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessClubPatterns
{
    /// <summary>
    /// Класс, который служит интерфейсом между распорядителем и конкретным строителем.
    /// </summary>
    public abstract class BuilderPerson
    {
        /// <summary>
        /// Метод, создающий продукт(в нашем случае человека)
        /// </summary>
        public abstract void CreateProduct();


        /// <summary>
        /// Методы, которые строят части продукта(человека)
        /// </summary>
        /// <param name="item"></param>
        public abstract void BuildSecondName(string item);
        public abstract void BuildName(string item);
        public abstract void BuildAge(string item);


        /// <summary>
        /// Метод, возвращающий продукт клиенту
        /// </summary>
        /// <returns></returns>
        public abstract ProductPerson GetProduct();
    }
}
