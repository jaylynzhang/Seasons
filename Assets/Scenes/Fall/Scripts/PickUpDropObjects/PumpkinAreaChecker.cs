using UnityEngine;

public class PumpkinAreaChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pumpkin"))
        {
            PumpkinManager.Instance.UpdatePumpkinCount(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pumpkin"))
        {
            PumpkinManager.Instance.UpdatePumpkinCount(-1);
        }
    }
}
