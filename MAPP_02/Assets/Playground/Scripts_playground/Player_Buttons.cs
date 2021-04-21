using UnityEngine;

public class Player_Buttons : MonoBehaviour
{
    [SerializeField] private Transform objectChecker;
    [SerializeField] private LayerMask interactableLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D interactable = Physics2D.OverlapCircle(objectChecker.position, 0.3f, interactableLayer);
            if (interactable != null && !Game_Controller.IsGamePaused())
            {
                interactable.GetComponent<NPC_Info>().Interact();
                interactable.GetComponent<NPC_Movement>().TurnToPlayer(transform.position);
            }
            else
            {
                Game_Controller.GetDialogueBox().NextDialoguePart();
            }
        }

        if (!Game_Controller.IsGamePaused())
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject ql = Game_Controller.GetQuestLog().gameObject;
                if (!ql.activeInHierarchy)
                {
                    ql.SetActive(true);
                }
                else
                {
                    ql.SetActive(false);
                }
            }
        }
    }
}
