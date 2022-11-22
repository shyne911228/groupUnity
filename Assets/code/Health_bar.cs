using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Health_bar : MonoBehaviour
{
    public TextMeshProUGUI Health;
    public static int healthnow;
    public  static int healthmax;
    private Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar=GetComponent<Image>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount=(float)healthnow/(float)healthmax;
        Health.text=healthnow.ToString()+"/"+healthmax.ToString();
    }
}
