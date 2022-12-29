

namespace WordFinder.Core
{
    using System;
    using System.Collections.Generic;

    public class WordFinderResponse
    {
        public List<string> StringsFound { get; set; } = new List<string>();

        public List<WordFinderErrorStringResponse> StringsNotFoundWithErrors { get; set; } = new List<WordFinderErrorStringResponse>();
    }
}
