using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    private short sniper = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sniperView = transform.GetChild(2);
        var NormalView = transform.GetChild(1);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sniper == 0)
            {
                sniperView.GetComponent<CanvasGroup>().alpha = 1;
                NormalView.GetComponent<CanvasGroup>().alpha = 0;
                sniper = 1;
            }
            else
            {
                sniperView.GetComponent<CanvasGroup>().alpha = 0;
                NormalView.GetComponent<CanvasGroup>().alpha = 1;
                sniper = 0;
            }
        }

        var o = transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        var oSniper = transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        if (gunfire.canFire)
        {
            o.color = Color.white;
            oSniper.color = Color.white;
        }
        else
        {
            o.color = Color.red;
            oSniper.color = Color.red;
        }

        var aligmentDisplay = transform.GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        aligmentDisplay.text = $"{Aiming.gunAlignment} m";
    }
}
