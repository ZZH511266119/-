﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleXiangqi
{
    class control
    {
        public board Board = new board();
        string[,] Display = new string[9, 10];
        string color = "black";

        public bool Gameover()
        {
            bool alive;
            alive = Board.GeneralAlive();
            return !alive;
        }

        public bool WhoWin()
        {
            bool alive;
            alive = Board.GeneralAlive();
            return alive;
        }

        public void display()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (j == 4 || j == 5)
                    {
                        if (Board.Chess[i, j] == null)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Display[i, j] = "-";
                            Console.Write(Display[i, j]);
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i, j);
                            switch (Board.GetChessColor(i, j))
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
                        if (Board.Chess[i, j] == null)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Display[i, j] = "+";
                            Console.Write(Display[i, j]);
                        }
                        else
                        {
                            Display[i, j] = Board.GetChessName(i, j);
                            switch (Board.GetChessColor(i, j))
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

        public void Playchoose()
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

            while (!inputcondition1)
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
                if (Board.GetChessColor(int.Parse(begin[0]), int.Parse(begin[1])) != color)//看看输入是不是玩家现在颜色的棋子
                {
                    Console.WriteLine($"Oh! You are {color} player. Please input the aix of {color} piece!");
                    Console.WriteLine("");
                    Console.WriteLine("Which pieces do you want to move? Please input its aix(Ex: 1,2): ");
                    receiveBegin = Console.ReadLine();
                    begin = receiveBegin.Split(',');
                    condition1 = false;
                }
                condition2 = true;

                inputcondition1 = condition1 && condition2;
            }


            display();

            Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
            receiveEnd = Console.ReadLine();
            end = receiveEnd.Split(',');

            while (!inputcondition2)
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
                while (!(Board.Chess[int.Parse(begin[0]), int.Parse(begin[1])].JudgeMovement(int.Parse(end[0]), int.Parse(end[1]))))//看看棋子走对了没
                {
                    string NameofChessPlayerChoosed = Board.Chess[int.Parse(begin[0]), int.Parse(begin[1])].Getname();
                    string MoveMethod;
                    Console.WriteLine("Now you choose " + NameofChessPlayerChoosed + ". I'm sorry to tell you that you can't move to the target point because the moving range does not include the target point.");
                    Console.WriteLine("");
                    Console.WriteLine("Where do you wan to go? Please input its aix(Ex: 1,2): ");
                    receiveEnd = Console.ReadLine();
                    end = receiveEnd.Split(',');
                    condition2 = false;
                }
                condition3 = true;

                inputcondition2 = condition1 && condition2 && condition3;
            }
            
            Board.MoveChess(begin[0], begin[1], end[0], end[1]);

        }

        public void DisplayChoose()
        {

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



    }
}