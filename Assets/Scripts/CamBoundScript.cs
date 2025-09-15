using UnityEngine;

public class CamBoundScript : MonoBehaviour
{

    [SerializeField] private BoxCollider _field;



    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.z == _field.bounds.extents.z)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, _field.bounds.extents.z);
        }
    }
}
