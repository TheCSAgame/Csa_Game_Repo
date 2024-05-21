using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{
    [SerializeField] private health playerhealth;
    [SerializeField] private Image tphBar;
    [SerializeField] private Image cphBar;

    void Start()
    {
        tphBar.fillAmount = playerhealth.CurrentHealth / playerhealth.StartingHealth;
    }

    void Update()
    {
        cphBar.fillAmount = playerhealth.CurrentHealth / playerhealth.StartingHealth;
    }
}
