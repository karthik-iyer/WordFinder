namespace WordFinder.Service.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using WordFinder.Core;
    using WordFinder.Service.Interface;
    using Xunit;
    public class WordFinderValidationServiceTests
    {
        private readonly IWordFinderValidationService wordFinderValidationService = new WordFinderValidationService();

        [Fact]
        public void GetValidInputStrings_InvalidInputStrings_GivesInvalidOutputStringResponse()
        {
            //Arrange
            var inputStrings = new List<string>() { "", "test","test2","tray","knife","spoon","spooooooooooon"};

            var wordFinderResponse = new WordFinderResponse();

            //Act
            wordFinderValidationService.GetValidInputStrings(inputStrings, wordFinderResponse);


            //Assert
            Assert.True(wordFinderResponse.StringsNotFoundWithErrors.Count > 0);

        }


        [Fact]
        public void GetValidInputStrings_ValidInputStrings_GivesValidOutputResponse()
        {
            //Arrange
            var inputStrings = new List<string>() { "test", "tes", "alive", "tray", "knife", "spoon","tenletters" };

            var wordFinderResponse = new WordFinderResponse();

            //Act
            wordFinderValidationService.GetValidInputStrings(inputStrings, wordFinderResponse);

            //Assert
            Assert.True(wordFinderResponse.StringsNotFoundWithErrors.Count == 0);

        }


        [Fact]
        public void IsInputStringEmpty_GivenEmptyString_ThrowsArgumentNullException()
        {
            //Arrange
            var inputStrings = new List<string>();           

            //Act and Assert
           Assert.Throws<ArgumentNullException>( () => wordFinderValidationService.IsInputStringEmpty(inputStrings));

        }


        [Fact]
        public void IsInputStringEmpty_GivenValidString_ReturnsTrue()
        {
            //arrange
            var inputStrings = new List<string>() { "test", "this", "poor", "rich" };

            //act
            var result = wordFinderValidationService.IsInputStringEmpty(inputStrings);

            //Assert
            Assert.True(result);


        }

        [Fact]
        public void IsSquareMatrix_InvalidMatrix_ScenarioWhenMatrixMissingItems_ThrowsInvalidOperationException()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\InvalidCharacterMatrixScenario1.txt");


            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => wordFinderValidationService.IsSquareMatrix(inputCharacterMatrixArray));

            

        }


        [Fact]
        public void IsSquareMatrix_InvalidMatrix_ScenarioWhenMatrixMissingRows_ThrowsInvalidOperationException()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\InvalidInputMatrixScenario2.txt");


            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => wordFinderValidationService.IsSquareMatrix(inputCharacterMatrixArray));

        }

        [Fact]
        public void IsSquareMatrix_InvalidMatrix_ScenarioWhenMatrixMissingRowsAndColumns_ThrowsInvalidOperationException()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\InvalidInputMatrixScenario3.txt");


            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => wordFinderValidationService.IsSquareMatrix(inputCharacterMatrixArray));

        }


        [Fact]
        public void IsSquareMatrix_ValidMatrix_ReturnsTrue()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\ValidInputMatrix.txt");

            var result = wordFinderValidationService.IsSquareMatrix(inputCharacterMatrixArray);

            //Act and Assert
            Assert.True(result);

        }


    }
}
