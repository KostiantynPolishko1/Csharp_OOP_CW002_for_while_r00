class Program
{
    static void Main(string[] args)
    {
        const int MIN_SIZE = 3;
        const int MAX_SIZE = 12;
        const char border = '*';
        const char field = 'x';

        ConsoleColor[] color = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Blue };
        string[] moves = { "Up -> UpArrow", "Right -> RightArrow", "Down -> DownArrow", "Left -> LeftArrow", "Exit -> Escape" };

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;

        int length;
        int index;
        bool flag;
        do
        {
            Console.Write("\tenter size SQ -> ");
            flag = int.TryParse(Console.ReadLine(), out length);
            if (!flag)
            {
                Console.WriteLine("\tERROR!");
                continue;
            }
            else if (Math.Abs(length) < MIN_SIZE || Math.Abs(length) > MAX_SIZE)
            {
                Console.Write($"\tOUT OF SIZE: MIN{MIN_SIZE} - MAX {MAX_SIZE}\n");
                flag = false;
            }

        } while (!flag);


        for (int i = 0; i != color.Length; i++)
        {
            Console.Write($"\n\t{i + 1} - {color[i]} color");
        }

        do
        {
            Console.Write("\n\tselect color of SQ -> ");
            flag = int.TryParse(Console.ReadLine(), out index);
            if (!flag)
            {
                Console.Write("\n\tERROR!");
            }
            else if (Math.Abs(index) > color.Length)
            {
                Console.Write("\n\tOUT OF INDEX COLOR!");
                flag = false;
            }

        } while (!flag);

        Console.Clear();

        index--;
        int row = 0, col = 0;

        //string setPosRow = "", setPosCol = "";
        string setPosRow = new string('\n', row);
        string setPosCol = new string(' ', col);

        ConsoleKeyInfo press;

        do
        {
            Console.Write("Menu Buttons\n");
            for (int i = 0; i < moves.Length; i++)
                Console.Write(moves[i] + " | ");

            Console.WriteLine();
            Console.Write(setPosRow);

            //redraw figure SQUARE
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(setPosCol);

                Console.BackgroundColor = ConsoleColor.Green;
                for (int n = 0; n < length + 2; n++)
                    Console.Write(" " + border);
                Console.Write("\n");

                for (int i = 0; i < length; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(setPosCol);

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" " + border);
                    Console.BackgroundColor = color[index];
                    for (int j = 0; j < length; j++)
                    {
                        Console.Write(" " + field);
                    }
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" " + border + "\n");
                }

                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(setPosCol);

                Console.BackgroundColor = ConsoleColor.Green;
                for (int n = 0; n < length + 2; n++)
                    Console.Write(" " + border);
                Console.Write("\n");
            }

            press = Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            //setPosRow = "";
            //setPosCol = "";

            if (press.Key == ConsoleKey.UpArrow)
                row--;
            else if (press.Key == ConsoleKey.RightArrow)
                col++;
            else if (press.Key == ConsoleKey.DownArrow)
                row++;
            else if (press.Key == ConsoleKey.LeftArrow)
                col--;

            row = row < 0 ? 0 : row;
            col = col < 0 ? 0 : col;

            setPosRow = new string('\n', row);
            setPosCol = new string(' ', col);

            /*for (int i = 0; i < row; i++)
                setPosRow += "\n";

            for (int i = 0; i < col; i++)
                setPosCol += " ";*/

        } while (press.Key != ConsoleKey.Escape);

        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
    }
}