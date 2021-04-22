using System.Collections;
using System.Collections.Generic;
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
        PlayerHud.SetData(PlayerUnit.character);
        EnemyUnit.Setup();
        EnemyHud.SetData(EnemyUnit.character);

        dialogBox.SetMoveNames(PlayerUnit.character.Moves);

        //$ möjliggör att man kan lägga till värden i strängen.
        yield return dialogBox.TypeDialog($"You encountered a {EnemyUnit.character._base.getName()}!");
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

  /*  public IEnumerator PerformPlayerMove(Button button)
    {
        var move = PlayerUnit.character.Moves[]
            yield return dialogBox.TypeDialog($"{PlayerUnit.character._base.name} used {move.Base.GetName()}");
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

     /*       b1.onClick.AddListener(PerformPlayerMove());
            b2.onClick.AddListener(PerformPlayerMove());
            b3.onClick.AddListener(PerformPlayerMove());
            b4.onClick.AddListener(PerformPlayerMove());
     */
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
