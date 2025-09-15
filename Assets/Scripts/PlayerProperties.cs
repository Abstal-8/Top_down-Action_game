using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    private int maxHealth = 10;
    public int currentHealth;

    [Header("Attack")]
    public float attackDistace;
    public int attackDamage;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
