using WinFlows.Blocks.Connectors;

namespace WinFlows.Blocks
{
    public static class BlockFactory
    {
        public static (Block, Block) CreateBlocksForInsert(string blockData)
        {
            if (blockData == null || !blockData.StartsWith("BLOCK:"))
            {
                MessageBox.Show($"BlockFactory cannot create block from {blockData}");
                return (new StartBlock(), new StartBlock());
            }

            blockData = blockData.Substring("BLOCK:".Length);

            Block block1, block2;

            switch (blockData)
            {
                case "INPUT":
                    block1 = new InBlock();
                    block2 = block1;
                    break;
                case "OUTPUT":
                    block1 = new OutBlock();
                    block2 = block1;
                    break;
                case "ASSIGN":
                    block1 = new AssignBlock();
                    block2 = block1;
                    break;
                case "IF":
                    block2 = new SplitFlowConnector();
                    block1 = new IfBlock((SplitFlowConnector)block2);
                    var leftDownRight = new LeftDownRightConnector
                    {
                        From = block1,
                        South = block2
                    };
                    var rightDownLeft = new RightDownLeftConnector
                    {
                        From = block1,
                        South = block2
                    };
                    block1.West = leftDownRight;
                    block1.East = rightDownLeft;
                    break;
                case "WHILE":
                    var rightUpLeft = new RightUpLeftConnector();
                    block1 = new LoopFlowConnector(rightUpLeft);
                    block2 = new WhileBlock((LoopFlowConnector)block1);

                    rightUpLeft.From = block2;
                    rightUpLeft.South = block1;

                    block1.South = block2;
                    block2.East = rightUpLeft;
                    break;
                default:
                    MessageBox.Show($"BlockFactory cannot create block from {blockData}");
                    return (new StartBlock(), new StartBlock());
            };

            return (block1, block2);
        }
    }
}
