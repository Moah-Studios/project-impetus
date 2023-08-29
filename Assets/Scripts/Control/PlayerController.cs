using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control 
{
    /// <summary>
    /// Coordinates the various actions the user can do with a Player. 
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        /// <summary>
        /// Determines if a Player can attack what they're hovering over and if so/the user clicks it, tells the Fighter to attack.
        /// </summary>
        /// <returns>A boolean representing if the attack was performed.</returns>
        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            // Check all of the hits to see if one is something that can be interacted with using combat.
            foreach (RaycastHit hit in hits)
            {
                // Get the CombatTarget (if there is one) on the object in this hit.
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();

                // If it isn't a target, skip to checking the next one. 
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                }
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// Determines if a Player can move to where they're hovering over and if so/the user clicks it, tellls the Mover to move there.
        /// </summary>
        /// <returns>A boolean representing if the movement was performed.</returns>
        private bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            // If the ray hit anything, move to that point. We know this isn't a target because the logic already checked. 
            if (hasHit)
            {
                if (Input.GetMouseButton(0)) {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            } 
            return false; 
        }

        /// <summary>
        /// Gets the mouse ray from where the user is hovering.
        /// </summary>
        /// <returns>A ray represnting where the user's cursor is in relation to the 3D world.</returns>
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}