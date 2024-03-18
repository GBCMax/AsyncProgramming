using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessClubPatterns
{
    /// <summary>
    /// Класс-распорядитель, содержит методы построения объекта Product из частей
    /// </summary>
    public class DirectorPerson
    {
        /// <summary>
        /// Ссылка на builder
        /// </summary>
        private BuilderPerson builder;


        /// <summary>
        /// Конструктор - инициализируется экземпляром Builder
        /// </summary>
        /// <param name="_builder"></param>
        public DirectorPerson(BuilderPerson _builder)
        {
            builder = _builder;
        }


        /// <summary>
        /// Метод, который строит объект класса Product из частей
        /// </summary>
        public void Construct1()
        {
            //Построить экземпляр класса Product
            builder.CreateProduct();
            builder.BuildSecondName("Елисеев");
            builder.BuildName("Максим");
            builder.BuildAge("20");
        }
        public void Construct2()
        {
            //Построить экземпляр класса Product
            builder.CreateProduct();
            builder.BuildSecondName("Криштиану");
            builder.BuildName("Роналдо");
            builder.BuildAge("34");
        }
        public void Construct3()
        {
            //Построить экземпляр класса Product
            builder.CreateProduct();
            builder.BuildSecondName("Лионель");
            builder.BuildName("Месси");
            builder.BuildAge("32");
        }
        public void Construct4()
        {
            //Построить экземпляр класса Product
            builder.CreateProduct();
            builder.BuildSecondName("Артем");
            builder.BuildName("Дзюба");
            builder.BuildAge("30");
        }
    }
}
