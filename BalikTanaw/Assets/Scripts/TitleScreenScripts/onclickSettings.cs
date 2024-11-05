using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Make sure to include this for Button

public class OnClickSettings : MonoBehaviour
{
    public GameObject settingsPanel; // Reference to the settings panel
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = settingsPanel.GetComponent<Animator>();
        settingsPanel.SetActive(false); // Ensure the panel is hidden at start
    }

    public void ToggleSettingsPanel()
    {
        if (settingsPanel.activeSelf)
        {
            animator.SetTrigger("Close"); // Trigger the close animation
            Invoke("DeactivatePanel", 0.5f); // Adjust time based on animation length
            EnableTitleScreenButtons(); // Re-enable buttons when closing
        }
        else
        {
            settingsPanel.SetActive(true); // Show the panel
            animator.SetTrigger("Open"); // Trigger the open animation
            DisableTitleScreenButtons(); // Disable buttons when opening
        }
    }

    private void DeactivatePanel()
    {
        settingsPanel.SetActive(false); // Hide the panel after closing
    }

    private void DisableTitleScreenButtons()
    {
        // Find all GameObjects with the "TitleButton" tag
        GameObject[] titleButtonObjects = GameObject.FindGameObjectsWithTag("TitleButton");
        foreach (GameObject buttonObject in titleButtonObjects)
        {
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false; // Disable each button
                button.gameObject.SetActive(false); // Optionally hide the button
            }
        }
    }

    private void EnableTitleScreenButtons()
    {
        // Find all GameObjects with the "TitleButton" tag
        GameObject[] titleButtonObjects = GameObject.FindGameObjectsWithTag("TitleButton");
        foreach (GameObject buttonObject in titleButtonObjects)
        {
            Button button = buttonObject.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = true; // Enable each button
                button.gameObject.SetActive(true); // Optionally show the button
            }
        }
    }
}