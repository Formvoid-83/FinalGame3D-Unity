using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshFollow : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent enemy;
    [SerializeField]
    private float enemySpeed;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float timer = 5;
    private float bulletTime;
    GameObject bulletObject;
    [SerializeField]
    private GameObject enemyBullet;
    [SerializeField]
    private Transform spawnPoint;
    Rigidbody bulletRig;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }
    void ShootAtPlayer(){
        bulletTime -= Time.deltaTime;
        if(bulletTime > 0) return;
        bulletTime = timer;
        bulletObject = Instantiate(enemyBullet, spawnPoint.transform.position,spawnPoint.transform.rotation) as GameObject;
        bulletRig = bulletObject.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
    }
}
