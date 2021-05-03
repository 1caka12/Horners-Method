using System;
using System.Linq;

namespace HornerMethodConsole
{
    class Program
    {
       
        private static float[] CoefficientCalculator(float[] coefficients, float[] rationalDividers)
        {
           float newElement = coefficients[0];    // keeps every new element
           float[] newElements = new float[coefficients.Length];   //an array to keep the new elements
           newElements[0] = coefficients[0];   // keeps the first coefficient
            
            for (int k = 0; k < rationalDividers.Length; k++) 
            {
                for (int i = 0; i < coefficients.Length - 1; i++) 
                {
                    newElement = coefficients[i + 1] + (newElement * rationalDividers[k]); // calculates every element
                    newElements[i + 1] = newElement;  // adds every new element to the array of new elements
                }
                Console.WriteLine(String.Join(" ", newElements));
                newElement = coefficients[0];  // reverts the value of the variable, so it can calculate the new elements              
            }           
            return newElements;
        }

        private static float[] Coefficients(float[] coefficients, float[] dividers)
        {          
            if(coefficients[0]>1) 
            {                
               Console.WriteLine($"Choose rational dividers of {coefficients[0]}",coefficients);
               float[] rationalDividers = Console.ReadLine().Split().Select(float.Parse).ToArray();                                  
               CoefficientCalculator(coefficients, rationalDividers);               
            }  

            return CoefficientCalculator(coefficients,dividers);                    
        }
     
        private static void MultipleCoefficients(float[] newArr)
        {
            Console.WriteLine("Check for multiple coefficients? Type 'go' to continue or 'end' to stop execution.");
            string command = Console.ReadLine();

           while(command == "go" || newArr.Length==1) 
           {  
                Array.Resize(ref newArr, newArr.Length - 1); 
                Console.WriteLine("New integer dividers:");
                float[] newDividers = Console.ReadLine().Split().Select(float.Parse).ToArray();

                newArr = Coefficients(newArr, newDividers);
                Console.WriteLine("go again? To end type 'end'.");
                command = Console.ReadLine();
           }

        }        
        static void Main(string[] args)
        {
            Console.WriteLine("Coefficients");
            float[] coefficients = Console.ReadLine().Split().Select(float.Parse).ToArray();
 
            Console.WriteLine($"Choose integer dividers of {coefficients[coefficients.Length - 1]}:", coefficients);
            float[] dividers = Console.ReadLine().Split().Select(float.Parse).ToArray();            

            float[] newElements = Coefficients(coefficients,dividers);
                                
            if (newElements[newElements.Length - 1] == 0)  
            {
                MultipleCoefficients(newElements);
            }
            
            Console.WriteLine();
            
        }
    }
}
 