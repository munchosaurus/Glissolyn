using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BattleSystem : MonoBehaviour
{
    [SerializeField] bool testing;
    [SerializeField] BattleUnit PlayerUnit;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleHud PlayerHud;
    [SerializeField] BattleHud EnemyHud;
    [SerializeField] BattleDialogBox dialogBox;
    [SerializeField] CharacterBase player;
    [SerializeField] CharacterBase enemy;
    private float timer;
    private float startTime;

    //BattleState state;
    //int currentAction;
    void Start()
    {
        if (!testing)
        {
            player = Combat_Info.GetPlayer();
            enemy = Combat_Info.GetEnemy();
        }
        print(player.GetName() + "Vs." + enemy.GetName());
        StartCoroutine(SetupBattle(player, enemy));
         
    }


    public IEnumerator SetupBattle(CharacterBase player, CharacterBase enemy)
    {
        PlayerUnit.Setup(player);
        PlayerHud.SetData(PlayerUnit.Character);
        EnemyUnit.Setup(enemy);
        EnemyHud.SetData(EnemyUnit.Character);

        dialogBox.SetMoveNames(PlayerUnit.Character.Moves);

        //$ möjliggör att man kan lägga till värden i strängen.
        yield return dialogBox.TypeDialog($" You encountered a {EnemyUnit.Character.Base.GetName()}!");
        yield return new WaitForSeconds(2f);
        PlayerAction();

    }

    public void PlayerAction()
    {
        //state = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Choose an action"));
        dialogBox.EnableActionSelector(true);
        
    }

    public void PlayerMove()
    {
        //state = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }

    public void PerformPlayerMove(int index)
    {
        dialogBox.EnableMoveSelector(false);
        dialogBox.EnableDialogText(true);
        //state = BattleState.Busy;

        var move = PlayerUnit.Character.Moves[index];
        EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);

        StartCoroutine(dialogBox.TypeDialog($" You used ability: {move.Base.GetName()}"));

        //TODO Wait a little bit

        bool isDead = EnemyUnit.Character.TakeDamage(move, PlayerUnit.Character);
        EnemyHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{EnemyUnit.Character.Base.GetName()} died.");
            //TODO Wait a little bit
            yield return new WaitForSeconds(2f);
            EndBattle(true);
        } else
        {
            StartCoroutine(EnemyMove());
        }
    }

    private IEnumerator EnemyMove()
    {
        //state = BattleState.EnemyMove;
        yield return new WaitForSeconds(3f);

        var move = EnemyUnit.Character.GetRandomMove();
        PlayerUnit.Character.TakeDamage(move, EnemyUnit.Character);

        dialogBox.SetDialog($"{EnemyUnit.Character.Base.name} used {move.Base.GetName()}");
        //TODO Wait a little bit

        bool isDead = PlayerUnit.Character.TakeDamage(move, PlayerUnit.Character);
        PlayerHud.UpdateHP();

        if (isDead)
        {
            dialogBox.SetDialog($"{PlayerUnit.Character.Base.GetName()} died.");
            //TODO Wait a little bit
            yield return new WaitForSeconds(2f);
            EndBattle(true);
        }
        else
        {
            yield return new WaitForSeconds(3f);
            PlayerAction();
        }
    }

    void EndBattle(bool IsBattleOver)
    {
        if (IsBattleOver)
        {
            dialogBox.SetDialog("IsBattleOver = true");
            //TODO Gör saker beroende på vem som vann.
            Game_Controller.ToggleCombatState(false);
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
