using System;
using System.Collections.Generic;
using System.Linq;


namespace HornerMethodConsole
{
    class Program
    {
        private static float[] FirstCoefficient(int[] coefficients, float[] rationalDividers)
        {
            float sum = coefficients[0];
            float[] sumArr = new float[coefficients.Length];
            sumArr[0] = coefficients[0];
            for (int k = 0; k < rationalDividers.Length; k++) //for every divider
            {
                for (int i = 0; i < coefficients.Length - 1; i++) //for every coefficient
                {
                    // sum = sumArr[i + 1] + (sum * dividers[k]);
                    sum = coefficients[i + 1] + (sum * rationalDividers[k]);
                    sumArr[i + 1] = sum; //sumArr[i+1] - to show the first coefficient     
       
                }
                Console.WriteLine(String.Join(" ", sumArr));
                sum = coefficients[0];
            }
            return sumArr;
        }
        private static int[] LastCoeffiecient(int[] coefficients, int[] dividers)                 //private static int[] Horner(int[] coefficients, int[] dividers)
        {           
           int sum = coefficients[0];
           int[] sumArr =new int[coefficients.Length];
           sumArr[0] = coefficients[0];
        
           if (coefficients[0] > 1)
           {
               Console.WriteLine($"Choose rational dividers of {coefficients[0]}:", coefficients);
               float[] rationalDividers = Console.ReadLine().Split().Select(float.Parse).ToArray();
               FirstCoefficient(coefficients, rationalDividers);
           }
        
           for (int k = 0; k < dividers.Length; k++) //for every divider
           {            
              for (int i = 0; i < coefficients.Length - 1; i++) //for every coefficient
              {                   
                   // sum = sumArr[i + 1] + (sum * dividers[k]);
                   sum = coefficients[i + 1] + (sum * dividers[k]);
                   sumArr[i+1] = sum; //sumArr[i+1] - to show the first coefficient     
                  
              }
              Console.WriteLine(String.Join(" ",sumArr));
              sum = coefficients[0];                           
           }
           return sumArr;
        }
        private static void MultipleCoefficients(int[] newArr)
        {
            Console.WriteLine("Check for multiple coefficients? Type 'go' to continue.");
            string command = Console.ReadLine();
            for (int i = 0; command == "go"; i++)
            {
                if (newArr.Length == 1)
                {
                    return;
                }
                Array.Resize(ref newArr, newArr.Length - 1);
                Console.WriteLine("New integer dividers:");
                int[] newDividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                newArr = LastCoeffiecient(newArr,newDividers);
                Console.WriteLine("go again? To end type 'end'.");
                command = Console.ReadLine();
            }

        }        
        static void Main(string[] args)
        {
            Console.WriteLine("Coefficients");
            int[] coefficients = Console.ReadLine().Split().Select(int.Parse).ToArray();
 
            Console.WriteLine($"Choose integer dividers of {coefficients[coefficients.Length - 1]}:", coefficients);
            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sumArr = LastCoeffiecient(coefficients, dividers);

            if (sumArr[sumArr.Length - 1] == 0)
            {
                MultipleCoefficients(sumArr);
            }          
        }
    }
}




// Console.WriteLine("Check for double coefficients?");
//string command =Console.ReadLine();
// while (command != "end") 
//{
// int counter = 1;

//int[] newSum = sumArr;

//counter++;
//newSum = new int[sumArr.Length-1];
//}


// Console.WriteLine("go?");
// string command = Console.ReadLine();
// for (int i = 0; command=="go"/*i < sumArr.Length*/; i++)//i=1- decrease the size of sumArr
// {
//     if(sumArr.Length==1)
//     {
//         return;
//     }
//     Array.Resize(ref sumArr, sumArr.Length - 1);
//     Console.WriteLine("New dividers:");
//     int[] newDividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
//
//     sumArr = LastCoeffiecient(sumArr, newDividers);
//     Console.WriteLine("go");
//     command = Console.ReadLine();
// }