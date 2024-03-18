using FitnessClubBusinessLogic.Business_Logic;
using System.Collections.Generic;
using Xunit;

namespace FitnessClubBusinessLogicTests
{
    public class MainGoalsTest
    {
        [Fact]
        public void AddGoalsTestAddValidation()//добавить тест на проверку добавления таких же целей с разных тренировок
        {
            //Arrange
            var mainGoals = new MainGoals();
            string[] goals = { "1-я цель", "2-я цель" };
            var tr = new List<Training>();
            var training = new Training("Тип тренировки", goals, "Описание");
            tr.Add(training);
            //Act
            mainGoals.AddGoals(tr);
            //Assert
            Assert.Equal(goals[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals[1], mainGoals.MainGoalsDictionary["2"]);
        }

        [Fact]
        public void AddGoalsTestCheckAddingOneSameGoal()//добавить тест на проверку добавления таких же целей с разных тренировок
        {
            //Arrange
            var mainGoals = new MainGoals();
            string[] goals1 = { "1-я цель", "2-я цель" };
            string[] goals2 = { "1-я цель", "3-я цель" };
            var tr = new List<Training>();
            var training1 = new Training("Тип тренировки", goals1, "Описание");
            var training2 = new Training("Тип тренировки", goals2, "Описание");
            tr.Add(training1);
            tr.Add(training2);
            //Act
            mainGoals.AddGoals(tr);
            //Assert
            Assert.Equal(goals1[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals2[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals1[1], mainGoals.MainGoalsDictionary["2"]);
            Assert.Equal(goals2[1], mainGoals.MainGoalsDictionary["3"]);
        }

        [Fact]
        public void AddGoalsTestCheckAddingTwoSameGoal()//добавить тест на проверку добавления таких же целей с разных тренировок
        {
            //Arrange
            var mainGoals = new MainGoals();
            string[] goals1 = { "1-я цель", "2-я цель" };
            string[] goals2 = { "1-я цель", "2-я цель" };
            var tr = new List<Training>();
            var training1 = new Training("Тип тренировки", goals1, "Описание");
            var training2 = new Training("Тип тренировки", goals2, "Описание");
            tr.Add(training1);
            tr.Add(training2);
            //Act
            mainGoals.AddGoals(tr);
            //Assert
            Assert.Equal(goals1[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals2[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals1[1], mainGoals.MainGoalsDictionary["2"]);
            Assert.Equal(goals2[1], mainGoals.MainGoalsDictionary["2"]);
        }

        [Fact]
        public void AddGoalsTestCheckAddingDifferentGoals()//добавить тест на проверку добавления таких же целей с разных тренировок
        {
            //Arrange
            var mainGoals = new MainGoals();
            string[] goals1 = { "1-я цель", "2-я цель" };
            string[] goals2 = { "3-я цель", "4-я цель" };
            var tr = new List<Training>();
            var training1 = new Training("Тип тренировки", goals1, "Описание");
            var training2 = new Training("Тип тренировки", goals2, "Описание");
            tr.Add(training1);
            tr.Add(training2);
            //Act
            mainGoals.AddGoals(tr);
            //Assert
            Assert.Equal(goals1[0], mainGoals.MainGoalsDictionary["1"]);
            Assert.Equal(goals1[1], mainGoals.MainGoalsDictionary["2"]);
            Assert.Equal(goals2[0], mainGoals.MainGoalsDictionary["3"]);
            Assert.Equal(goals2[1], mainGoals.MainGoalsDictionary["4"]);
        }
    }
}
