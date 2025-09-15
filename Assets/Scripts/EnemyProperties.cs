using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
  
  private int maxHealth = 5;
  private Vector3 walkPoint;
  private WaveManager waveManager;
  [SerializeField] private bool _isPatrolling;
  [SerializeField] private bool _isChasing;
  [SerializeField] private int aggroRadius;
  [SerializeField] private int attackRange;
  public int currentHealth;
  public float moveSpeed;

  public GameObject player;
  public GameObject walkSpace;
  public GameObject waveObj;
  

  void Start()
  {
    currentHealth = maxHealth;
    waveManager = waveObj.GetComponent<WaveManager>();
    CreateWalkPoint();
  }

  void Update()
  {
    if (currentHealth <= 0)
    {
      currentHealth = 0;
      waveManager.enemyCount--;
      Destroy(this.gameObject);
    }


    if (Vector3.Distance(transform.position, player.transform.position) >= aggroRadius)
    {
      _isPatrolling = true;
      _isChasing = false;
    }
    else {
      _isChasing = true;
      _isPatrolling = false;
    }

    if (_isPatrolling)
    {
      Patrol();
    }
    else if (_isChasing)
    {
      Chase();
    }
      
  }
  

  void CreateWalkPoint()
  {
    float rangeX = Random.Range(-40, 40);
    float rangeZ = Random.Range(-45, 45);
    walkPoint = new Vector3(rangeX, 1f, rangeZ);
  }

  void Patrol()
  {
    if (Vector3.Distance(walkPoint, transform.position) > 1f)
      {
        transform.position = Vector3.MoveTowards(transform.position, walkPoint, moveSpeed * Time.deltaTime);
      }
      else {
        CreateWalkPoint();
      }
  }
  void Chase()
  {
    if (Vector3.Distance(transform.position, player.transform.position) <= attackRange)
    {
      transform.SetPositionAndRotation(transform.localPosition, transform.localRotation);
    }
    else
    {
      transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }
    
  }

  void OnDrawGizmos()
  {
    Gizmos.color = Color.cyan;
    Gizmos.DrawWireSphere(walkPoint, 0.5f);
      
  }

}
