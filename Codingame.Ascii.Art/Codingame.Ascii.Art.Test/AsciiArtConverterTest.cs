namespace Codingame.Ascii.Art.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NFluent;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestClass]
    public class AsciiArtConverterTest
    {

        private static readonly string[] AsciiArtAlphabet = new[]
            {
                " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ",
                "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ",
                "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ",
                "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ",
                "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  "
            };

        private Codingame.Ascii.Art.Solution.AsciiArtConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new Codingame.Ascii.Art.Solution.AsciiArtConverter();
        }

        [TestMethod]
        public void GivenbWhenExecuteThenReturnBAsAsciiArt()
        {
            var width = 4;
            var height = 5;
            var text = "B";

            var asciiArtTranslation = _converter.Execute(width, height, text, AsciiArtAlphabet);

            var expectedTranslation = 
                "##  " + Environment.NewLine +
                "# # " + Environment.NewLine +
                "##  " + Environment.NewLine +
                "# # " + Environment.NewLine +
                "##  " + Environment.NewLine;

            Check.That(asciiArtTranslation).IsEqualTo(expectedTranslation);
        }

        [TestMethod]
        public void GivenUnknownWhenExecuteThenReturnBQuestionMarksAsciiArt()
        {
            var width = 4;
            var height = 5;
            var text = "!";

            var asciiArtTranslation = _converter.Execute(width, height, text, AsciiArtAlphabet);

            var expectedTranslation =
                "### " + Environment.NewLine +
                "  # " + Environment.NewLine +
                " ## " + Environment.NewLine +
                "    " + Environment.NewLine +
                " #  " + Environment.NewLine;

            Check.That(asciiArtTranslation).IsEqualTo(expectedTranslation);
        }
    }
}
