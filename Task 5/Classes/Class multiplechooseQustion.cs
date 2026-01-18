using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Task_5.Classes
{
      class multiplechooseQustion : Question
    {
        public  int[] Correctanswers { get; set; } 
       
        public string[] Choieces { get; set; }= new string[4];
      
        public override void Display()
        {
            Console.WriteLine(Header);
            for (int i = 0; i < Choieces.Length; i++)
            {
                Console.WriteLine($"{i + 1}{Choieces[i]}");
            }
            Console.WriteLine($"Choose The Correct Answer (  ,  )");
        }

        public override bool Checkanswer(string answer)
        {
            string[] Parts = answer.Split(',');

            if (Parts.Length != Correctanswers.Length)
            {
                return false;
            }
            for(int i = 0;i < Parts.Length;i++)
            {
                int num = int .Parse(Parts[i].Trim());
                bool found = false;
                for(int j = 0; j < Correctanswers.Length; j++)
                {
                    if(num == Correctanswers[j])
                    {
                        found = true;
                        break;
                    }    
                }
                if(!found)
                {
                    return false;
                }

            }
            return true;

        }
    }
   
}
