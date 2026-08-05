using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public GameObject[] wallpieceholder1;
    //public GameObject[] wallpieceholder2;
    //public GameObject[] wallpieceholder3;

    private int greenCounter;

    public void GreenATM()
    {
        greenCounter++;

        switch (greenCounter)
        {
            case 0:
                //wallpieceholder[0].SetActive(true);
                //wallpieceholder[1].SetActive(false);
                //wallpieceholder[2].SetActive(false);
                break;
            default:
                break;
        }
    }

}
