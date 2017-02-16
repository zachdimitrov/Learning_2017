# Unit Testing

## MS Test

#### Attributes

```c#
    [TestClass]
    public class AccountTest
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        public void TestDeposit()
        {
            Account acc = new Account();
            acc.Deposit(200.00M);
            decimal balance = acc.Balance;
            Assert.AreEqual(balance, 200.00M);
        }
    }
```

#### Other tricks
- test Internal methods - add to tested assembly this attribute
```c#
[assembly: InternalsVisibleTo("TestSolution")]
```
- test private methods - with reflection
```c#
PrivateObject pri = new PrivateObject(typeof(TestedClass));
var result = pri.Invoke("PrivateMethodName");
Assert.AreEqual(expected, result);
```

## NUnit

#### Installation

- right click solution, go to **manage nuget packages**
- install **NUnit**
- install **NUnit3TestAdapter**

#### Usage Example

```c#
using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;

namespace DeckTest
{
    /// <summary>
    /// Testing Deck.cs from ..\\..\\Task-2-Decks\\Santase.Logic.dll
    /// Link to tested class in repo: https://github.com/NikolayIT/SantaseGameEngine/blob/master/Source/Santase.Logic/Cards/Deck.cs
    /// </summary>

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void CheckIfDeckConstructorWorks()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck);
        }

        [Test]
        public void DeckTrumpCardShouldExist()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck.TrumpCard);
        }

        [Test]
        public void CheckIfCardsLeftIsCorrectValue()
        {
            var deck = new Deck();
            Assert.IsTrue(deck.CardsLeft >= 0 && deck.CardsLeft < 25);
        }

        [Test]
        [TestCase(2)]
        [TestCase(7)]
        [TestCase(9)]
        [TestCase(18)]
        public void GetNextCardShouldWork(int testsCount)
        {
            var deck = new Deck();
            for (int i = 0; i < testsCount; i++)
            {
                Assert.IsNotNull(deck.GetNextCard());
            }
        }

        [Test]
        public void DeckShouldThrowIfCardsAreEmpty()
        {
            var deck = new Deck();

            for (int i = 0; i < 24; i++)
            {
                deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void ChangeTrumpCardShouldWork()
        {
            var deck = new Deck();
            var card = new Card(CardSuit.Diamond, CardType.Ten);
            deck.ChangeTrumpCard(card);
            Assert.IsTrue(deck.TrumpCard.Equals(card));
        }
    }
}
```

# Isolation Techniques - Mocking

#### Inversion of Control Pattern  

- razdelqme zavisimostite na otdelnite komponenti
- vsqka chast si znae sobstvenata otgovornost
- trqbva da izpolzvame nai-abstraktnite nachini

```c#
    public Card[] Cards { get; private set; }       // bad code
    public IList<ICard> Cards { get; private set; } // good code 
```

#### Dependency Inversion

- dependent consumer
- declaration of a component's dependencies as interfaces
- injector
- kontrola se otdava na drug

#### Faking

- izpolzvaiki Dependency Inversion za da testvame funkcionalnost
- testvame izolirano metoda s falshivi obekti

## Moq (Framework)


