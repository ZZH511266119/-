using System;

namespace ConsoleXiangqi
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个叫”游戏的““控制”类
            control game = new control();
            game.Board.InitializeBorad();//初始化
            game.display();//展示棋盘
            while (!game.Gameover())//先判断游戏有没有结束（将的生死），然后循环玩家选择，展示棋盘，黑红交换
            {
                try
                {
                    game.Playchoose();
                    game.display();
                    game.SwitchPlayer();
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Check your input is in the right rule, ex:1,2!");
                    Console.WriteLine("Now restart you choose step'!");
                    Console.WriteLine("");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Check your input is in the right rule, ex:1,2 ");
                    Console.WriteLine("Now restart you choose step'!");
                    Console.WriteLine("");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Check your input is in the right rule, ex:1,2 ");
                    Console.WriteLine("Now restart you choose step'!");
                    Console.WriteLine("");
                }
            }

            //游戏结束，有一方将死了，通过看黑将生死来判断谁赢
            if (game.WhoWin())
            {
                Console.WriteLine("Gameover! Black player win!");
            }
            else
            {
                Console.WriteLine("Gameover! Red player win!");
            }
        }
    }



    
}
