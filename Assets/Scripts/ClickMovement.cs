using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ClickMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Vector3 _worldPosition; 
    [SerializeField] private float _rayDis;

    [SerializeField] private LayerMask _currentLayer;
    private EnemyProperties enemyProperties;
    private PlayerProperties playerProperties;
    
    private RaycastHit hitData;
    private GameObject targetObj;
    


    
    void Start()
    {
        _camera = _camera.GetComponent<Camera>();
        enemyProperties = GetComponent<EnemyProperties>();
        playerProperties = GetComponent<PlayerProperties>();
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hitData, 100, _currentLayer))
        {
           
           if (Input.GetMouseButtonDown(0))
           {
                _worldPosition = hitData.point;
                targetObj = hitData.transform.gameObject;
           }
           if (targetObj != null && (targetObj.layer == LayerMask.NameToLayer("Enemy") || targetObj.layer == LayerMask.NameToLayer("Interactable")))
           {
                if (Vector3.Distance(targetObj.transform.position, transform.position) <= playerProperties.attackDistace)
                {
                    _worldPosition = transform.position;
                }
           }
        

        }

        _worldPosition.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, _worldPosition, 5f * Time.deltaTime);
        transform.LookAt(_worldPosition);
        Debug.DrawRay(ray.origin, _camera.transform.forward * _rayDis, Color.black);
        
    }

    void OnDrawGizmos()
    {
        // Gizmos.color = Color.white;
        // Gizmos.DrawWireSphere(transform.localPosition + transform.forward*1.5f, 1.3f);
        //Gizmos.DrawSphere(this.transform.position, 0.5f);
        Gizmos.DrawWireSphere(_worldPosition, 0.5f);
       
    }

}