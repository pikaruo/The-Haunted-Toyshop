using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Keypad : MonoBehaviour
{
    [Header("External Preference")]
    public OpenDoorWithCode mekanika_pintu_kantor;
    public BrankasSystem mekanik_brankas;

    public Interactive interaksi;

    [Header("Internal Preference")]
    [SerializeField] private TextMeshProUGUI textAnswer;
    // [SerializeField] private GameObject keypad_panel;
    public string answerOffice;
    public string answerBrankas;
    private string textSeed; // untuk menyimpan kode sebelumnya

    // [SerializeField] private GameObject door;
    // [SerializeField] private Animator playAnim;


    // // public List<GameObject> doors = new List<GameObject>();
    // public List<Button> buttons = new List<Button>();
    // public List<string> answerCode = new List<string>();
    // public List<Animator> animDoor = new List<Animator>();

    public bool isInput = true;
    public bool isSmartDoor = true;

    private void Start()
    {   
        
        isInput = true;
        // for (int i = 0; i < buttons.Count; i++)
        // {
        //     int index = i;
        //     buttons[i].onClick.AddListener(() => DoorSelect(answerCode[index], doors[index], animDoor[index]));
        // }
    }

    // public void DoorSelect(string answerText, GameObject doorObject, Animator playAnim)
    // {
    //     keypad.SetActive(true);
    //     this.answer = answerText;
    //     this.door = doorObject;
    //     this.playAnim = playAnim;
    // }

   


    public void EnterNumber(int number)
    {
        if(isInput == true){
            if(textAnswer != null){
                textAnswer.text += number.ToString();
                textSeed += number.ToString();
            }
        }
    }

    public void EnterCode()
    {
        if(isSmartDoor){
            if(isInput == true){
                if (textSeed == answerOffice)
                {
                    isInput = false;
                    textAnswer.text = "Correct";
                    AudioManager.Instance.TestTwo();

                    interaksi.PintuTerbuka = true;

                    mekanika_pintu_kantor.isOpen = true;
                    Invoke("ClearTextAnswer", 4);
                }
                else
                {
                    isInput = false;
                    textAnswer.text = "Invalid";

                    Invoke("ClearTextAnswer", 4);
                }
            }
        }else{
            if(isInput == true){
                if (textSeed == answerBrankas)
                {
                    isInput = false;
                    textAnswer.text = "Correct";

                    interaksi.BrankasTerbuka = true;

                    mekanik_brankas.isOpen = true;
                    AudioManager.Instance.TestTwo();

                    Invoke("ClearTextAnswer", 2);
                }
                else
                {
                    isInput = false;
                    textAnswer.text = "Invalid";

                    Invoke("ClearTextAnswer", 2);
                }
            }
        }
    }

    public void ClearTextAnswer()
    {
        isInput = true;
        textAnswer.text = "";
        textSeed = "";
    }

}
