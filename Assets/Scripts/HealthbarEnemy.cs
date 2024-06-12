using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    [SerializeField] private Transform Target;


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue/maxValue;
    }
    public void Update()
    {
        transform.position = new Vector3(Target.position.x, transform.position.y, transform.position.z);
        
    }
}
