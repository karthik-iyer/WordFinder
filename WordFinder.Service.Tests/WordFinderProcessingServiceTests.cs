namespace WordFinder.Service.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using WordFinder.Core;
    using WordFinder.Service.Interface;
    using Xunit;

    public class WordFinderProcessingServiceTests
    {

        private readonly IWordFinderProcessingService wordFinderProcessingService = new WordFinderProcessingService();

        [Fact]
        public void CreateInputMatrixPattern_InvalidCharactersInMatrix_ThrowsInvalidOperationException()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\InputMatrixWithInvalidCharacters.txt");

            var inputCharacterPattern = new List<string>();




            //Act and Assert
            Assert.Throws<InvalidOperationException>(() => wordFinderProcessingService.CreateInputMatrixPattern(inputCharacterMatrixArray, inputCharacterPattern));

        }

        [Fact]
        public void CreateInputMatrixPattern_ValidCharactersInMatrix_FillsValidPattern()
        {
            //Arrange
            var inputCharacterMatrixArray = File.ReadAllLines("TestInputs\\ValidInputMatrix.txt");

            var inputCharacterPattern = new List<string>();

            //Act and Assert
            wordFinderProcessingService.CreateInputMatrixPattern(inputCharacterMatrixArray, inputCharacterPattern);

            Assert.True(inputCharacterPattern.Count > 0);

            var patternRowSize = inputCharacterMatrixArray[0].Length;

            var patternColumnSize = inputCharacterMatrixArray.Count();
            
            //tests for if the pattern is a square matrix
            Assert.True(patternRowSize == patternColumnSize);
        }


        [Fact]
        public void IsInputStringFoundInMatrix_ForValidCharacterMatrix_FewValidInputStrings_FillsResponseAsValidAndInvalid()
        {

            //Arrange
            var InputPatterns = new List<string>()
            {
            "UVFCFZJMUVJQSNTAZEHK"  ,
            "STUGUKUNXCTLNEYSGYVX"  ,
            "IODDESZGMCFPOJIUOETH"  ,
            "MODQVMUNOCRDWUVTKHPZ"  ,
            "MTPOESUFSJDCFQLPBGAJ"  ,
            "LGDSLTFSFZRXOEGBKIBI"  ,
            "ERETJMFEBKTJHYKDBAGL"  ,
            "CCOSFBPJIRHEPLBDAWUK"  ,
            "JBLHVSWFQDWOYYKWEQFN"  ,
            "JABUIKMAOWSTRGRZMENC"  ,
            "QWRRQEDKHFUNIPXKNOUL"  ,
            "TAONINTERFACEOLTUTBA"  ,
            "JYCIXWCSOINSTANCEHGS"  ,
            "QUKCVROLIAWCEBNUTYYS"  ,
            "CWGECDWSYMIHKGICWMKB"  ,
            "PSKYMTULTFNIZRLJDZGF"  ,
            "NJWYFVGXBJDLXJMTGFNV"  ,
            "ZWVFGYIJBPOLDPWYCYLA"  ,
            "TUCOLDSDYGIRMQTMJUYX"  ,
            "ZAZUGTUCZOWHNVKDJZSA"  ,
            "USIMMLECJJQTJQCPNZTZ"  ,
            "VTOOTGRCBAWAYUWSJWUA"  ,
            "FUDDPDEOLBROCKGKWVCZ"  ,
            "CGDQOSTSHURNICEYYFOU"  ,
            "FUEVELJFVIQIXVCMFGLG"  ,
            "ZKSMSTMBSKENWRDTVYDT"  ,
            "JUZUUFFPWMDTCOWUGISU"  ,
            "MNGNFSEJFAKESLSLXJDC"  ,
            "UXMOSFBIQOHROIYTBBYZ"  ,
            "VCCCJZKRDWFFIAMFJPGO"  ,
            "JTFRDRTHWSUANWINDOIW"  ,
            "QLPDCXJEOTNCSCHILLRH"  ,
            "SNOWFOHPYRIETEKZXDMN"  ,
            "NEJUQEYLYGPOABGRJPQV"  ,
            "TYIVLGKBKRXLNNILMWTK"  ,
            "ASUTPBDDWZKTCUCJTYMD"  ,
            "ZGOKBKBAEMNUETWDGCJJ"  ,
            "EYEHGIAWQEOTHYMZFYUZ"  ,
            "HVTPABGUFNUBGYKGNLYS"  ,
            "KXHZJILKNCLASSBFVAXA"  ,
            };

            var InputStrings = new List<string>()
            {
                "cold",
                "wind",
                "snow",
                "chill",
                "class",
                "interface",
                "instance",
                "way",
                "rock",
                "cot"
            };
            var wordFinderResponse = new WordFinderResponse();

            //Act
             var result = wordFinderProcessingService.IsInputStringFoundInMatrix(InputPatterns, InputStrings, wordFinderResponse);

            //Assert
            Assert.False(result);
            Assert.True(wordFinderResponse.StringsNotFoundWithErrors.Count > 0);
        }

        [Fact]
        public void IsInputStringFoundInMatrix_ForValidCharacterMatrix_ValidInputStrings_FillsResponseAsValid()
        {

            //Arrange
            var InputPatterns = new List<string>()
            {
            "UVFCFZJMUVJQSNTAZEHK"  ,
            "STUGUKUNXCTLNEYSGYVX"  ,
            "IODDESZGMCFPOJIUOETH"  ,
            "MODQVMUNOCRDWUVTKHPZ"  ,
            "MTPOESUFSJDCFQLPBGAJ"  ,
            "LGDSLTFSFZRXOEGBKIBI"  ,
            "ERETJMFEBKTJHYKDBAGL"  ,
            "CCOSFBPJIRHEPLBDAWUK"  ,
            "JBLHVSWFQDWOYYKWEQFN"  ,
            "JABUIKMAOWSTRGRZMENC"  ,
            "QWRRQEDKHFUNIPXKNOUL"  ,
            "TAONINTERFACEOLTUTBA"  ,
            "JYCIXWCSOINSTANCEHGS"  ,
            "QUKCVROLIAWCEBNUTYYS"  ,
            "CWGECDWSYMIHKGICWMKB"  ,
            "PSKYMTULTFNIZRLJDZGF"  ,
            "NJWYFVGXBJDLXJMTGFNV"  ,
            "ZWVFGYIJBPOLDPWYCYLA"  ,
            "TUCOLDSDYGIRMQTMJUYX"  ,
            "ZAZUGTUCZOWHNVKDJZSA"  ,
            "USIMMLECJJQTJQCPNZTZ"  ,
            "VTOOTGRCBAWAYUWSJWUA"  ,
            "FUDDPDEOLBROCKGKWVCZ"  ,
            "CGDQOSTSHURNICEYYFOU"  ,
            "FUEVELJFVIQIXVCMFGLG"  ,
            "ZKSMSTMBSKENWRDTVYDT"  ,
            "JUZUUFFPWMDTCOWUGISU"  ,
            "MNGNFSEJFAKESLSLXJDC"  ,
            "UXMOSFBIQOHROIYTBBYZ"  ,
            "VCCCJZKRDWFFIAMFJPGO"  ,
            "JTFRDRTHWSUANWINDOIW"  ,
            "QLPDCXJEOTNCSCHILLRH"  ,
            "SNOWFOHPYRIETEKZXDMN"  ,
            "NEJUQEYLYGPOABGRJPQV"  ,
            "TYIVLGKBKRXLNNILMWTK"  ,
            "ASUTPBDDWZKTCUCJTYMD"  ,
            "ZGOKBKBAEMNUETWDGCJJ"  ,
            "EYEHGIAWQEOTHYMZFYUZ"  ,
            "HVTPABGUFNUBGYKGNLYS"  ,
            "KXHZJILKNCLASSBFVAXA"  ,
            };

            var InputStrings = new List<string>()
            {
                "cold",
                "wind",
                "snow",
                "chill",
                "class",
                "interface",
                "instance",
                "way",
                "rock"
            };
            var wordFinderResponse = new WordFinderResponse();

            //Act
            var result = wordFinderProcessingService.IsInputStringFoundInMatrix(InputPatterns, InputStrings, wordFinderResponse);

            //Assert
            Assert.True(result);
            Assert.True(wordFinderResponse.StringsNotFoundWithErrors.Count == 0);

        }
    }
}
