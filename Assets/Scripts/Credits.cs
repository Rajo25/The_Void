using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject CreditsUI;

    public Button Back_;


    void Start()
    {
        Back_.onClick.AddListener(Back);
    }

    private void Back()
    {
        CreditsUI.SetActive(false);
    }

}
