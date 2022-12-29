using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Core;
using WordFinder.Service.Interface;

namespace WordFinder.Service
{
    public class WordFinderProcessingService : IWordFinderProcessingService
    {
        private readonly IWordFinderValidationService _wordFinderValidationService;

        public WordFinderProcessingService(IWordFinderValidationService wordFinderValidationService)
        {
            _wordFinderValidationService = wordFinderValidationService;
        }
        public char[][] CreateCharacterArray(IEnumerable<string> InputCharacterMatrix)
        {
            //Here assuming that the input character matrix number of characters per string in the matrix is same as the number of elements of the matrix to be a square matrix. 
          

            var characterMatrix = InputCharacterMatrix.Select(line => line.ToCharArray()).ToArray();

            

            return characterMatrix;


        }

        public bool IsInputStringFoundInMatrix(IEnumerable<string> InputPatterns, IEnumerable<string> InputStrings,WordFinderResponse wordFinderResponse)
        {
            foreach (var InputString in InputStrings)
            {
                foreach (var inputPattern in InputPatterns)
                {
                    if(inputPattern.IndexOf(InputString,StringComparison.OrdinalIgnoreCase) >=0)
                    {
                        wordFinderResponse.StringsFound.Add(InputString);
                    }    
                }
                if(!wordFinderResponse.StringsFound.Contains(InputString))
                {
                    wordFinderResponse.StringsNotFoundWithErrors.Add(new WordFinderErrorStringResponse { InputStringNotFound = InputString, ErrorMessage = "String not found in the pattern" });
                }

            }

            return !(wordFinderResponse.StringsNotFoundWithErrors.Count > 0);

        }
    }
}
