namespace Santase.Tests
{
    using System;
    using NUnit.Framework;
        
    using Santase.Logic;
    using Santase.Logic.Cards;

    [TestFixture]
    public class TestDeck
    {        
        [Test]
        [TestCase(24)]
        public void TestNewDeckShouldContain24Cards(int numberOfAllCards )
        {
            Deck deck = new Deck();
            Assert.AreEqual(numberOfAllCards, deck.CardsLeft, "The new deck should contain 24 cards !");
        }

        [Test]
        public void TestGetNextCardShouldRemoveTheCardFromTheDeck()
        {
            Deck deck = new Deck();
            int initialNumberOfCards = deck.CardsLeft;
            deck.GetNextCard();

            Assert.AreEqual((initialNumberOfCards - 1), deck.CardsLeft, "GetNextCard() should remove 1 card from the deck");
        }

        [Test]
        [ExpectedException(typeof(InternalGameException))]
        public void TestGetNextCardFromEmptyDeckThrowsException()
        {
            Deck deck = new Deck();
            int cardsCount = deck.CardsLeft;
            Card card = deck.GetNextCard();

            for (int i = 1; i <= cardsCount; i++)
            {
                card = deck.GetNextCard();
            }
        }
                
        [Test]
        [TestCase(CardSuit.Spade, CardType.King)]
        [TestCase(CardSuit.Heart, CardType.Ace)]
        [TestCase(CardSuit.Diamond, CardType.Jack)]
        [TestCase(CardSuit.Heart, CardType.Queen)]
        [TestCase(CardSuit.Diamond, CardType.Ten)]
        public void TestChangeTrumpCardShouldProperlyUpdateBothTrumpCardAndDeckTopCard(CardSuit suit, CardType type)
        {
            Deck deck = new Deck();
            Card newTrumpCard = new Card(suit, type);

            deck.ChangeTrumpCard(newTrumpCard);
            int cardsCount = deck.CardsLeft;
            Card topCard = deck.GetNextCard();

            for (int i = 1; i < cardsCount; i++)
            {
                topCard = deck.GetNextCard();

                
            }

            Assert.AreEqual(topCard, newTrumpCard);
        }

        [Test]
        public void ChangeTrumpCardShouldChangeTheTrumpCardIfThereAreCardsLeftInTheDeck()
        {
            Deck testDeck = new Deck();

            Card initialTrumpCard = testDeck.GetTrumpCard;
            Card newCard = testDeck.GetNextCard();
            testDeck.ChangeTrumpCard(newCard);

            Assert.AreNotSame(initialTrumpCard, testDeck.GetTrumpCard);
        }
    }
}
