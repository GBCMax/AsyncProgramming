using FitnessClubBusinessLogic.Business_Logic;
using FitnessClubPatterns;
using Xunit;

namespace FitnessClubBusinessLogicTests
{
    public class GroupTests //�������� ������� ��������� ��� �������� ���������
    {
        [Fact]
        public void AddPersonTestPattern()//wtf?
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
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
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            Person p = new Person("�������", "����", "20");
            //Act
            var actual = group.AddPerson(p);
            //Assert
            Assert.Equal("�� ���������� � ������!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUAlreadyInGroup()
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            Person p = new Person("�������", "����", "20");
            group.AddPerson(p);
            //Act
            var actual = group.AddPerson(new Person("�������", "����", "20"));
            //Assert
            Assert.Equal("�� ��� �������� � ��� ������!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenGroupAlreadyFull()
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            group.AddPerson(new Person("������", "�������", "21"));
            group.AddPerson(new Person("������", "�������", "19"));
            group.AddPerson(new Person("������", "�������", "23"));
            //Act
            var actual = group.AddPerson(new Person("������", "�������", "20"));
            //Assert
            Assert.Equal("������ ���������!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontPassByAge()
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            //Act
            var actual = group.AddPerson(new Person("�����", "�����-��", "74"));
            //Assert
            Assert.Equal("�� �� ��������� ���������� �����������!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontEnterAName()
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            //Act
            var actual = group.AddPerson(new Person("�������", "", "21"));
            //Assert
            Assert.Equal("�� �� ����� ���!", actual);
        }

        [Fact]
        public void Ability_to_join_a_groupTestWhenUDontEnterASecondName()
        {
            //Arrange
            string[] goals = { "1-� ����", "2-� ����" };
            var training = new Training("��� ����������", goals, "��������");
            var group = new Group("������ � ", training);
            //Act
            var actual = group.AddPerson(new Person("", "���", "21"));
            //Assert
            Assert.Equal("�� �� ����� �������!", actual);
        }
    }
}