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
        public void CreateInputMatrixPattern(IEnumerable<string> InputCharacterMatrixArray, List<string> InputCharacterPattern)
        {

            var count = 0;

            for (int index = 0; index < InputCharacterMatrixArray.Count(); index++)
            {
                InputCharacterPattern.Add(string.Empty);
            }

            foreach (var item in InputCharacterMatrixArray)
            {
                foreach (char ch in item.ToCharArray())
                {
                    if(!IsLetter(ch))
                    {
                        throw new InvalidOperationException("Input Matrix Array has invalid characters. The WordFinder algorithm cannot be processed. Please make sure the characters are (A-Z) or (a-z)");
                    }

                    InputCharacterPattern[count] = InputCharacterPattern[count] + ch;
                    count++;
                }
                count = 0;
            }

            foreach (var item in InputCharacterMatrixArray)
            {
                InputCharacterPattern.Add(item);

            }
        }

        private bool IsLetter(char ch)
        {
                return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');            
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
                        break;
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
