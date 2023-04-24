using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwordKill : MonoBehaviour
{
    public TextMeshProUGUI KillText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetKillText();
    }

// telur stigin
    void SetKillText()
    {
        KillText.text = "Kills: " + count.ToString();
        if(count >= 5)
        {
            Application.LoadLevel("KillerEnd");
        }
    }
// ef að leikmaður snertir gula hlutinn þá fær hann stig
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetKillText();
        }
    }
}
