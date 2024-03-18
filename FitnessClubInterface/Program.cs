using FitnessClubInterface.User_Interface;

namespace FitnessClubInterface
{
    internal class Program
    {
        /// <summary>
        /// Метод, запускающий программу
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)//конструктор интерфейса в menuinterface
        {
            var mi = new MenuInterface(new UserInterface());
        }
    }
}