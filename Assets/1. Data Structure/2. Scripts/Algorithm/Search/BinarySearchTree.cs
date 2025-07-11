using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BinarySearchTree : MonoBehaviour
{

    private TreeNode root; // null
    private int[] array = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
    private string result;


    /// <summary>
    /// ��ø Ŭ����, �� Ŭ���� ���ο����� ��밡����
    /// </summary>
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value)
        {
            this.value = value;
        }
    }




    private void Start()
    {
        foreach(var v in array)
        {
            root = Insert(root, v);
        }

        PreOrder(root);
        Debug.Log($"Preorder : {result}");

        result = string.Empty;
        InOrder(root);
        Debug.Log($"Inorder : {result}");
        
        
        result = string.Empty;
        PostOrder(root);
        Debug.Log($"Postorder : {result}");


    }

    // Ʈ�� ���� ���
    private TreeNode Insert(TreeNode node, int value)
    {
        if(node == null) 
            return new TreeNode(value);
        if (value < root.value) 
            node.left = Insert(node.left, value);
        else 
            node.right = Insert(node.right, value);

        return node;
    }

    private void PreOrder(TreeNode node) // ���� ��ȸ (���� ���)
    {
        // Center ������ ����
        if (node == null) return;

        result += $"{node.value}, ";
        PreOrder(node.left);
        PreOrder(node.right);
    }

    private void InOrder(TreeNode node) // ���� ��ȸ (���� ���)
    {
        // Center ������ ����
        if (node == null) return;

        PreOrder(node.left);
        result += $"{node.value}, ";
        PreOrder(node.right);
    }

    private void PostOrder(TreeNode node) // ���� ��ȸ (���� ���)
    {
        // Center ������ ����
        if (node == null) return;

        PreOrder(node.left);
        PreOrder(node.right);
        result += $"{node.value}, ";
    }
}
