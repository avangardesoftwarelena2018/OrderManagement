namespace BST 
{
    public class BSTNode
    {
        private object data;

        public T GetData<T>()
        {
            return (T)data;
        }
        public void SetData<T>(T newData)
        {
            data = newData;
        }

        //Right Child
        private BSTNode rightNode;
        public BSTNode RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        //Left Child
        private BSTNode leftNode;
        public BSTNode LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        //Node constructor
        public BSTNode(object value)
        {
            data = value;
        }

        //recursively calls insert down the tree until it find an open spot
        public void Insert(object value)
        {
            //if the value passed in is greater or equal to the data then insert to right node
            if (value.GetHashCode() >= data.GetHashCode())
            {   //if right child node is null create one
                if (rightNode == null)
                {
                    rightNode = new BSTNode(value);
                }
                else
                {//if right node is not null recursivly call insert on the right node
                    rightNode.Insert(value);
                }
            }
            else
            {//if the value passed in is less than the data then insert to left node
                if (leftNode == null)
                {//if the leftnode is null then create a new node
                    leftNode = new BSTNode(value);
                }
                else
                {//if the left node is not null then recursively call insert on the left node
                    leftNode.Insert(value);
                }
            }
        }

        public BSTNode Find(object value)
        {
            //this node is the starting current node
            BSTNode currentNode = this;

            //loop through this node and all of the children of this node
            while (currentNode != null)
            {
                //if the current nodes data is equal to the value passed in return it
                if (value.GetHashCode() == currentNode.data.GetHashCode())
                {
                    return currentNode;
                }
                else if (value.GetHashCode() > currentNode.data.GetHashCode())//if the value passed in is greater than the current data then go to the right child
                {
                    currentNode = currentNode.rightNode;
                }
                else//otherwise if the value is less than the current nodes data the go to the left child node 
                {
                    currentNode = currentNode.leftNode;
                }
            }
            //Node not found
            return null;
        }
    }

    public class BSTTree
    {
        private BSTNode root;
        public BSTNode Root
        {
            get { return root; }
        }
        
        //O(Log n)
        public BSTNode Find(object data)
        {
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//the root is null so we return null, nothing to find
                return null;
            }
        }

        //O(Log n)
        public void Insert(object data)
        {
            //if the root is not null then we call the Insert method on the root node
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {//if the root is null then we set the root to be a new node based on the data passed in
                root = new BSTNode(data);
            }
        }
    }
}
