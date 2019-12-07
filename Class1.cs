using System;
using System.Collections.Generic;
using System.Text;

//这个是棋子的类，我就是是基于这个类出发做的，所以要看的话先看这个类！

namespace ConsoleXiangqi
{
    public abstract class chess
    {
        string name;//名字，颜色，行，列，这是我暂时想到有用的属性
        string color;
        int row;
        int colum;

        public chess(string color, string name, int colum, int row)//构造函数
        {
            this.color = color;
            this.name = name;
            this.colum = colum;
            this.row = row;
        }

        public string Getname()//获取名字
        {
            return this.name;
        }

        public string Getcolor()//获取棋子的颜色
        {
            return this.color;
        }

    }


    //以下就算是各个棋子的类，也就是“棋子”的子类，除了将我添加了一个"生死"属性，其它一样
        public class horse : chess
        {
            public horse(string color, int colum, int row)
            : base(color, "h", colum, row)
            {
        }
        }

         public class cannon : chess
        {
            public cannon(string color, int colum, int row)
            : base(color,"c", colum, row)
            { }
        }
        public class rood : chess
        {
            public rood(string color, int colum, int row)
            : base(color, "r", colum, row)
            { }
        }

        public class soldier : chess
        {
            public soldier(string color, int colum, int row)
            : base(color, "s", colum, row)
            { }
        }

        public class elephant : chess
        {
            public elephant(string color, int colum, int row)
            : base(color, "e", colum, row)
            { }
        }

        public class guard : chess
        {
            public guard(string color, int colum, int row)
            : base(color, "g", colum, row)
            { }
        }

        public class general : chess
        {
        public bool alive = true;
        public general(string color, int colum, int row)
            : base(color, "G", colum, row)
        { }
        }


}
