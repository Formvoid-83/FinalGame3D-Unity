using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFollow : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent enemy;
    [SerializeField]
    private Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
}
