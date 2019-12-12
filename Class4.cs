using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleXiangqi
{
    class control//这个类的作用我觉得是能把main类变得很简洁
    {
        public board Board = new board();
        public board copyBoard = new board();
        string[,] Display = new string[10, 11];
        string[,] Display2 = new string[10, 11];
        string color = "red";//这个是在后面玩家切换回合使用，显示黑色走

        public bool Gameover()
        {
            bool alive;
            alive = Board.GeneralAlive();
            return alive;
        }

        public bool WhoWin()
        {
            bool alive;
            alive = Board.blackGeneralAlive();
            return alive;
        }

        public void display()//展示棋盘
        {
                Display[0, 0] = "  ";
                Display[0, 1] = "零";
                Display[0, 2] = "一";
                Display[0, 3] = "二";
                Display[0, 4] = "三";
                Display[0, 5] = "四";
                Display[0, 6] = "五";
                Display[0, 7] = "六";
                Display[0, 8] = "七";
                Display[0, 9] = "八";
                Display[0, 10] = "九";
                Display[1, 0] = "零";
                Display[2, 0] = "一";
                Display[3, 0] = "二";
                Display[4, 0] = "三";
                Display[5, 0] = "四";
                Display[6, 0] = "五";
                Display[7, 0] = "六";
                Display[8, 0] = "七";
                Display[9, 0] = "八";

                for (int j = 1; j < 10; j++)
                {

                    Display[j, 1] = "┬ ";
                    Display[j, 5] = "┴ ";
                    Display[j, 6] = "┬ ";
                    Display[j, 10] = "┴ ";
                }
                for (int i = 1; i < 11; i++)
                    {
                            Display[1, i] = "├ ";
                            Display[9, i] = "┤ ";
                    }

                Display[1, 1] = "┌ ";
                Display[9, 1] = "┐ ";
                Display[1, 10] = "└ ";
                Display[9, 10] = "┘ ";
            for (int j = 0; j < 11; j++)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                    if (i == 0 || j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Display[i, j]);
                    }
                    else if (Display[i, j] == "├ " || Display[i, j] == "┤ ")
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Display[i, j]);
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(Display[i, j]);
                        }
                    }
                    else if (j == 1 || j == 10)
                    {
                        if(i != 4 && i != 5 && i != 6)
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(Display[i, j]);
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                            }
                        }
                        else
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "×";
                                Console.Write(Display[i, j]);
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                            }
                        }
                    }
                    else if (j == 5 || j == 6)
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Display[i, j]);
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(Display[i, j]);
                        }
                    }
                    else if (i == 4 || i == 5 || i == 6)
                    {
                        if (j == 1 || j == 2 || j == 3 || j == 10 || j == 8 || j == 9)
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "×";
                                Console.Write(Display[i, j]);
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                            }
                        }
                        else
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "┼ ";
                                Console.Write(Display[i, j]);
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                            }
                        }
                    }
                    else
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Display[i, j] = "┼ ";
                            Console.Write(Display[i, j]);
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(Display[i, j]);
                        }
                    }
                        }
                        Console.WriteLine("");
                    }
                  Console.ForegroundColor = ConsoleColor.White;
                  Console.WriteLine("");
          }

        public void Playchoose()//选择棋子
        {
            string receiveBegin;
            string receiveEnd;
            string[] begin = new string[2];
            string[] end = new string[2];
            bool inputcondition1 = false;
            bool inputcondition2 = false;

            Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
            receiveBegin = Console.ReadLine();
            begin = receiveBegin.Split(',');

            while (!inputcondition1)//限定输入的坐标反馈错误给用户
            {


                bool condition1 = false;
                if (int.Parse(begin[0]) > 8 || int.Parse(begin[0]) < 0 || int.Parse(begin[1]) < 0 || int.Parse(begin[0]) > 9)//看看输入是不是范围以内的值
                {
                    Console.WriteLine("You should in put input colum that is 0-8 and row that is 0-9. Please input again!");
                    Console.WriteLine("");
                    Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
                    receiveBegin = Console.ReadLine();
                    begin = receiveBegin.Split(',');
                }
                condition1 = true;

                bool condition2 = false;
                if (Board.Chess[int.Parse(begin[0]), int.Parse(begin[1])].Getname() == "nochess")//看看输入是不是玩家现在颜色的棋子
                {
                    Console.WriteLine("There is no chess in your input aix!");
                    Console.WriteLine("");
                    Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
                    receiveBegin = Console.ReadLine();
                    begin = receiveBegin.Split(',');
                    condition1 = false;
                }
                condition2 = true;

                bool condition3 = false;
                if (Board.GetChessColor(int.Parse(begin[0]), int.Parse(begin[1])) != color)//看看输入是不是玩家现在颜色的棋子
                {
                    Console.WriteLine($"Oh! You are {color} player. Please input the aix of {color} piece!");
                    Console.WriteLine("");
                    Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
                    receiveBegin = Console.ReadLine();
                    begin = receiveBegin.Split(',');
                    condition2 = false;
                }
                condition3 = true;

                inputcondition1 = condition1 && condition2 && condition3 ;
            }

            DisplayChoose(int.Parse(begin[0]), int.Parse(begin[1]));

            Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
            receiveEnd = Console.ReadLine();
            end = receiveEnd.Split(',');

            while (!inputcondition2)//限定输入的坐标反馈错误给用户
            {
                bool condition1 = false;
                if (int.Parse(end[0]) > 8 || int.Parse(end[0]) < 0 || int.Parse(end[1]) < 0 || int.Parse(end[0]) > 9)//看看输入是不是范围以内的值
                {
                    Console.WriteLine("You should in put input colum that is 0-8 and row that is 0-9. Please input again!");
                    Console.WriteLine("");
                    Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
                    receiveEnd = Console.ReadLine();
                    end = receiveEnd.Split(',');
                }
                condition1 = true;

                bool condition2 = false;
                if (receiveBegin == receiveEnd)//看看初始点和去的点是不是同一个点
                {
                    Console.WriteLine("You start at the same place as you finish! ");
                    Console.WriteLine("");
                    Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
                    receiveEnd = Console.ReadLine();
                    end = receiveEnd.Split(',');
                    condition1 = false;
                }
                condition2 = true;

                bool condition3 = false;
                if ((Board.GetChessColor(int.Parse(end[0]), int.Parse(end[1])) == color))//看看是不是吃本方棋子
                {
                    Console.WriteLine($"Oh! You are {color} player. You cannot eat your {color} chess!");
                    Console.WriteLine("");
                    Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
                    receiveBegin = Console.ReadLine();
                    begin = receiveBegin.Split(',');
                    condition2 = false;
                }
                condition3 = true;

                bool condition4 = false;
                if (!(Board.Movemethod(int.Parse(begin[0]), int.Parse(begin[1]), int.Parse(end[0]), int.Parse(end[1]))))//看看棋子走对了没
                { 
                    string NameofChessPlayerChoosed = Board.Chess[int.Parse(begin[0]), int.Parse(begin[1])].Getname();
                    string MoveMethod;
                    Console.WriteLine("Now you choose " + NameofChessPlayerChoosed + ". I'm sorry to tell you that you can't move to the target point because the moving range does not include the target point.");
                    Console.WriteLine("");
                    Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
                    receiveEnd = Console.ReadLine();
                    end = receiveEnd.Split(',');
                    condition3 = false;
                }
                condition4 = true;


                inputcondition2 = condition1 && condition2 && condition3 && condition4;
            }
            if (Board.Chess[int.Parse(end[0]), int.Parse(end[1])].Getname() == "将")
            {
                Board.Chess[int.Parse(end[0]), int.Parse(end[1])].alive = false;
            }
            Board.MoveChess(begin[0], begin[1], end[0], end[1]);

        }

        public void DisplayChoose(int colum, int row)//可能后期用于提供可走路线的展示
        {
            CopyBoard();
            copyBoard.Wherecanchessgo(colum, row);
            Display[0, 0] = "  ";
            Display[0, 1] = "零";
            Display[0, 2] = "一";
            Display[0, 3] = "二";
            Display[0, 4] = "三";
            Display[0, 5] = "四";
            Display[0, 6] = "五";
            Display[0, 7] = "六";
            Display[0, 8] = "七";
            Display[0, 9] = "八";
            Display[0, 10] = "九";
            Display[1, 0] = "零";
            Display[2, 0] = "一";
            Display[3, 0] = "二";
            Display[4, 0] = "三";
            Display[5, 0] = "四";
            Display[6, 0] = "五";
            Display[7, 0] = "六";
            Display[8, 0] = "七";
            Display[9, 0] = "八";

            for (int j = 1; j < 10; j++)
            {

                Display[j, 1] = "┬ ";
                Display[j, 5] = "┴ ";
                Display[j, 6] = "┬ ";
                Display[j, 10] = "┴ ";
            }
            for (int i = 1; i < 11; i++)
            {
                Display[1, i] = "├ ";
                Display[9, i] = "┤ ";
            }

            Display[1, 1] = "┌ ";
            Display[9, 1] = "┐ ";
            Display[1, 10] = "└ ";
            Display[9, 10] = "┘ ";
            for (int j = 0; j < 11; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0 || j == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(Display[i, j]);
                        Console.BackgroundColor = ConsoleColor.Black; 
                    }
                    else if (Display[i, j] == "├ " || Display[i, j] == "┤ ")
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            if (copyBoard.Chess[i -1, j-1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Display[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black; 
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(Display[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black; 
                        }
                    }
                    else if (j == 1 || j == 10)
                    {
                        if (i != 4 && i != 5 && i != 6)
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        else
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "×";
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                    }
                    else if (j == 5 || j == 6)
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(Display[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(Display[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                    }
                    else if (i == 4 || i == 5 || i == 6)
                    {
                        if (j == 1 || j == 2 || j == 3 || j == 10 || j == 8 || j == 9)
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "×";
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                        }
                        else
                        {
                            if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                            {
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                                Display[i, j] = "┼ ";
                                Console.Write(Display[i, j]);
                                Console.BackgroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                                }
                                switch (Board.GetChessColor(i - 1, j - 1))
                                {
                                    case "red":
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                    case "black":
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.Write(Display[i, j]);
                            }
                        }
                    }
                    else
                    {
                        if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                        {
                            if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            Console.ForegroundColor = ConsoleColor.White;
                            Display[i, j] = "┼ ";
                            Console.Write(Display[i, j]);
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i - 1, j - 1);
                            if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                            }
                            switch (Board.GetChessColor(i - 1, j - 1))
                            {
                                case "red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;

                                case "black":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write(Display[i, j]);
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

        }

        public void SwitchPlayer()
        {
            switch (color)
            {
                case "black":
                    color = "red";
                    break;

                case "red":
                    color = "black";
                    break;
            }
        }

        public void CopyBoard()
        {
            for(int j = 0; j < 10; j++)
            {
                for(int i = 0; i <9; i++)
                {
                    if (Board.Chess[i, j].GetCango() == true)
                    {
                        Board.Chess[i, j].Cango = false;
                    }
                }
            }
            copyBoard = Board;
        }


    }
}