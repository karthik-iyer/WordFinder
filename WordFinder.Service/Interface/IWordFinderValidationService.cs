using System;
using System.Collections.Generic;
using System.Text;
using WordFinder.Core;

namespace WordFinder.Service.Interface
{
    public interface IWordFinderValidationService
    {
        public List<string> GetValidInputStrings(IEnumerable<string> InputStrings, WordFinderResponse wordFinderResponse);

        public bool IsSquareMatrix(IEnumerable<string> InputMatrix);

        public bool IsInputStringEmpty(IEnumerable<string> InputStrings);
    }
}
