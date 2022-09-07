using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Awake()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        win.SetActive(false);
        lose.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnStartButtonPressed()
    {
        Debug.Log("ğ");
        Camera.main.GetComponent<CameraFollow>().enabled = true;
        menu.SetActive(false);
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
    }

    public void OnAdButtonPressed()
    {
        playerStats.updateGold(10);
    }

    public void OnBonusVelButtonPressed()
    {
        if (playerStats.goldAmount < 40) return;
        playerStats.goldAmount -= 40;
        playerStats.bonusInitialVel = 20;
    }

    public void OnShieldButtonPressed()
    {
        if (playerStats.goldAmount < 40) return;
        playerStats.goldAmount -= 40;
        playerStats.hasShield = true;
    }

    public void OnLuckButtonPressed()
    {
        if (playerStats.goldAmount < 40) return;
        playerStats.goldAmount -= 40;
        playerStats.chance = 25;
    }

    public void OnContinuePressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
