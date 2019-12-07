using System;
using System.Collections.Generic;
using System.Text;



namespace ConsoleXiangqi
{

    public class MyException : Exception
    {
        public MyException()
            : base("默认错误测试")
        {

        }

        public MyException(string message)//指定错误消息
            : base(message)
        {

        }

        public MyException(string message, Exception inner)//指定错误消息和内部异常信息
            : base(message, inner)
        {

        }
    }

}
