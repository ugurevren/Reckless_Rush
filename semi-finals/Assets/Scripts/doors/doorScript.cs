using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class doorScript : MonoBehaviour
{
    private enum DoorType {adder, substracter, chance};
    [SerializeField] DoorType Type;
    [SerializeField] int doorValue;
    [Space(2)] 
    [SerializeField] TextMeshProUGUI valueText;

    [SerializeField] private playerStats player;
    private ParticleSystem particle;
    void Start()
    {
        valueText.text = Type == DoorType.adder ? '+' +doorValue.ToString()+"\nKm/h":
            Type == DoorType.substracter? '-' + doorValue.ToString()+"\nKm/h":
             "± ? \n Km/h";
    }

    public void UpdateKmph(AudioHandler audioHandler)
    {
        switch (Type)
        {
            case DoorType.adder:
                audioHandler.greenDoor.Play();
                player.kmph += doorValue;
                Debug.Log(player.kmph);
                particle = player.gameObject.GetComponent<playerStats>().positivePar;
                break;
            case DoorType.substracter:
                audioHandler.redDoor.Play();
                player.kmph -= doorValue;
                Debug.Log(player.kmph);
                particle = player.gameObject.GetComponent<playerStats>().negativePar;
                break;
            case DoorType.chance:
                float ch = Random.Range(0, 100);
                ch += playerStats.chance;
                if (ch > 50)
                {
                    this.Type = DoorType.adder;
                }
                else Type = DoorType.substracter;
                UpdateKmph(audioHandler);
                return;
        }
        particle.Play();
    }
}
