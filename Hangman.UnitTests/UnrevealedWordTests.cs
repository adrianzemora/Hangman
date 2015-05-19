using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.UnitTests
{
    [TestClass]
    public class UnrevealedWordTests
    {
        private WordLetter letterA;
        private WordLetter letterB;

        [TestInitialize]
        public void Initialize()
        {
            letterA = new WordLetter("A");
            letterB = new WordLetter("B");
        }

        [TestMethod]
        public void Intantiate_RevealsFirstLetter_WhenItAppearsOnlyOnce()
        {
            var unrevealedWord = new UnrevealedWord("AXXB");

            Assert.AreEqual("A", unrevealedWord.Letters[0].DisplayValue);
        }

        [TestMethod]
        public void Intantiate_RevealsLastLetter_WhenItAppearsOnlyOnce()
        {
            var unrevealedWord = new UnrevealedWord("AXXXB");

            Assert.AreEqual("B", unrevealedWord.Letters[4].DisplayValue);
        }

        [TestMethod]
        public void Instantiate_RevealsAllOccurrencesOfFirstLetter_WhenItAppearsMultipleTimesInWord()
        {
            var unrevealedWord = new UnrevealedWord("AXAXB");

            Assert.AreEqual("A", unrevealedWord.Letters[0].DisplayValue);
            Assert.AreEqual("A", unrevealedWord.Letters[2].DisplayValue);
        }

        [TestMethod]
        public void Instantiate_RevealsAllOccurrencesOfLastLetter_WhenItAppearsMultipleTimesInWord()
        {
            var unrevealedWord = new UnrevealedWord("AXBXB");

            Assert.AreEqual("B", unrevealedWord.Letters[2].DisplayValue);
            Assert.AreEqual("B", unrevealedWord.Letters[4].DisplayValue);
        }

        [TestMethod]
        public void IsRevealed_ReturnTrue_WhenThereIsNoUnrevealedLetter()
        {
            var unrevealedWord = new UnrevealedWord("AAAB");

            Assert.IsTrue(unrevealedWord.IsRevealed());
        }

        [TestMethod]
        public void IsRevealed_ReturnFlase_WhenThereIsUnrevealedLetter()
        {
            var unrevealedWord = new UnrevealedWord("AAXB");

            Assert.IsFalse(unrevealedWord.IsRevealed());
        }

        [TestMethod]
        public void IsValidLetter_ReturnsTrue_WhenItIsPartOfTheWord()
        {
            var unrevealedWord = new UnrevealedWord("AXTXB");

            Assert.IsTrue(unrevealedWord.IsValidLetter("T"));
        }

        [TestMethod]
        public void IsValidLetter_ReturnsFalse_WhenItIsNotPartOfTheWord()
        {
            var unrevealedWord = new UnrevealedWord("AXXXB");

            Assert.IsFalse(unrevealedWord.IsValidLetter("T"));
        }
    }
}
