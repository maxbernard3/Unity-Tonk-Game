using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public static string range = "0";

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

        var rangeDisplay = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        switch (range.Length)
        {
            case 1 :
                rangeDisplay.text = $"0 0 0 0  m";
                break;
            case 2:
                rangeDisplay.text = $"0 0 {range[0]} {range[1]}  m";
                break;
            case 3:
                rangeDisplay.text = $"0 {range[0]} {range[1]} {range[2]} m";
                break;
            case 4:
                rangeDisplay.text = $"{range[0]} {range[1]} {range[2]} {range[3]} m";
                break;
            default:
                rangeDisplay.text = $"9 9 9 9 m";
                break;
        }

        var point = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
        point.text = $"{target.point}";
    }
}
