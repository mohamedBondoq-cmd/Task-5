using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5.Classes
{
     class  TrueFalseQuestion : Question
    {
       public  bool Correctanswer { get; set; }
       
        public override void Display()
        {
            Console.WriteLine(Header);
            Console.WriteLine("1) True");
            Console.WriteLine("2) False");
            Console.WriteLine("Choose One Answer (1 or 2)");

        }
        public override bool Checkanswer(string answer)
        {
            int UserAnswer = int.Parse(answer);
            if (UserAnswer == 1 && Correctanswer == true)
            {
                return true;
            }
            if (UserAnswer == 2 && Correctanswer == false)
            {
                return true;
            }
            return false;

        }


    }
   
}
