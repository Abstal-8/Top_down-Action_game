using Unity.VisualScripting;
using UnityEngine;

public class PointTest : MonoBehaviour
{

    [SerializeField] private GameObject player;


    void OnDrawGizmos()
    {
        var col = GetComponent<Collider>();

        if (!col)
        {
            return; // nothing to do without a collider
        }

        Vector3 closestPoint = col.ClosestPoint(player.transform.position);

        Gizmos.DrawSphere(player.transform.position, 0.5f);
        Gizmos.DrawWireSphere(closestPoint, 0.5f);
    }
}
