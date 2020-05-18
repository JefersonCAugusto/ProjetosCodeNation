using System;
using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> numbers = new List<int>() { 0 };  //Init List
            int before = 0;
            int current = 0;
            while (current < 350)
            {
                if (current == 0)
                {
                    current++;
                    numbers.Add(current);
                    before++;
                }
                else
                {
                    if (current == 1)
                        numbers.Add(current);
                    int temp = before + current;
                    if (temp < 350)
                        numbers.Add(temp);                   
                    before = current;
                    current = temp;
                }
            }
            return numbers;
        }

        public bool IsFibonacci(int numberToTest)
        {
            if (Fibonacci().Contains(numberToTest))     //recomenação do nosso colega "Anderson Silvério Mendrot Filho"
                return true;
                return false;
        }


    }
}
