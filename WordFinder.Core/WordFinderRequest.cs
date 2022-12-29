using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Core
{
    public class WordFinderRequest
    {
        public IEnumerable<string> InputCharacterMatrixPattern { get; set; }
    }
}
