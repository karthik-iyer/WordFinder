namespace WordFinder.Console
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WordFinder.Core;
    using WordFinder.Service;
    using WordFinder.Service.Interface;

    class Program
    {
       
        static void Main()
        {
            
            try
            {
                //Add Service Dependencies here
               var wordFinderProcessingService = AddServiceDependencies().Item1;
               var wordFinderValidationService = AddServiceDependencies().Item2;

                //Create Instance of the WordFinderResponse
                var wordFinderResponse = new WordFinderResponse();

                //Assuming that the input character matrix is given in the text file and it needs to be read and loaded as a character matrix. Hence this exercise.
                //Read Input Strings Array
                var inputStringsArray = File.ReadAllLines("Input\\InputStrings.txt");

                var validInputList = ValidateInputStrings(wordFinderValidationService, wordFinderResponse, inputStringsArray);

                //Reading Input and create a character matrix
                var inputCharacterMatrixArray = File.ReadAllLines("Input\\InputCharacterMatrix.txt");

                List<string> inputCharacterPattern = InputMatrixValidation(wordFinderValidationService, inputCharacterMatrixArray);

                wordFinderProcessingService.CreateInputMatrixPattern(inputCharacterMatrixArray, inputCharacterPattern);


                //After getting the character matrix process the input Strings to check if they are there in the matrix. 
                //Assumptions here are  The patterns can be found from left to right or from top to bottom .
                // For this Exercise I am not considering Right to left or bottom to top or diagonal. 
                // Also the given example problem only assumes Left to right or bottom to top approach.
                // So with that assumption, I can create a list of patterns of rows of words and columns of words corresponding to the rows and columns of the square matrix.
                // Then we need to check if that input word belongs to any of the list of patterns to get our result

                var IsAllPatternsFound = wordFinderProcessingService.IsInputStringFoundInMatrix(inputCharacterPattern, validInputList, wordFinderResponse);

                DisplayOutputOfStrings(wordFinderResponse);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Occured while executing the program. {ex.Message}");
            }

        }

        private static void DisplayOutputOfStrings(WordFinderResponse wordFinderResponse)
        {
            Console.WriteLine("The following strings were found in the pattern");
            foreach (var validInput in wordFinderResponse.StringsFound)
            {
                Console.WriteLine(validInput);

            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The following strings were not found in the pattern");
            foreach (var inValidInput in wordFinderResponse.StringsNotFoundWithErrors)
            {
                Console.WriteLine(inValidInput.InputStringNotFound + $". Error Message : {inValidInput.ErrorMessage}");

            }
        }

        private static List<string> InputMatrixValidation(IWordFinderValidationService wordFinderValidationService, string[] inputCharacterMatrixArray)
        {
            //For a Given Input character Matrix Validate if its a square matrix
            wordFinderValidationService.IsSquareMatrix(inputCharacterMatrixArray);

            //Creates Character Matrix and Validates InputMatrix for Square matrix and characters to be alphabets
            var inputCharacterPattern = new List<string>();
            return inputCharacterPattern;
        }

        private static List<string> ValidateInputStrings(IWordFinderValidationService wordFinderValidationService, WordFinderResponse wordFinderResponse, string[] inputStringsArray)
        {

            //IsInputString List empty
            wordFinderValidationService.IsInputStringEmpty(inputStringsArray);

            //From the given list of input strings , just get the valid string list.
            //If the string is invalid , put them in the errorList.
            var validInputList = wordFinderValidationService.GetValidInputStrings(inputStringsArray, wordFinderResponse);
            return validInputList;
        }

        private static (IWordFinderProcessingService,IWordFinderValidationService) AddServiceDependencies()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IWordFinderProcessingService, WordFinderProcessingService>();
            services.AddSingleton<IWordFinderValidationService, WordFinderValidationService>();

            var serviceProvider = services.BuildServiceProvider();
            var wordFinderProcessingService = serviceProvider.GetService<IWordFinderProcessingService>();
           var  wordFinderValidationService = serviceProvider.GetService<IWordFinderValidationService>();
            return (wordFinderProcessingService, wordFinderValidationService);
        }
    }
}
