using System;

namespace binary_tree
{
    class Node{
        public Node leftNode;
        public Node rightNode;
        public int data;
    }

    class BinaryTree{
        public Node root;

        public void AddNode(int value){
            Node newNode = new Node();
            newNode.data = value;

            if(root == null){
                this.root = newNode;
            }else{
                Node currentNode = this.root;
                Node previousNode = null;

                while(currentNode != null){
                    previousNode = currentNode;

                    if(currentNode.data > value){
                        currentNode = currentNode.leftNode;
                    }else if(currentNode.data < value){
                        currentNode = currentNode.rightNode;
                    }else{
                        Console.WriteLine("Can not add. Duplicate node");
                        return;
                    }
                }

                if(previousNode.data > value){
                    previousNode.leftNode = newNode;
                }else if(previousNode.data < value){
                    previousNode.rightNode = newNode;
                }
            }
        }

        public void PreOrderTraverse(Node node){
            if (node != null){
                Console.Write(node.data + " ");
                this.PreOrderTraverse(node.leftNode);
                this.PreOrderTraverse(node.rightNode);
            }
        }

        public void DeleteNode(int key){
            Node deletedNode = DeleteNode(this.root, key);
        }

        private Node DeleteNode(Node root, int key){
            // if the tree is empty
            if(root == null){
                return root;
            }

            // go down to the tree
            if(key < root.data){
                root.leftNode = DeleteNode(root.leftNode, key);
            }else if(key > root.data){
                root.rightNode = DeleteNode(root.rightNode, key);

            }
            else{
                // the node contains the key
                // root with one or not child
                if(root.leftNode == null){
                    return root.rightNode;
                }else if(root.rightNode == null){
                    return root.leftNode;
                }

                // the root has two or more children
                // get the min value from right subtree
                root.data = GetMinValue(root.rightNode);
                root.rightNode = DeleteNode(root.rightNode, root.data);
            }
            return root;
        }

        private int GetMinValue(Node root){
            int min_value = root.data;

            while(root.leftNode != null){
                min_value = root.leftNode.data;
                root = root.leftNode;
            }

            return min_value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.AddNode(5);
            tree.AddNode(1);
            tree.AddNode(9);
            tree.AddNode(3);
            tree.AddNode(10);
            tree.AddNode(8);

            tree.PreOrderTraverse(tree.root);

            tree.DeleteNode(9);
            Console.WriteLine("");
            tree.PreOrderTraverse(tree.root);
        }
    }
}
