﻿using System;
using System.Collections.Generic;
using System.Linq;
using WordFinder.Core;
using WordFinder.Service.Interface;

namespace WordFinder.Service
{
    public class WordFinderValidationService : IWordFinderValidationService
    {
        public bool DoesMatrixContainNonEnglishCharacters(char[][] InputMatrix)
        {
            throw new NotImplementedException();
        }

        public List<string> GetValidInputStrings(IEnumerable<string> InputStrings, WordFinderResponse wordFinderResponse)
        {
            var validInputStrings = new List<string>();

          
            foreach (var inputString in InputStrings)
            {
                if(inputString.Length < WordFinderConstants.MinimumInputStringLength || inputString.Length > WordFinderConstants.MaximumInputStringLength)
                {
                    wordFinderResponse.StringsNotFoundWithErrors.Add(new WordFinderErrorStringResponse { InputStringNotFound = inputString, ErrorMessage = $"{inputString} should be between 3 to 10 characters long" });
                }
                else
                {
                    validInputStrings.Add(inputString);
                }
            }

            return validInputStrings;
        }

        public bool IsInputStringEmpty(IEnumerable<string> InputStrings)
        {
            if (InputStrings.ToList().Count <= 0)
            {
                throw new ArgumentNullException("Input String is Null or Empty");
            }
            return true;
        }

        public bool IsSquareMatrix(char[][] InputMatrix)
        {
            return InputMatrix[0].GetLength(0) == InputMatrix.GetLength(1);

        }

      
    }
}
