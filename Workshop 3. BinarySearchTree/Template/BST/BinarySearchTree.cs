using System;
using System.Collections.Generic;

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
            get;
        }

        public IBinarySearchTree<T> Left
        {
            get;
        }

        public IBinarySearchTree<T> Right
        {
            get;
        }

        public int Height
        {
            get;
        }

        public IList<T> GetInOrder()
        {
            var elements = new List<T>();
            var stack = new Stack<BinarySearchTree<T>>();
            var current = this;
            stack.Push(current);
            while (stack.Count !=0)
            {
                if (current.left !=null)
                {
                    current = 
                }
            }


        }

        public IList<T> GetPostOrder()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetPreOrder()
        {
            throw new NotImplementedException();
        }

        public IList<T> GetBFS()
        {
            throw new NotImplementedException();
        }

        public void Insert(T element)
        {
            throw new NotImplementedException();
        }

        public bool Search(T element)
        {
            throw new NotImplementedException();
        }

        // Advanced task!
        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }
    }
}
