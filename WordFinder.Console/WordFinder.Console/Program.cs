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
                var services = new ServiceCollection();
                services.AddSingleton<IWordFinderProcessingService, WordFinderProcessingService>();
                services.AddSingleton<IWordFinderValidationService, WordFinderValidationService>();

                var serviceProvider = services.BuildServiceProvider();
                var wordFinderProcessingService = serviceProvider.GetService<IWordFinderProcessingService>();
                var wordFinderValidationService = serviceProvider.GetService<IWordFinderValidationService>();


                //Create Instance of the WordFinderResponse
                var wordFinderResponse = new WordFinderResponse();

                //Assuming that the input character matrix is given in the text file and it needs to be read and loaded as a character matrix. Hence this exercise.
                //Read Input Strings Array
                var inputStringsArray = File.ReadAllLines("Input\\InputStrings.txt");

                //IsInputString List empty
                 wordFinderValidationService.IsInputStringEmpty(inputStringsArray);               


                var validInputList = wordFinderValidationService.GetValidInputStrings(inputStringsArray,wordFinderResponse);



                //Reading Input and create a character matrix
                var inputCharacterMatrixArray = File.ReadAllLines("Input\\InputCharacterMatrix.txt");



                //Creates Character Matrix and Validates InputMatrix for Square matrix and characters to be alphabets
                var inputCharacterPattern = new List<string>();

                var inputMatrix = wordFinderProcessingService.CreateCharacterArray(inputCharacterMatrixArray);

                var count = 0;

                for (int index =0; index < inputCharacterMatrixArray.Length; index++)
                {
                    inputCharacterPattern.Add(string.Empty);
                }

                foreach (var item in inputCharacterMatrixArray)
                {
                    foreach (char ch in item.ToCharArray())
                    {
                        inputCharacterPattern[count] = inputCharacterPattern[count] + ch;
                        count++;
                    }
                    count = 0;
                }

                foreach (var item in inputCharacterMatrixArray)
                {
                    inputCharacterPattern.Add(item);

                }

               

              

                //After getting the character matrix process the input Strings to check if they are there in the matrix. 
                //Assumptions here are  The patterns can be found from left to right or from top to bottom .
                // For this Exercise I am not considering Right to left or bottom to top or diagonal. 
                // Also the given example problem only assumes Left to right or bottom to top approach.
                // So with that assumption, I can create a list of patterns of rows of words and columns of words corresponding to the rows and columns of the square matrix.
                // Then we need to check if that input word belongs to any of the list of patterns to get our result

                var IsAllPatternsFound = wordFinderProcessingService.IsInputStringFoundInMatrix(inputCharacterPattern, validInputList, wordFinderResponse);

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
            catch (Exception ex)
            {

                Console.WriteLine($"An Error Occured while executing the program. {ex}");
            }
                
          

           

            



        }
    }
}
