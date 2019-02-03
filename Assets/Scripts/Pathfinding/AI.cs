using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed;

    public GameObject startNode;
    public GameObject endNode;
    public float pathfindingNodeContactPadding;
    private List<GameObject> movementPath = new List<GameObject>();

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementPath = GameObject.Find("Pathfinding").GetComponent<Astar>().FindShortestPath(startNode, endNode);

        Debug.Log("_____________");
        foreach (var item in movementPath)
        {
            Debug.Log(item.name);
        }
    }
    
    void Update()
    {

        if (movementPath.Count > 0)
        {
            rb.MovePosition(Vector3.MoveTowards(rb.position, movementPath[0].transform.position, Time.deltaTime * speed));
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(movementPath[0].transform.position.x, 0, movementPath[0].transform.position.z)) < pathfindingNodeContactPadding)
            {
                movementPath.RemoveAt(0);
            }
        }
    }
}
