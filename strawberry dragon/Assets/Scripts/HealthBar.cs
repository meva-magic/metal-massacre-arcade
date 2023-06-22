using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthBar;
    public float maxHealth = 100f;
    public float HP;
    public float bops;

    PlayerCollision player;

    public void Start()
    {
        healthBar = GetComponent<Image>();
        HP = maxHealth;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>();
    }

    public void DropTimer()
    {
        HP = maxHealth;
        healthBar.fillAmount = HP / maxHealth;
    }

    void Update()
    {
        HP -= 6 * Time.deltaTime;
        healthBar.fillAmount = HP / maxHealth;

        if (HP <= 0)
        {
            player.GameOvered();
        }
    }
}
