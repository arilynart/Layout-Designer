using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FrontDisplay : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI copyrightText;
    public TextMeshProUGUI abilityText;

    public TextMeshProUGUI costText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI defText;

    public Image frameImg;
    public Image artImg;

    private Color32 pineColor = new Color32(13, 66, 75, 255);

    public Sprite pineFrameDef;
    public Sprite pineFrameCost;
    public Sprite pineFrameMin;

    public Card defaultCard;

    // Start is called before the first frame update
    void Awake()
    {
        if (defaultCard != null) DisplayCard(defaultCard);
    }

    public void DisplayCard(Card _card)
    {
        if (_card == null) return;

        titleText.text = _card.title;
        typeText.text = _card.type;

        abilityText.text = _card.text;
        if (_card.textFont > 0) abilityText.fontSizeMax = _card.textFont;

        if (_card.cost > 0) costText.text = _card.cost.ToString(); else costText.text = "";
        if (_card.def > 0) atkText.text = _card.atk.ToString(); else atkText.text = "";
        if (_card.def > 0) defText.text = _card.def.ToString(); else defText.text = "";

        copyrightText.text = "Art by: " + _card.artist +" — © " + DateTime.Now.Year.ToString() + " Archivym Studios. All rights reserved.";

        if (_card.art != null) artImg.sprite = _card.art;

        switch (_card.landType)
        {
            case Card.CardLand.PINES:
                //change text color
                costText.color = pineColor;
                atkText.color = pineColor;
                defText.color = pineColor;
                abilityText.color = pineColor;
                copyrightText.color = pineColor;

                switch (_card.frame)
                {
                    case Card.FrameType.MINIMUM:
                        frameImg.sprite = pineFrameMin;
                    break;
                    case Card.FrameType.COST_ONLY:
                        frameImg.sprite = pineFrameCost;
                    break;
                    case Card.FrameType.ATK_AND_DEF:
                        frameImg.sprite = pineFrameDef;
                    break;
                }
            break;
        }
    }
}
