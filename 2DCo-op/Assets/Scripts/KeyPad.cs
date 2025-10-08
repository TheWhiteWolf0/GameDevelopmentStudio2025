using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;

public class KeyPad : MonoBehaviour
{
    [SerializeField]
    public GameObject DisapearingDoor;




    public TMP_InputField CharHolder;

    [Header("Buttons")]
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject button9;
    public GameObject button0;

    [Header("Speical")]
    public GameObject enter;
    public GameObject clear;

    public void B1()
    {
        CharHolder.text = CharHolder.text + "1";
    }

    public void B2()
    {
        CharHolder.text = CharHolder.text + "2";
    }

    public void B3()
    {
        CharHolder.text = CharHolder.text + "3";
    }

    public void B4()
    {
        CharHolder.text = CharHolder.text + "4";
    }

    public void B5()
    {
        CharHolder.text = CharHolder.text + "5";
    }

    public void B6()
    {
        CharHolder.text = CharHolder.text + "6";
    }

    public void B7()
    {
        CharHolder.text = CharHolder.text + "7";
    }

    public void B8()
    {
        CharHolder.text = CharHolder.text + "8";
    }

    public void B9()
    {
        CharHolder.text = CharHolder.text + "9";
    }

    public void B0()
    {
        CharHolder.text = CharHolder.text + "0";
    }

    public void ClearEvent()
    {
        CharHolder.text = null;
    }

    public void EnterEvent()
    {
        if(CharHolder.text == "2641")
        {
            Debug.Log("succes");
            DisapearingDoor.SetActive(false);
        }

        else
        {
            Debug.Log("fail");
        }

    }


}
