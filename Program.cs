using System;

namespace TicTacToe
{
    class Program
    {

        static int MATRIX_SIZE = 3;
        //y, x
        //static char[,] matrix = new char[3, 3] {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};

        // <summary>
        // Matrix array [y, x]
        // </summary>
        // <value>Empty matrix</value>
        static char[,] matrix = new char[3, 3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}};

        static void PrintMatrix()
        {
            for (int y = 0; y < MATRIX_SIZE; y++)
            {
                string line = "";
                for (int x = 0; x < MATRIX_SIZE; x++)
                {
                    //Interpolate string
                    // Console.WriteLine($"[y, x] = {y}, {x}");
                    // Console.Write(matrix[y, x]);
                    line += matrix[y, x] + "|";
                }
                line = line.Substring(0, line.Length - 1);
                Console.WriteLine(line);
                Console.WriteLine("------");
            }
        }

        // <summary>
        // Adds a value to the matrix in the specified position.
        // </summary>
        // <param name="value">value to add</param>
        // <param name="y">y position</param>
        // <param name="x">x position</param>
        static void AddValue(char value, int y, int x)
        {
            matrix[y, x] = value;
        }

        static void InputRequest()
        {
            Console.WriteLine("Write down the coordinates in the form [y, x] where you want to place your move.");
            Console.WriteLine("And press enter.");
            string userInputCoordinates = Console.ReadLine();

            //Remove spaces
            userInputCoordinates = userInputCoordinates.Replace(" ", "");

            //Separate in an array values with ","
            string[] coordinates = userInputCoordinates.Split(",");

            //Convert coordinates to integer type
            int y = Convert.ToInt32(coordinates[0]);
            int x = Convert.ToInt32(coordinates[1]);

            AddValue('X', y, x);
        }

        static bool IsValueInMatrix(int y, int x)
        {
            bool isEmpty = matrix[y,x] == ' ';
            return !isEmpty;
        }

        static void AIRequest() {
            Random r = new Random();
            //Number between 0 and two , must be an integer
            //The int changes between parenthesis transform a thing in another

            bool validPositionSelected = false;

            int y = 0;
            int x = 0;

            while (!validPositionSelected)
            {
                y = (int)Math.Floor(r.NextDouble() * 3);
                x = Convert.ToInt32(Math.Floor(r.NextDouble() * 3));
                bool isValuedDefined = IsValueInMatrix(y, x);

                validPositionSelected = !isValuedDefined;
            }

            AddValue ('O', y, x);
        }


        static void Main(string[] args)
        {
            PrintMatrix();
            Console.WriteLine();
            InputRequest();
            AIRequest();
            PrintMatrix();
            Console.WriteLine();

            // bool gameEnded = false;
            // int turns = 0;

            // while(!gameEnded) {
            //     InputRequest();
            //     turns++;

            //     //Check if user won
            //     gameEnded = CheckThreeLines();

            //     //End after 9 turns
            //     if (turns >= 9) {
            //         gameEnded = true;
            //     }

            //     if (!gameEnded) {
            //         AIRequest();
            //         turns++;
            //         //Check if AI won
            //         gameEnded = CheckThreeLines();
            //     }

        }

    }
}

