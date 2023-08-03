using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    public float radius = 20;
    private List<GameObject> waypoints = new List<GameObject>();
    public int wayPoints_length = 3;
    private NavMeshAgent agent;
    public float distance = 0.5f;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Parent = new GameObject();
        Parent.name ="WayPointsParent " + transform.name;
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        for (int i = 0; i < wayPoints_length; i++)
        {
            GameObject gameObject = new GameObject();
            waypoints.Add(gameObject);
            waypoints[i].transform.parent = Parent.transform;
            waypoints[i].transform.position = new Vector3(Random.Range(-radius, radius), 0, Random.Range(-radius, radius));
        }
    }


    void Update()
    {
        Move();
    }
    void Move()
    {
        
        Vector3 pos = new Vector3(transform.GetChild(0).position.x, 0, transform.GetChild(0).position.z);
        if (animator.GetBool("IsPatrolling"))
        {
            agent.SetDestination(waypoints[index].transform.position);
            if (index < wayPoints_length - 1)
            {
                if (Vector3.Distance(pos, waypoints[index].transform.position) < distance)
                {
                    index++;

                }
            }
            else
            {
                if (Vector3.Distance(pos, waypoints[index].transform.position) < distance)
                {
                    index = 0;

                }
            }
        }
    }
}
