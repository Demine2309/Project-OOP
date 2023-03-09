using UnityEngine;
using UnityEngine.UI;

// Nguyễn Như Cường - 20200076
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;  
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
