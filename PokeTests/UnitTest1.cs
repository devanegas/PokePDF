using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokePDF.Services;
using Moq;

namespace PokeTests
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {

        }

        [TestMethod]
        public void UserEntersPokemonName_GetsPokemonInformationBack()
        {
            var PokeService = new Mock<PokeInformationService>();
        }
    }
}
