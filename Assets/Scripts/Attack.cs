using System.Collections;
using UnityEngine;



public class Attack : MonoBehaviour
{
   public GameObject sword;
   [SerializeField] bool CanAttack = true;
   public float attackCooldown;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }

    void SwordAttack()
    {
        CanAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
        CanAttack = true;
    }
}
