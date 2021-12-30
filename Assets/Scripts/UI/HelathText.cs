using UnityEngine;
using UnityEngine.UI;

public class HelathText : MonoBehaviour
{
    [SerializeField] private Text uiHealthText;
    void Update()
    {
        gameObject.transform.LookAt(Camera.main.transform);
    }

    public void SetHealthText(float currentHealth, float maxHealth)
    {
        uiHealthText.text = currentHealth.ToString() + " \\ " + maxHealth.ToString();
    }
}
