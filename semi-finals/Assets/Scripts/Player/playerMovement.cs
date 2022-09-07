using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private playerStats _stats;
    private AudioHandler _audios;
    public GameObject lost;
    public GameObject won;
    public GameObject flash;
    
    
    public Vector3 targetPoint;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        _audios = GetComponent<AudioHandler>();
        _characterController = GetComponent<CharacterController>();
        _stats = GetComponent<playerStats>();
    }


    private void Update()
    {
        _stats.shield.SetActive(playerStats.hasShield);
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                targetPoint.x = touch.deltaPosition.x * _stats.horizontalVelocity*0.1f;
            }
        }
        else
        {
            targetPoint.x = 0;
        }
        targetPoint.z = 5+(_stats.kmph-40+playerStats.bonusInitialVel)/20;
        if (_stats.kmph < 40)
            _stats.kmph = 40;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move(targetPoint * (Time.fixedDeltaTime ));
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Door"))
        {
            other.GetComponent<doorScript>().UpdateKmph(_audios);
            return;
        }

        if (other.CompareTag("Finish"))
        {
            Camera.main!.GetComponent<CameraFollow>().enabled = false;
            StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _audios.cam.Play();
        Camera.main.transform.position = _stats.camNewPos.position;
        Camera.main.transform.rotation = _stats.camNewPos.rotation;
        flash.SetActive(false);
        if (_stats.kmph > _stats.debt)
            StartCoroutine(Win());
        else
        {
            StartCoroutine(Lose());
            Debug.Log("Kardeşler Pide & Kebap Oyun Geliştirme Stüdyosu");
        }

    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(.1f);
        _audios.success.Play();
        won.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(.1f);
        _audios.failed.Play();
        lost.SetActive(true);
        Time.timeScale = 0;
    }
}
