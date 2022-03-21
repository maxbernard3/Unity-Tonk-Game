using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var sniperView = transform.GetChild(2);
        var NormalView = transform.GetChild(1);

        if (CameraControler.sniper)
        {
            sniperView.GetComponent<CanvasGroup>().alpha = 1;
            NormalView.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            sniperView.GetComponent<CanvasGroup>().alpha = 0;
            NormalView.GetComponent<CanvasGroup>().alpha = 1;
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

        var aligmentDisplay = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        aligmentDisplay.text = $"{Aiming.gunAlignment} m";

        var point = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        point.text = $"{target.point}";
    }
}
