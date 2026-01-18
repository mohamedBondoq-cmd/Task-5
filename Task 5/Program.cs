using Task_5.Classes;

namespace Task_5
{
    internal class Program
    {
        static List<Question> QuestionBank = new List<Question>();
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Main Menu =====");
                Console.WriteLine("1. Doctor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    DoctorMode();
                else if (choice == 2)
                    StudentMode();

            } while (choice != 3);
        }



        static void DoctorMode()
        {
            int option;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Doctor Mode =====");
                Console.WriteLine("1. Add Question");
                Console.WriteLine("2. Back");
                Console.Write("Choice: ");
                option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("1. True / False");
                    Console.WriteLine("2. Choose One");
                    Console.WriteLine("3. Multiple Choice");
                    int type = int.Parse(Console.ReadLine());

                    Console.Write("Level (1-Easy, 2-Medium, 3-Hard): ");
                    QuestionLevels level = (QuestionLevels)int.Parse(Console.ReadLine());

                    Console.Write("Header: ");
                    string header = Console.ReadLine();

                    Console.Write("Marks: ");
                    int marks = int.Parse(Console.ReadLine());

                    if (type == 1)
                    {
                        TrueFalseQuestion q = new TrueFalseQuestion();
                        q.Header = header;
                        q.Level = level;
                        q.Marks = marks;

                        Console.Write("Correct Answer (1-True, 2-False): ");
                        q.Correctanswer = Console.ReadLine() == "1";

                        QuestionBank.Add(q);
                    }
                    else if (type == 2)
                    {
                        chooseoneQuestion q = new chooseoneQuestion();
                        q.Header = header;
                        q.Level = level;
                        q.Marks = marks;

                        for (int i = 0; i < 4; i++)
                        {
                            Console.Write($"Choice {i + 1}: ");
                            q.Choieces[i] = Console.ReadLine();
                        }

                        Console.Write("Correct Choice: ");
                        q.Correctanswer = int.Parse(Console.ReadLine());

                        QuestionBank.Add(q);
                    }
                    else if (type == 3)
                    {
                        multiplechooseQustion q = new multiplechooseQustion();
                        q.Header = header;
                        q.Level = level;
                        q.Marks = marks;

                        for (int i = 0; i < 4; i++)
                        {
                            Console.Write($"Choice {i + 1}: ");
                            q.Choieces[i] = Console.ReadLine();
                        }

                        Console.Write("Correct Answers (e.g. 1,3): ");
                        string input = Console.ReadLine();
                        string[] Parts = input.Split(',');
                        q.Correctanswers = new int[Parts.Length];
                        for (int i = 0; i < Parts.Length; i++)
                        {
                            q.Correctanswers[i] = int.Parse(Parts[i].Trim());
                        }

                        QuestionBank.Add(q);
                    }

                    Console.WriteLine("Question Added ");
                }

            } while (option != 2);
        }
        static void StudentMode()
        {
            Console.Clear();
            Console.WriteLine("===== Student Mode =====");
            Console.WriteLine("1. Practical Exam (Half)");
            Console.WriteLine("2. Final Exam (All)");
            Console.Write("Choice: ");
            int examType = int.Parse(Console.ReadLine());

            Console.Write("Level (1-Easy, 2-Medium, 3-Hard): ");
            QuestionLevels level = (QuestionLevels)int.Parse(Console.ReadLine());

            List<Question> selectedQuestions = new List<Question>();

            foreach (Question q in QuestionBank)
            {
                if (q.Level == level)
                    selectedQuestions.Add(q);
            }

            if (examType == 1)
            {
                int half = selectedQuestions.Count / 2;
                selectedQuestions = selectedQuestions.GetRange(0, half);
            }

            int totalMarks = 0;
            int result = 0;

            Console.Clear();
            Console.WriteLine("===== Exam Started =====\n");

            for (int i = 0; i < selectedQuestions.Count; i++)
            {
                Console.WriteLine($"Question {i + 1}:");
                selectedQuestions[i].Display();

                Console.Write("Your Answer: ");
                string answer = Console.ReadLine();

                totalMarks += selectedQuestions[i].Marks;

                if (selectedQuestions[i].Checkanswer(answer))
                    result += selectedQuestions[i].Marks;

                Console.WriteLine("----------------------");
            }


            Console.WriteLine($"Your Result: {result} / {totalMarks}");
            Console.WriteLine("\n1. Back to Main Menu");
            Console.Write("Choice: ");
            int back = int.Parse(Console.ReadLine());

            if (back == 1)
                return;
        }
    }
}
