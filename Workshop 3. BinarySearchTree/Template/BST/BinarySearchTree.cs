using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace BST
{
    public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable<T>
    {
        private T value;
        private IBinarySearchTree<T> left;
        private IBinarySearchTree<T> right;
        

        public BinarySearchTree(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        public BinarySearchTree(IBinarySearchTree<T> anotherNode)
        {
            this.value = anotherNode.Value;
            this.left = anotherNode.Left;
            this.right = anotherNode.Right;
        }

        public T Value
        {
            get => this.value;
            set => this.value = value;
        }

        public IBinarySearchTree<T> Left
        {
            get => this.left;
            set => this.left = value;
            
        }

        public IBinarySearchTree<T> Right
        {
            get => this.right;
            set => this.right = value;
        }

        public int Height
        {
            get
            {
                return GetHeight(this);
            }
        }

        public IList<T> GetInOrder()
        {                   
            var elementsList = new List<T>();
            GetInOrderRec(elementsList, this);
            return elementsList;
        }

        public IList<T> GetPostOrder()
        {
            var elementsList = new List<T>();
            GetPostOrderRec(elementsList, this);
            return elementsList;
        }

        public IList<T> GetPreOrder()
        {
            var elementsList = new List<T>();
            GetPreOrderRec(elementsList, this);
            return elementsList;
        }

        public IList<T> GetBFS()
        {
            var elementsList = new List <T>();
            var queue = new Queue<IBinarySearchTree<T>>();
            queue.Enqueue(this);
            while (queue.Count!=0)
            {
                var treeNode = queue.Dequeue();
                elementsList.Add(treeNode.Value);
                if (treeNode.Left!= null)
                {
                    queue.Enqueue(treeNode.Left);
                }
                if (treeNode.Right != null)
                {
                    queue.Enqueue(treeNode.Right);
                }
            }
            return elementsList;
        }

        public void Insert(T element)
        {
            var newNode = new BinarySearchTree<T>(element);
            BinarySearchTree<T> current = this;
            while (true)
            {
                if (current.Value.CompareTo(element) > 0)
                {
                    if (current.Left!=null)
                    {
                        current = (BinarySearchTree<T>)current.left;
                        continue;
                    }
                    current.left = newNode;
                    break;
                }
                else
                {
                    if (current.Right!= null)
                    {
                        current = (BinarySearchTree<T>)current.Right;
                        continue;
                    }
                    current.right = newNode;
                    break;
                }
            }
            
        }

        public bool Search(T element)
        {
            return FindRec(element, this);
        }

        // Advanced task!
        public bool Remove(T value)
        {
            if (!Search(value))
            {
                return false;
            }

            return RemoveSearch(value, this);           
        }
        public void GetInOrderRec(IList<T> list, IBinarySearchTree<T> treeNode)
        {
            if (treeNode.Left != null)
            {
                GetInOrderRec(list, treeNode.Left);
            }
            list.Add(treeNode.Value);
            if (treeNode.Right != null)
            {
                GetInOrderRec(list, treeNode.Right);
            }
        }
        public void GetPostOrderRec(IList<T> list, IBinarySearchTree<T> treeNode)
        {
            if (treeNode.Left != null)
            {
                GetPostOrderRec(list, treeNode.Left);
            }
            
            if (treeNode.Right != null)
            {
                GetPostOrderRec(list, treeNode.Right);
            }
            list.Add(treeNode.Value);
        }
        public void GetPreOrderRec(IList<T> list, IBinarySearchTree<T> treeNode)
        {
            list.Add(treeNode.Value);
            if (treeNode.Left != null)
            {
                GetPreOrderRec(list, treeNode.Left);
            }

            if (treeNode.Right != null)
            {
                GetPreOrderRec(list, treeNode.Right);
            }
            
        }
        public int GetHeight(IBinarySearchTree<T> treeNode)
        {
            if (treeNode == null)
            {
                return 0;
            }
            int leftHeight = treeNode.Left != null ? 1 : 0;
            int rightHeight = treeNode.Right != null ? 1 : 0;
            leftHeight += GetHeight(treeNode.Left);
            rightHeight += GetHeight(treeNode.Right);
            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }
        public bool FindRec(T element, IBinarySearchTree<T> treeNode)
        {
            if (treeNode.Value.Equals(element))
            {
                return true;
            }
            if (treeNode.Left == null && treeNode.Right == null)
            {
                return false;
            }
            if (treeNode.Value.CompareTo(element) > 0)
            {
                return FindRec(element, treeNode.Left);
            }
            else
            {
                return FindRec(element, treeNode.Right);
            }
        }
        public bool RemoveSearch(T element, IBinarySearchTree<T> treeNode)
        {
            if (treeNode.Value.Equals(element) )
            {
                if (treeNode.Left == null && treeNode.Right == null)
                {
                    treeNode = null;
                    return true;
                }
                else
                {
                    if (treeNode.Right == null)
                    {
                        treeNode.Value = treeNode.Left.Value;
                        treeNode.Left = treeNode.Left.Left;
                        return true;
                    }
                    else if (treeNode.Left == null)
                    {
                        treeNode.Value = treeNode.Right.Value;
                        treeNode.Right = treeNode.Right.Right;
                        return true;
                    }
                    else
                    {
                        var previous = treeNode;
                        var current = treeNode.Left;
                        if (current.Left == null && current.Right == null)
                        {
                            previous.Value = current.Value;
                            previous.Left = null;
                            return true;
                        }
                        while (current.Right != null)
                        {
                            previous = current;
                            current = current.Right;
                        }
                        previous.Right = current.Left;                        
                        treeNode.Value = current.Value;
                        return true;
                    }
                }                
            }

            IBinarySearchTree<T> foundNode = null;
            if (treeNode.Left != null && treeNode.Left.Value.Equals(element))
            {
                foundNode = treeNode.Left;
                if (foundNode.Left == null && foundNode.Right == null)
                {
                    treeNode.Left = null;
                    return true;
                }
                if (foundNode.Left == null)
                {
                    treeNode.Left = foundNode.Right;
                    return true;
                }
                if (foundNode.Right == null)
                {
                    treeNode.Left = foundNode.Left;
                    return true;
                }
                var previous = treeNode.Left;
                var current = treeNode.Left.Left;
                if (current.Left == null && current.Right == null)
                {
                    previous.Value = current.Value;
                    previous.Left = null;
                    return true;
                }
                while (current.Right != null)
                {
                    previous = current;
                    current = current.Right;
                }
                previous.Right = current.Left;
                foundNode.Value = current.Value;
                return true;
            }
            if (treeNode.Right!= null && treeNode.Right.Value.Equals(element))
            {
                foundNode = treeNode.Right;
                if (foundNode.Left == null && foundNode.Right == null)
                {
                    treeNode.Right = null;
                    return true;
                }
                if (foundNode.Left == null)
                {
                    treeNode.Right = foundNode.Right;
                    return true;
                }
                if (foundNode.Right == null)
                {
                    treeNode.Right = foundNode.Left;
                    return true;
                }
                var previous = treeNode.Right;
                var current = treeNode.Right.Left;
                if (current.Left == null && current.Right == null)
                {
                    previous.Value = current.Value;
                    previous.Left = null;
                    return true;
                }
                while (current.Right != null)
                {
                    previous = current;
                    current = current.Right;
                }
                previous.Right = current.Left;
                foundNode.Value = current.Value;
                return true;
            }
            if (treeNode.Left == null && treeNode.Right == null)
            {
                return false;
            }
            if (treeNode.Value.CompareTo(element) > 0)
            {
                return RemoveSearch(element, treeNode.Left);
            }
            else
            {
                return RemoveSearch(element, treeNode.Right);
            }

            
        }
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
