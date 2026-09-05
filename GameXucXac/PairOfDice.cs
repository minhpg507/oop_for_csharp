using System;

namespace GameXucXac
{
    public class Dice
    {
        public int FaceValue { get; private set; }
        private Random random;

        public Dice()
        {
            random = new Random();
            Roll(); 
        }

        public void Roll()
        {
            FaceValue = random.Next(1, 7); 
        }
    }

    public class PairOfDice
    {
        public Dice Die1 { get; private set; }
        public Dice Die2 { get; private set; }

        public PairOfDice()
        {
            Die1 = new Dice();
            Die2 = new Dice();
        }

        public void Roll()
        {
            Die1.Roll();
            Die2.Roll();
        }

        public int GetTotal()
        {
            return Die1.FaceValue + Die2.FaceValue;
        }
    }
}