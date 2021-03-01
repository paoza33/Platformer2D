using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;
        //la couleur prend la valeur la plus à droite de notre gradient (le gradient est compris entre 0 et 1f)
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth( int health){
        slider.value = health;
        //normalizedValue permet de mettre la valeur value entre 0 et 1 (ex: value = 50  normalizedValue = 0.5)
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
