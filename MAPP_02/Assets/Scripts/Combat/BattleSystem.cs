using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud PlayerHud;
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] BattleDialogBox dialogBox;

    [SerializeField] Button fight;
    [SerializeField] Button run;
    [SerializeField] Button a1, a2, a3, a4;

    BattleState state;
   // int currentAction;
    void Start()
    {
        StartCoroutine(SetupBattle());
         
    }

    public IEnumerator SetupBattle()
    {
        PlayerUnit.Setup();
        PlayerHud.SetData(PlayerUnit.Character);
        EnemyUnit.Setup();
        EnemyHud.SetData(EnemyUnit.Character);

        dialogBox.SetMoveNames(PlayerUnit.Character.Moves);

        //$ möjliggör att man kan lägga till värden i strängen.
        yield return dialogBox.TypeDialog($"You encountered a {EnemyUnit.Character.Base.getName()}!");
        yield return new WaitForSeconds(1.5f);

        PlayerAction();

    }

    public void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
        
    }

    public void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    /*
    public IEnumerator PerformPlayerMove(int index)
    {
        var move = PlayerUnit.Character.Moves[index];
            yield return dialogBox.TypeDialog($"{PlayerUnit.Character.Base.name} used {move.Base.GetName()}");
    }
    */


    private void Update()
    {
        if(state == BattleState.PlayerAction)
        {
            Button b1 = fight.GetComponent<Button>();
            Button b2 = run.GetComponent<Button>();

            b1.onClick.AddListener(PlayerMove);
            b2.onClick.AddListener(PlayerMove);
        }

        if (state == BattleState.PlayerMove)
        {
     
            Button b1 = a1.GetComponent<Button>();
            Button b2 = a2.GetComponent<Button>();
            Button b3 = a3.GetComponent<Button>();
            Button b4 = a4.GetComponent<Button>();

           
           b1.onClick.AddListener(PerformPlayerMoveOne);
           b2.onClick.AddListener(PerformPlayerMoveTwo);
           b3.onClick.AddListener(PerformPlayerMoveThree);
           b4.onClick.AddListener(PerformPlayerMoveFour);
           
        }
    }

    //temporär funktion som är identiska förutom index.
    private void PerformPlayerMoveOne()
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        state = BattleState.Busy;

        var move = PlayerUnit.Character.Moves[0];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        dialogBox.SetDialog($"You used ability: {move.Base.GetName()}");
        new WaitForSecondsRealtime(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{EnemyUnit.Character.Base.getName()} died.");
            new WaitForSecondsRealtime(1f);
            EndBattle(true);
        } else
        {
            EnemyMove();
        }
    }
    private void PerformPlayerMoveTwo()
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        state = BattleState.Busy;
        var move = PlayerUnit.Character.Moves[1];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        dialogBox.SetDialog($"You used ability: {move.Base.GetName()}");
        new WaitForSecondsRealtime(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{EnemyUnit.Character.Base.getName()} died.");
            new WaitForSecondsRealtime(1f);
            EndBattle(true);
        }
        else
        {
            EnemyMove();
        }
    }

    private void PerformPlayerMoveThree()
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        state = BattleState.Busy;
        var move = PlayerUnit.Character.Moves[2];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        dialogBox.SetDialog($"You used ability: {move.Base.GetName()}");
        new WaitForSecondsRealtime(1f); 

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{EnemyUnit.Character.Base.getName()} died.");
            new WaitForSecondsRealtime(1f);
            EndBattle(true);
        }
        else
        {
            EnemyMove();
        }
    }
    private void PerformPlayerMoveFour()
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        state = BattleState.Busy;
        var move = PlayerUnit.Character.Moves[3];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        dialogBox.SetDialog($"You used ability: {move.Base.GetName()}");
        new WaitForSecondsRealtime(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{EnemyUnit.Character.Base.getName()} died.");
            new WaitForSecondsRealtime(1f);
            EndBattle(true);
        }
        else
        {
            EnemyMove();
        }
    }

    private void EnemyMove()
    {
        state = BattleState.EnemyMove;

        var move = EnemyUnit.Character.GetRandomMove();
        PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);

        dialogBox.SetDialog($"{EnemyUnit.Character.Base.name} used {move.Base.GetName()}");
        new WaitForSecondsRealtime(1f);

        bool isDead = PlayerUnit.Character.TakeDamage(move, PlayerUnit.Character);
        PlayerHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{PlayerUnit.Character.Base.getName()} died.");
            new WaitForSecondsRealtime(1f);
            EndBattle(true);
        }
        else
        {
            PlayerAction();
        }
    }

    void EndBattle(bool IsBattleOver)
    {
        if (IsBattleOver)
        {
            dialogBox.SetDialog("IsBattleOver = true");
            //ladda andra scenen. 
            //SceneManager.LoadScene("NamnPåScenen");
        }
    }
}
public enum BattleState
{
    Start,
    PlayerAction,
    PlayerMove,
    EnemyMove,
    Busy
}
