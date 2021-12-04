using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//At the start of the encounter, prompt the player that they have encountered an opponent,
//then show their abilities
public class EncounterUI : MonoBehaviour
{
    [SerializeField]
    private EncounterInstance encounter;
    [SerializeField] 
    private GameObject abilitiesPanel;

    [SerializeField]
    private TMPro.TextMeshProUGUI encounterTextBox;

    [SerializeField] 
    private float textPromptSecondsPerCharacter = 0.1f;

    private IEnumerator animateTextCoroutine = null; // If coroutine is running, this will not be null.

    // Start is called before the first frame update
    void Start()
    {
        //Disable abilities panel
        //Say something
        //Enable abilities panel
        animateTextCoroutine = AnimateTextCoroutine("You have encountered a: " + "Foo", textPromptSecondsPerCharacter);
        StartCoroutine(animateTextCoroutine);
        //StopCoroutine(animateTextCoroutine);
        encounter.onTurnBegin.AddListener(AnnounceTurnBegin);
        //encounter.player.onAbilityCast.AddListener();
        //encounter.enemy.onAbilityCast.AddListener();
    }
    void AnnounceTurnBegin(ICharacter whoseTurn)
    {
        if(animateTextCoroutine!=null)
            StopCoroutine(animateTextCoroutine);
        animateTextCoroutine = AnimateTextCoroutine("Is is  " +whoseTurn.name+ "'s turn.", textPromptSecondsPerCharacter);
        StartCoroutine(animateTextCoroutine);
    }
    //Coroutine to write our text intro/prompt
    //It will type characters out one-by-one over time, because it looks nice
    //e.g. "Hello world"
    //H
    //He
    //Hel
    //Hell
    //Hello
    IEnumerator AnimateTextCoroutine(string message, float secondsPerCharacter = 0.1f)
    {
        abilitiesPanel.SetActive((false));
        //Set text to blank
        encounterTextBox.text = "";

        //then over time, add letters until complete
        for (int currentChar = 0; currentChar < message.Length; currentChar++)
        {
            encounterTextBox.text += message[currentChar];
            yield return new WaitForSeconds(secondsPerCharacter);
        }

        abilitiesPanel.SetActive((true));
        animateTextCoroutine = null;
    }
}
