using UnityEngine;
using TMPro;

public class PumpkinManager : MonoBehaviour
{
    public static PumpkinManager Instance;
    public TextMeshProUGUI endText;
    private int totalPumpkinCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (endText != null)
        {
            endText.gameObject.SetActive(false);
        }
    }

    public void UpdatePumpkinCount(int change)
    {
        totalPumpkinCount += change;
        CheckPumpkinThreshold();
    }

    private void CheckPumpkinThreshold()
    {
        if (totalPumpkinCount >= 5 && endText != null)
        {
            endText.gameObject.SetActive(true);
        }
    }
}
