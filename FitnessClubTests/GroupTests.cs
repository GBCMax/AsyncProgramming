using FitnessClubBusinessLogic.Business_Logic;
using FitnessClubPatterns;
using Xunit;

namespace FitnessClubBusinessLogicTests
{
    public class GroupTests //добавить паттерн строитель для создания элементов
    {
        [Fact]
        public void AddPersonTestPattern()//wtf?
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            ProductPerson productPerson;
            BuilderPerson B = new ConcreteBuilderPerson();
            DirectorPerson D = new DirectorPerson(B);
            D.Construct1();
            productPerson = B.GetProduct();
            Person p = new Person(productPerson.GetSecondName(), productPerson.GetName(), productPerson.GetAge());
            //Act
            group.AddPerson(p);
            //Assert
            Assert.Equal(p.SecondName, group.People[0].SecondName);
            Assert.Equal(p.Name, group.People[0].Name);
            Assert.Equal(p.Age, group.People[0].Age);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUCanJoinAGroup()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            Person p = new Person("Елисеев", "Макс", "20");
            //Act
            var actual = group.AddPerson(p);
            //Assert
            Assert.Equal("Вы записались в группу!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUAlreadyInGroup()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            Person p = new Person("Елисеев", "Макс", "20");
            group.AddPerson(p);
            //Act
            var actual = group.AddPerson(new Person("Елисеев", "Макс", "20"));
            //Assert
            Assert.Equal("Вы уже записаны в эту группу!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenGroupAlreadyFull()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            group.AddPerson(new Person("Первый", "человек", "21"));
            group.AddPerson(new Person("Второй", "человек", "19"));
            group.AddPerson(new Person("Третий", "человек", "23"));
            //Act
            var actual = group.AddPerson(new Person("Лишний", "человек", "20"));
            //Assert
            Assert.Equal("Группа заполнена!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontPassByAge()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            //Act
            var actual = group.AddPerson(new Person("Дедок", "какой-то", "74"));
            //Assert
            Assert.Equal("Вы не проходите возрастное ограничение!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontEnterAName()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            //Act
            var actual = group.AddPerson(new Person("Фамилия", "", "21"));
            //Assert
            Assert.Equal("Вы не ввели имя!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontEnterASecondName()
        {
            //Arrange
            string[] goals = { "1-я цель", "2-я цель" };
            var training = new Training("Тип тренировки", goals, "Описание");
            var group = new Group("Группа № ", training);
            //Act
            var actual = group.AddPerson(new Person("", "Имя", "21"));
            //Assert
            Assert.Equal("Вы не ввели фамилию!", actual);
        }
    }
}