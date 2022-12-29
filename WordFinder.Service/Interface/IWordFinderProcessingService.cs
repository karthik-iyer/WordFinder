using System;
using System.Collections.Generic;
using System.Text;
using WordFinder.Core;

namespace WordFinder.Service.Interface
{
    public interface IWordFinderProcessingService
    {
        public void CreateInputMatrixPattern(IEnumerable<string> InputCharacterMatrixArray, List<string> InputCharacterPattern);
        public bool IsInputStringFoundInMatrix(IEnumerable<string> InputPattern, IEnumerable<string> InputStrings,WordFinderResponse wordFinderResponse);
    }
}
