using Xunit;

namespace bowlingKata
{
    public class BowlingGameShould
    {
        private Game _game;

        public void Setup()
        {
            _game = new Game();
        }

        [Fact]
        public void ReturnZeroWithAGutterGame()
        {
            Setup();
            const int rolls = 20;
            const int pins = 0;

            RolMany(rolls,pins);

            Assert.Equal(_game.Score(),0);
        }

        [Fact]
        public void ReturnTwentyWhenAllThrowsAreOne()
        {
            Setup();
            const int rolls = 20;
            const int pins = 1;

            RolMany(rolls,pins);

            Assert.Equal(_game.Score(),20);
        }

        [Fact]
        public void ReturnSixteenWithOneSpare()
        {
            Setup();

            ThrowSpare();
            _game.Roll(3);
            RolMany(17, 0);

            Assert.Equal(_game.Score(), 16);
        }

        [Fact]
        public void ReturnTwentyFourWithOnStrike()
        {
            Setup();

            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
           RolMany(16,0);

            Assert.Equal(24,_game.Score());
        }

        [Fact]
        public void ReturnThreeHonderWithAPerfectGame()
        {
            Setup();
            RolMany(12,10);
            Assert.Equal(300,_game.Score());
        }

        [Fact]
        public void Return


        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void ThrowSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RolMany(int rolls,int pins)
        {
            for (var i = 0; i < rolls; i++)
            {
                _game.Roll(pins);
            }
        }
    }
}