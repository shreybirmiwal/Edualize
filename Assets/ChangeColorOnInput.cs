using UnityEngine;
using TMPro;

public class ChangeColorAndDisableOnInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public Color targetBackgroundColor = Color.green;
    public float disableDelay = 3f;
    public GameObject targetObject_toDisable_after_correct;
    public string TEXT;

    void Start()
    {
        if (inputField != null)
        {
            // Add a listener to the input field to detect changes
            inputField.onValueChanged.AddListener(OnInputChange);
        }
    }

    void OnInputChange(string inputText)
    {
        // Check if the input text matches the specified condition
        if (inputText.ToLower() == TEXT)
        {
            // Change the background color of the input field
            if (inputField != null)
            {
                inputField.image.color = targetBackgroundColor;
                // Disable the input field after the specified delay
                Invoke("DisableInputField", disableDelay);
            }
        }
        else
        {
            // Reset the background color if the input text doesn't match
            if (inputField != null)
            {
                inputField.image.color = Color.white; // You can set it to the default color or any other color
            }
        }
    }

    void DisableInputField()
    {
        // Disable the input field
        if (inputField != null)
        {
            targetObject_toDisable_after_correct.SetActive(false);
        }
    }
}
