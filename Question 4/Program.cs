using MMGuide;

BinaryTree myTree = new()
{
    Root = new Node(50)
    {
        Left = new Node(17),
        Right = new Node(76)
    }
};
myTree.Root.Left.Left = new Node(9);
myTree.Root.Left.Left.Right = new Node(14);
myTree.Root.Left.Left.Right.Left = new Node(12);
myTree.Root.Left.Right = new Node(23);
myTree.Root.Left.Right.Left = new Node(19);
myTree.Root.Right.Left = new Node(54);
myTree.Root.Right.Left.Right = new Node(72);
myTree.Root.Right.Left.Right.Left = new Node(67);

myTree.Root.ShowOneChildEndNote();


namespace MMGuide
{
    public class BinaryTree
    {
        public Node Root { get; set; } = null!;

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
            }
            else
            {
                Root.Add(value);
            }
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; } = null!;
        public Node Right { get; set; } = null!;

        public Node(int value) => Value = value;

        public void Add(int newValue)
        {
            if (newValue.CompareTo(Value) < 0)
            {
                if (Left == null)
                {
                    Left = new Node(newValue);
                }
                else
                {
                    Left.Add(newValue);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node(newValue);
                }
                else
                {
                    Right.Add(newValue);
                }
            }
        }

        public int NumberOfNodes
        {
            get
            {
                if (Left == null && Right == null)
                {
                    return 0;
                }

                if (Left == null || Right == null)
                {
                    return 1;
                }

                return 2;

            }
        }

        public bool IsEndNode
        {
            get
            {
                return Left == null && Right == null;
            }
        }

        public bool HasSingleEndNode
        {
            get
            {
                if (NumberOfNodes == 1)
                {
                    var SingleNode = Left==null ? Right : Left;
                    return SingleNode?.IsEndNode ?? false;
                }
                return false;
            }
        }



        public void ShowOneChildEndNote()
        {
           if (IsEndNode)
            {
                return;
            }
            if ( HasSingleEndNode)
            {
                Console.WriteLine(Value);
            }
            else
            {
                Left?.ShowOneChildEndNote();
                Right?.ShowOneChildEndNote();
            }
        }


    }

}

