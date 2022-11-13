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
        //SliderÇñûÉ^ÉìÇ…Ç∑ÇÈÅB
        slider.value = (float)Initial / (float)maxHp; ;
        //åªç›ÇÃHPÇç≈ëÂHPÇ∆ìØÇ∂Ç…ÅB
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
