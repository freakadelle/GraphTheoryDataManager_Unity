using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Graph : MonoBehaviour {

    public List<Node> nodes;
    public List<Edge> edges;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyNode(Node node)
    {
        nodes.Remove(node);

        if (node.gameObject)
            Destroy(node.gameObject);
    }

    public Node createNode(string name = "NewNode")
    {
        GameObject newNodeObject = new GameObject();
        newNodeObject.transform.parent = transform;

        Node tempNode = newNodeObject.AddComponent<Node>();
        tempNode.name = name;

        nodes.Add(tempNode);

        return tempNode;
    }
}


[CustomEditor(typeof(Graph))]
public class GraphInspector: Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Graph graph = (Graph)target;
        if (GUILayout.Button("Create Node"))
        {
            graph.createNode();
        }
    }
}