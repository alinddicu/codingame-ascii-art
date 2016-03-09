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
    public class AsciiArtParserTest
    {
        private Codingame.Ascii.Art.Solution.AsciiArtParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new Codingame.Ascii.Art.Solution.AsciiArtParser();
        }

        [TestMethod]
        public void GivenbWhenExecuteThenReturnBAsAsciiArt()
        {
            var width = 4;
            var height = 5;
            var text = "B";
            var asciiArtAlphabet = new []
            {
                " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ",
                "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ",
                "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ",
                "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ",
                "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  "
            };

            var asciiArtTranslation = _parser.Execute(width, height, text, asciiArtAlphabet);

            var b = 
                "##  " + Environment.NewLine +
                "# # " + Environment.NewLine +
                "##  " + Environment.NewLine +
                "# # " + Environment.NewLine +
                "##  " + Environment.NewLine;

            Check.That(asciiArtTranslation).IsEqualTo(b);
        }
    }
}
