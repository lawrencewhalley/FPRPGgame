using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    [SerializeField] private Image StaminaSprite;
    [SerializeField] private float reduceSpeed = 1;
    private float target = 1;

    public Camera _cam;

    public void updateStaminaBar(float maxStamina, float currentStam)
    {
        target = currentStam / maxStamina;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
        StaminaSprite.fillAmount = Mathf.MoveTowards(StaminaSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
    }
}
