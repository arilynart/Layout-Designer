using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShot : MonoBehaviour
{
    public Canvas canvasToSreenShot;

    public FrontDisplay frontDisplay;

    public List<Card> PineCards = new List<Card>();

    private int counter = 0;

    // Use this for initialization
    void Start()
    {
        //Subscribe
        CanvasScreenShot.OnPictureTaken += receivePNGScreenShot;
        CanvasScreenShot screenShot = GameObject.Find("Screenshot").GetComponent<CanvasScreenShot>();

        List<List<Card>> lists = new List<List<Card>>();

        lists.Add(PineCards);

        screenShot.takeAllCards(lists, canvasToSreenShot, SCREENSHOT_TYPE.IMAGE_AND_TEXT, false);

        //take ScreenShot(Image and Text)
        screenShot.takeScreenShot(canvasToSreenShot, SCREENSHOT_TYPE.IMAGE_AND_TEXT, false);


        //take ScreenShot(Image only)
        //screenShot.takeScreenShot(canvasToSreenShot, SCREENSHOT_TYPE.IMAGE_ONLY, false);
        //take ScreenShot(Text only)
        // screenShot.takeScreenShot(canvasToSreenShot, SCREENSHOT_TYPE.TEXT_ONLY, false);

    }

    public void OnDisable()
    {
        //Un-Subscribe
        CanvasScreenShot.OnPictureTaken -= receivePNGScreenShot;
    }

    void receivePNGScreenShot(byte[] pngArray)
    {
        Debug.Log("Picture taken");

        //Do Something With the Image (Save)
        string path = Application.persistentDataPath + "/CanvasScreenShot" + counter.ToString() + ".png";
        System.IO.File.WriteAllBytes(path, pngArray);
        Debug.Log(path);

        counter++;
    }

}
