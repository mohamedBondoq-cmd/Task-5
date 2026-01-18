using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5.Classes
{
 class chooseoneQuestion : Question
    {
        public  int Correctanswer { get; set; }
        public string[] Choieces { get; set; } = new string[4];

     

        public override void Display()
        {
            Console.WriteLine(Header);
           for(int i = 0; i < Choieces.Length; i++)
            {
                Console.WriteLine($"{i + 1}{Choieces[i]}");
            }
            Console.WriteLine("Choose The Correct Answer");
        }

        public override bool Checkanswer(string answer)
        {
            if (answer == Correctanswer.ToString())
                return true;
            else
                return false;
        }
    }
   
}
