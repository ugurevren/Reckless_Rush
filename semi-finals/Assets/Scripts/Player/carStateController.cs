using System.Collections;
using UnityEngine;

public class carStateController : MonoBehaviour
{
    public int [] upgradePoint;
    public GameObject[] cars;
    private playerStats _stats;
    private AudioHandler audio;
    private int curCar=0;
    private Animator animator;
    private bool transforming = false;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        _stats = gameObject.GetComponent<playerStats>();
        audio = GetComponent<AudioHandler>();
    }

    private void Update()
    {
        if (_stats.kmph > upgradePoint[curCar])
        {
            StartCoroutine(TransformCar(true));
        }
        else if (curCar>0&&_stats.kmph < upgradePoint[curCar - 1])
        {
            StartCoroutine(TransformCar(false));
        }
        else
        {
            animator.SetBool("transform",false);
            if (cars[curCar].activeSelf) return;
            cars[curCar].SetActive(true);
            for (int i = 0; i < cars.Length; i++)
            {
                if (i != curCar)
                    cars[i].SetActive(false);
            }

            
        }
    }

    private IEnumerator TransformCar(bool upgrade)
    {
        if (transforming) yield break;
        transforming = true;
        if (upgrade)
        {
            animator.SetBool("transform", true);
            yield return new WaitForSeconds(0.5f);
            curCar++;
            audio.transform.Play();
        }
        else
        {
            animator.SetBool("transform", true);
            yield return new WaitForSeconds(0.5f);
            curCar--;
            audio.transform.Play();
        }

        transforming = false;
    }
}
