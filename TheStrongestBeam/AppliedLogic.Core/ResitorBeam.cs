namespace AppliedLogic.Core
{
    public class ResitorBeam
    {
        public static bool IsValid(string message)
        {
            Console.Write(message);
            var beam = Console.ReadLine();

            string b = beam!.Substring(0, 1);
            if (!(b.Equals("%") || b.Equals("&") || b.Equals("#")))
            {
                return false;
            }

            int size = beam.Length;
            int count = 0;
            for (int i = 1; i < size; i++)
            {
                string position = beam.Substring(i, i + 1);
                if (!(position.Equals("=") || position.Equals("*")))
                {
                    return false;
                }
                if (position.Equals("*"))
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 2)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool CalculateWeight(string message)
        {
            Console.Write(message);
            var beam = Console.ReadLine();
            string b = beam!.Substring(0, 1);
            int size = beam.Length;
            int total = 0;
            int segment = 0;
            for (int i = 1; i < size; i++)
            {
                string position = beam.Substring(i, i + 1);
                if (position.Equals("="))
                {
                    segment++;
                }
                else
                {
                    total += segment * 3;
                    segment = 0;
                }
            }
            total += segment;

            int weightLimit = 0;
            switch (b)
            {
                case "%":
                    weightLimit = 10;
                    break;

                case "&":
                    weightLimit = 20;
                    break;

                case "#":
                    weightLimit = 90;
                    break;
            }
            ;
            return weightLimit >= total;
        }


    }
}