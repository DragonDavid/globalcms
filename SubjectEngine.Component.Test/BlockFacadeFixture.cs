using Global.Data;
using Global.DataConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SubjectEngine.Component.Test
{
    [TestClass]
    public class BlockFacadeFixture : FixtureBase
    {
        [TestMethod]
        public void TestAll()
        {
            BlockFacade facade = new BlockFacade(UnitOfWork);
            List<BlockInfoDto> result = facade.GetBlocksInfo<BlockInfoDto>(new BlockInfoConverter());
            if (result != null)
            {
            }

            BlockInfoDto item = facade.GetBlockInfo<BlockInfoDto>(7, new BlockInfoConverter());
        }
    }
}
