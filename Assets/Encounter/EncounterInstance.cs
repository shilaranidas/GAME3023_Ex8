using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EncounterInstance : MonoBehaviour
{
    private int turnNumber;
    public int TurnNumber
    {
        get { return turnNumber; }
        private set { turnNumber = value; }
    }
    [SerializeField]
    public PlayerCharacter player;
    [SerializeField]
    public AICharacter enemy;
    public ICharacter currentCharacter;
    public UnityEvent<PlayerCharacter> onPlayerTurnBegin;
    public UnityEvent<PlayerCharacter> onPlayerTurnEnd;
    // Start is called before the first frame update
    public UnityEvent<AICharacter> onEnemyTurnBegin;
    public UnityEvent<AICharacter> onEnemyTurnEnd;
    public UnityEvent<ICharacter> onTurnBegin;
    public UnityEvent<ICharacter> onTurnEnd;
    void Start()
    {
        currentCharacter = player;
        player.onAbilityCast.AddListener(OnAbilityCastCallback);
        MusicManager.Instance.PlayTrack(MusicManager.TrackID.Battle);
    }
    public void OnAbilityCastCallback(Ability casted)
    {
        AdvancedTurns();
    }
    public void AdvancedTurns()
    {
        turnNumber++;
        if(currentCharacter==player)
        {
            currentCharacter = enemy;
            player.onAbilityCast.RemoveListener(OnAbilityCastCallback);
            enemy.onAbilityCast.AddListener(OnAbilityCastCallback);
            onPlayerTurnEnd.Invoke(player);
            onEnemyTurnBegin.Invoke(enemy);
        }
        else
        {
            currentCharacter = player;
            enemy.onAbilityCast.RemoveListener(OnAbilityCastCallback);
            player.onAbilityCast.AddListener(OnAbilityCastCallback);
            onEnemyTurnEnd.Invoke(enemy);
            onPlayerTurnBegin.Invoke(player);
        }
        onTurnBegin.Invoke(currentCharacter);
        currentCharacter.TakeTurn(this);
        //turnNumber++;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndBattle()
    {
        FindObjectOfType<WorldTraveller>().ExitEncounter();
    }
}
