/*
Converting from Roman to Arab
Example: input = XXV ; output = 25;
*/

public class Roman
    {
        public static void romanToDecimal(String romanNumber)
        {
            int current = 0;
            int lastNumber = 0;
            char[] romanNumeral = romanNumber.ToUpper().ToCharArray();
            /*
             * разбираем входную строку по символам, далее для нужного символа вызываем метод getResult
             */
            for (int x = romanNumeral.Count() - 1; x >= 0; x--)
            {
                char convertToDecimal = romanNumeral[x];

                switch (convertToDecimal)
                {
                    case 'M':
                        current = getResult(1000, lastNumber, current);
                        lastNumber = 1000;
                        break;

                    case 'D':
                        current = getResult(500, lastNumber, current);
                        lastNumber = 500;
                        break;

                    case 'C':
                        current = getResult(100, lastNumber, current);
                        lastNumber = 100;
                        break;

                    case 'L':
                        current = getResult(50, lastNumber, current);
                        lastNumber = 50;
                        break;

                    case 'X':
                        current = getResult(10, lastNumber, current);
                        lastNumber = 10;
                        break;

                    case 'V':
                        current = getResult(5, lastNumber, current);
                        lastNumber = 5;
                        break;

                    case 'I':
                        current = getResult(1, lastNumber, current);
                        lastNumber = 1;
                        break;
                }
            }
            Console.WriteLine(current);
        }

        public static int getResult(int current, int lastNumber, int lastDecimal)
        {
            if (lastNumber > current)
            {
                return lastDecimal - current;
            }
            else
            {
                return lastDecimal + current;
            }
        }

        
    }
