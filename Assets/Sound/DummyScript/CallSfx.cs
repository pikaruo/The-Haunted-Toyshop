using UnityEngine;
using UnityEngine.UI;

public class CallSfx : MonoBehaviour
{

    public Button btnOne;
    public Button btnTwo;
    public Button btnThree;


    private void Start()
    {
        btnOne.onClick.AddListener(() => AudioManager.Instance.TestOne());
        btnTwo.onClick.AddListener(() => AudioManager.Instance.TestTwo());
        btnThree.onClick.AddListener(() => AudioManager.Instance.TestThree());

    }

}
