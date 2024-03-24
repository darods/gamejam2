using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementOponent : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    private GameObject[] waypoints= new GameObject[6];
    int currentWaypointIndex = 0;
    private Rigidbody rb;
    public PositionManager master;
    public float aiDistance;
    public GameObject[] points;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // rb = GetComponent<Rigidbody>();
        SearchWaypoints();

    }

    // Update is called once per frame
    void Update()
    {
        // Si el agente ha llegado a su destino actual, establece el siguiente punto de destino
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 1f)
        {
            SetNextWaypoint();
        }

        FindDistance();
        // transform.Rotate(Vector3.forward, 30.0f * Time.deltaTime);
    }

    void SetNextWaypoint()
    {

        if (currentWaypointIndex < waypoints.Length)
        {
      
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].transform.position);
            currentWaypointIndex++;
        }else 
        {
            currentWaypointIndex = 0;
        }
    }

    void SearchWaypoints()
    {
        for (int i = 0; i < 6; i++)
        {
            waypoints[i] = GameObject.Find("WayPoint_" + i);
        }
    }

    public void FindDistance()
    {
        aiDistance = Vector3.Distance(points[master.currentPoint].transform.position, transform.position);
    }
}
