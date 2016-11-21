namespace bowlingKata
{
    public class Game
    {
        private int _score;
        private readonly int[] rolls = new int[21];
        private int currentRoll;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int Score()
        {
            var roll = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrikeRole(roll))
                {
                    _score += 10 + StrikeBonus(roll);
                    roll++;
                }
                else if (IsASpareFrame(roll))
                {
                    _score += 10 + SpareBonus(roll);
                    roll += 2;
                }
                else
                {
                   _score += SumOffBallsInFrame(roll);
                    roll += 2;
                }
            }

            return _score;
        }

        private bool IsStrikeRole(int roll)
        {
            return rolls[roll] == 10;
        }

        private int SumOffBallsInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private int StrikeBonus(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private int SpareBonus(int roll)
        {
            return rolls[roll + 2];
        }

        private bool IsASpareFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1] == 10;
        }
    }
}