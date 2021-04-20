using UnityEngine;

public class Player_Buttons : MonoBehaviour
{
    [SerializeField] private Transform objectChecker;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Dialogue_Box theDialogueBox;

    private bool isTalking;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D interactable = Physics2D.OverlapCircle(objectChecker.position, 0.3f, interactableLayer);
            if (interactable != null && !isTalking) {
                interactable.GetComponent<NPC_Info>().Interact();
                isTalking = true;
            }
            else
            {
                if (!theDialogueBox.NextDialoguePart())
                {
                    isTalking = false;
                }
            }
        }
    }
}
