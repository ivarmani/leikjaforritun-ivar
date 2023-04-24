using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();
    }

// telur stigin
    void SetCountText()
    {
        CountText.text = "Score: " + count.ToString();
        if(count >= 10)
        {
            Application.LoadLevel("PacifistEnd");
        }
    }
// ef að leikmaður snertir gula hlutinn þá fær hann stig
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
