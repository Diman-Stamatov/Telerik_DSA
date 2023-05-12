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

        public T Value
        {
            get => this.value;
        }

        public IBinarySearchTree<T> Left
        {
            get => this.left;
            
        }

        public IBinarySearchTree<T> Right
        {
            get => this.right;
            
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

            return ReplaceSearch(value, this);           
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
        public bool ReplaceSearch(T element, IBinarySearchTree<T> treeNode)
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
        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
