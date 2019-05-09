using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4;
    public GameObject dialogBox;

    private float displayTimer;

    private void Start()
    {
        dialogBox.SetActive(false);
        displayTimer = -1.0f;
    }

    private void Update()
    {
        if (displayTimer >= 0)
        {
            displayTimer -= Time.deltaTime;
            if (displayTimer < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        displayTimer = displayTime;
        dialogBox.SetActive(true);
    }
}
