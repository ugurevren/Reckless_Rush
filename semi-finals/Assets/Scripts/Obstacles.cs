using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject BOOM;
    [SerializeField] private bool policeCar = false;
    public GameObject badassCanvas;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,3);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Instantiate(BOOM,transform.position,transform.rotation);
            collider.gameObject.GetComponent<playerStats>().kmph -= playerStats.hasShield?0:40;
            playerStats.hasShield = false;
            Destroy(gameObject);
            if (policeCar) Instantiate(badassCanvas);
        }
    }
    
    
}
