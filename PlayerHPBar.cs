using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI HP_text;

    public int maxHp = 600;
    public int Initial = 1;
    public int currentHp;

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //Sliderを満タンにする。
        slider.value = (float)Initial / (float)maxHp; ;
        //現在のHPを最大HPと同じに。
        currentHp = Initial;

        HP_text.text = "HP " + currentHp.ToString("0000") + " / " + maxHp.ToString("0000");

    }

    public bool HpValue(int Hp)
    {
        bool Result = true;

        if(currentHp <= maxHp)
        {
            currentHp = currentHp + Hp;

            if (currentHp >= maxHp)
            {
                currentHp = maxHp;
            }
            else if(currentHp <= 0)
            {
                currentHp = 0;
            }

            if (currentHp <= 0)
            {
                Result = false;
            }

            slider.value = (float)currentHp / (float)maxHp;
        }

        HP_text.text = "HP " + currentHp.ToString("0000") + " / " + maxHp.ToString("0000");

        return Result;

    }

}
