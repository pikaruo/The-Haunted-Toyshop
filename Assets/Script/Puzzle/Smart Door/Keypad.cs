using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class Keypad : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAnswer;
    [SerializeField] private GameObject keypad;
    [SerializeField] private string answer;
    [SerializeField] private GameObject door;
    [SerializeField] private Animator playAnim;


    public List<GameObject> doors = new List<GameObject>();
    // public List<Button> buttons = new List<Button>();
    // public List<string> answerCode = new List<string>();
    public List<Animator> animDoor = new List<Animator>();

    public bool isInput = true;

    private bool isDoorOffice = true;
    private bool isDoorToyshop = false;

    public bool isCorrected_Code_1=false;


    // private void Start()
    // {
    //     for (int i = 0; i < buttons.Count; i++)
    //     {
    //         int index = i;
    //         buttons[i].onClick.AddListener(() => DoorSelect(answerCode[index], doors[index], animDoor[index]));
    //     }
    // }

    // public void DoorSelect(string answerText, GameObject doorObject, Animator playAnim)
    // {
    //     keypad.SetActive(true);
    //     this.answer = answerText;
    //     this.door = doorObject;
    //     this.playAnim = playAnim;
    // }

    public void Update(){
        if(isDoorOffice == true){
            answer = "1512";
            isDoorToyshop = true;
        }else if(isDoorOffice == true && isDoorToyshop == true){
            answer = "1512";
        }else{
            textAnswer.text = "Code Successfully";
            isInput = false;
        }
    }

    public void EnterNumber(int number)
    {
        if(isInput == true){
            textAnswer.text += number.ToString();
        }
    }

    public void EnterCode()
    {
        if (textAnswer.text == answer)
        {
            isInput = false;
            textAnswer.text = "Correct";

            playAnim.SetBool("Open", true);

            Invoke("ClearTextAnswer", 4);
        }
        else
        {
            isInput = false;
            textAnswer.text = "Invalid";
            Invoke("ClearTextAnswer", 2);
        }
    }

    public void ClearTextAnswer()
    {
        textAnswer.text = "";
        isInput = true;
    }
}
