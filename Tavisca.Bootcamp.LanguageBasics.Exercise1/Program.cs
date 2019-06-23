using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            /* Saperating Value and Operand form Equation */
            string[] string1 = equation.Split("=");
            string[] digits = string1[0].Split("*");
            string operand_1=digits[0];
            string operand_2=digits[1];
            string operand_3=string1[1];
             
            
            /* Condition to check if question mark "?" is present */
            if(operand_3.Contains("?"))                      
            {   int value_one,value_two;
                string equation_1;
               value_one=Convert.ToInt32(operand_1);
               value_two=Convert.ToInt32(operand_2);
               value_one=value_one*value_two;
               equation_1=value_one.ToString();
               return findValue(equation_1,operand_3);
            }
            else 
            {    
                 int value_one,value_two;
                 string equation_1;
                if(operand_1.Contains("?"))
                {
                    string temp=operand_1;
                   operand_1=operand_2;
                   operand_2=temp;
                }   
                value_one=Convert.ToInt32(operand_1);
                value_two=Convert.ToInt32(operand_3);
                
                /* if second is not divisible by first the return -1*/
                if(value_two%value_one!=0)
                { 
                    return -1;
                }
                else
                {
                value_one=value_two/value_one;
                equation_1=value_one.ToString();
                   return findValue(equation_1,operand_2);
                 }
        }

            throw new NotImplementedException();
        }
        /* Find Value */
        public static int findValue(string a, string b)
        {
            if(a.Length!=b.Length) 
               {
                   return -1;
               }
            for(int i=0;i<a.Length;i++)
            {
                if(b[i]=='?') return a[i]-48;
            }
            return -1;
            throw new NotImplementedException();
        }
    }
}
