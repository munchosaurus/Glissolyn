using System.Collections;
using UnityEngine;
using UnityEngine.UI;


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
        yield return new WaitForSeconds(1.3f);

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

        StartCoroutine(dialogBox.TypeDialog($"{PlayerUnit.Character.Base.getName()} used {move.Base.name}."));
        new WaitForSeconds(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            StartCoroutine(dialogBox.TypeDialog($"{EnemyUnit.Character.Base.getName()} died."));
        } else
        {
            StartCoroutine(EnemyMove());
        }
    }
    private void PerformPlayerMoveTwo()
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        state = BattleState.Busy;
        var move = PlayerUnit.Character.Moves[1];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        StartCoroutine(dialogBox.TypeDialog($"{PlayerUnit.Character.Base.getName()} used {move.Base.name}."));
        new WaitForSeconds(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            StartCoroutine(dialogBox.TypeDialog($"{EnemyUnit.Character.Base.getName()} died."));
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

        StartCoroutine(dialogBox.TypeDialog($"{PlayerUnit.Character.Base.getName()} used {move.Base.name}."));
        new WaitForSeconds(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            StartCoroutine(dialogBox.TypeDialog($"{EnemyUnit.Character.Base.getName()} died."));
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

        StartCoroutine(dialogBox.TypeDialog($"{PlayerUnit.Character.Base.getName()} used {move.Base.name}."));
        new WaitForSeconds(1f);

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            StartCoroutine(dialogBox.TypeDialog($"{EnemyUnit.Character.Base.getName()} died."));
        }
        else
        {
            EnemyMove();
        }
    }

    private IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;

        var move = EnemyUnit.Character.GetRandomMove();
        PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);

        yield return dialogBox.TypeDialog($"{EnemyUnit.Character.Base.name} used {move.Base.GetName()}");
        yield return new WaitForSeconds(1f);

        bool isDead = PlayerUnit.Character.TakeDamage(move, PlayerUnit.Character);
        PlayerHud.UpdateHP();

        if (isDead)
        {
            yield return dialogBox.TypeDialog($"{PlayerUnit.Character.Base.getName()} died.");
        }
        else
        {
            PlayerAction();
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
