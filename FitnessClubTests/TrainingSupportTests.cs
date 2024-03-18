using FitnessClubBusinessLogic.Business_Logic;
using System.Linq;
using Xunit;

namespace FitnessClubBusinessLogicTests
{
    public class TrainingSupportTests//готов
    {
        [Fact]
        public void HelpWithChoiceTestContainsAllGoals()
        {
            //Arrange
            TrainingSupport trainingSupport = new TrainingSupport();
            var message = "1-я цель, 2-я цель";
            string[] goals = {"1-я цель", "2-я цель"};
            FitnessClub fitnessClub = new FitnessClub();
            var training = new Training("Тип тренировки", goals, "Описание");
            fitnessClub.Trainings.Add(training);
            //Act
            var actual = trainingSupport.HelpWithChoice(fitnessClub, message);
            //Assert
            Assert.Contains(goals[0], actual);
            Assert.Contains(goals[1], actual);
        }

        [Fact]
        public void HelpWithChoiceTestContainsPartOfGoalsGoals()
        {
            //Arrange
            TrainingSupport trainingSupport = new TrainingSupport();
            var message = "1-я цель, Не цель";
            string[] goals = { "1-я цель", "2-я цель" };
            FitnessClub fitnessClub = new FitnessClub();
            var training = new Training("Тип тренировки", goals, "Описание");
            fitnessClub.Trainings.Add(training);
            //Act
            var actual = trainingSupport.HelpWithChoice(fitnessClub, message);
            //Assert
            Assert.Contains(goals[0], actual);
            Assert.DoesNotContain(goals[1], actual);
        }

        [Fact]
        public void HelpWithChoiceTestDoesntContainsGoals()
        {
            //Arrange
            TrainingSupport trainingSupport = new TrainingSupport();
            var message = "Не цель, Не цель";
            string[] goals = { "1-я цель", "2-я цель" };
            FitnessClub fitnessClub = new FitnessClub();
            var training = new Training("Тип тренировки", goals, "Описание");
            fitnessClub.Trainings.Add(training);
            //Act
            var actual = trainingSupport.HelpWithChoice(fitnessClub, message);
            //Assert
            Assert.DoesNotContain(goals[0], actual);
            Assert.DoesNotContain(goals[1], actual);
        }
    }
}
