using UnityEngine;

public class UselessMachine : MonoBehaviour
{
    [SerializeField] private float time;

    // Update is called once per frame
    private void Awake()
    {
        Destroy(gameObject,time);
    }
}
