using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour

{
    public int debt;
    
    public float kmph=40;
    public float horizontalVelocity=1;
    public static int chance=0;
    public ParticleSystem positivePar;
    public ParticleSystem negativePar;
    public Transform camNewPos;
    public static int bonusInitialVel = 0;
    public static bool hasShield=false;
    public GameObject shield;
    public static int goldAmount=0;
    [SerializeField] TextMeshProUGUI goldText;

    public void Start()
    {
        goldText.text = "Golds: " + goldAmount +"g";
    }

    public void Update()
    {
        goldText.text = "Golds: " + goldAmount +"g";
    }

    public static void updateGold(int g)
    {
        goldAmount += g;
    }
}
