using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private PlayerProperties playerProperties;
    [SerializeField] GameObject player;

    void Start()
    {
        playerProperties = player.GetComponent<PlayerProperties>();
    }



    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy")
        {
           var enemy = other.GetComponent<EnemyProperties>();
           if (enemy != null)
           {
                enemy.currentHealth -= playerProperties.attackDamage;
                Debug.Log("Enemy health: " + enemy.currentHealth);
           }
        }
    }
}
