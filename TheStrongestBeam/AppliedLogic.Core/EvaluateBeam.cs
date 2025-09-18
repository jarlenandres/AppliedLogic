namespace AppliedLogic.Core
{
    public class ResitorBeam
    {
        public static string EvaluateBeam(string beam)
        {
            int count = 0;
            string content = beam.Substring(0, 1);
            if (!(content.Equals("%") || content.Equals("&") || content.Equals("#")))
            {
                return "The beam is poorly constructed!";
            }

            int resistanceBase = 0;
            char baseType = beam[0];
            switch (baseType)
            {
                case '%':
                    resistanceBase = 10;
                    break;

                case '&':
                    resistanceBase = 30;
                    break;

                case '#':
                    resistanceBase = 90;
                    break;
            }

            if (beam.Length == 1)
            {
                return "The beam supports the weight!";
            }

            string content1 = beam.Substring(1);
            int totalWeight = 0;
            int Sequence = 0;
            int i = 0;
            for (i = 1; i < content1.Length; i++)
            {
                if (content1[i] == '=')
                {
                    Sequence++;
                }
                else
                {
                    totalWeight += Sequence * 3;
                    Sequence = 0;
                }

                if (content1[i] == '*')
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 2)
                {
                    return "The beam is poorly constructed!";
                }
            }
            totalWeight += Sequence;

            if (totalWeight <= resistanceBase)
            {
                return "The beam supports the weight!";
            }
            else
            {
                return "The beam does NOT support the weight!";
            }
        }
    }
}