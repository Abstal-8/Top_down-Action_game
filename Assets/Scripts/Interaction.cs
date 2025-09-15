using UnityEngine;

public class Interaction : MonoBehaviour
{
   [SerializeField] float interactionRange = 2;
   public GameObject player;
   private WaveManager waveManager;
   private UIManager uIManager;
   public GameObject waveObj;
   public GameObject uIObj;

   void Start()
   {
      waveManager = waveObj.GetComponent<WaveManager>();
      uIManager = uIObj.GetComponent<UIManager>();
   }


    
   void Update()
   {
        if (Vector3.Distance(player.transform.position, transform.position) <= interactionRange)
        {
           if (Input.GetKeyDown(KeyCode.E))
         {
            // waveObj.SetActive(true);
            // waveManager._isWaveActive = true;

            uIManager.interactPanel.SetActive(!uIManager.interactPanel.activeSelf);
         }
        }
   }

}
