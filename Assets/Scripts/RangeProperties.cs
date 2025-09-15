using UnityEngine;

public class RangeProperties : MonoBehaviour
{
    public bool _canAttack;

    void OnTriggerStay(Collider other)
    {
       // Debug.Log("Hit " + other.gameObject.name);
    }
    void OnTriggerEnter(Collider other)
    {
       _canAttack = true;
       if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
       {
          //  Debug.Log("Enemy has entered");
       }
    }
    void OnTriggerExit(Collider other)
    {
       _canAttack = false;
    }
}
