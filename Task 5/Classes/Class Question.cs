using System;
using System.Collections.Generic;
using System.Text;

namespace Task_5.Classes
{
    enum QuestionLevels
    {
        Easy =1 ,
        Medium,
        Hard
    }
    abstract class Question
    {  
        public string Header { get; set; }
        public  int Marks { get; set; }       
        public   QuestionLevels Level { get; set; }


        public abstract void Display();
        public abstract bool Checkanswer(string answer);


    }
 
}
