using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class InboxManager : MonoBehaviour
{
    public List<EmailMessage> allMessages;
    private List<EmailMessage> availableMessages = new List<EmailMessage>();

    public TextMeshProUGUI subjectText; // Change from Text to TextMeshProUGUI
    public TextMeshProUGUI bodyText;    // Change from Text to TextMeshProUGUI

    private void Start()
    {
        InitializeAvailableMessages();
        ShowRandomMessage();
    }

    void InitializeAvailableMessages()
    {
        availableMessages.AddRange(allMessages);
    }

    void ShowRandomMessage()
    {
        if (availableMessages.Count > 0)
        {
            int randomIndex = Random.Range(0, availableMessages.Count);
            EmailMessage currentMessage = availableMessages[randomIndex];

            // Display the message
            subjectText.text = currentMessage.subject;
            bodyText.text = currentMessage.body;

            // Remove the displayed message from the available messages
            availableMessages.RemoveAt(randomIndex);
        }
        else
        {
            Debug.Log("No more messages");
        }
    }

    public void AcceptEmail()
    {
        gameObject.SetActive(false);
    }

    public void DeclineEmail()
    {
        // Handle declining the email
        ShowRandomMessage();
    }
}
