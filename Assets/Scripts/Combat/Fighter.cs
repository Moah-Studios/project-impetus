using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Combat
{
    /// <summary>
    /// Dictates the Player's attack actions.
    /// </summary>
    public class Fighter : MonoBehaviour
    {
        // The range of the current weapon (unarmed)
        [SerializeField] float weaponRange = 2f;

        // The target to attack
        Transform target; 

        private void Update()
        {
            // Is the distance between our current position and the target's position less than the weapon range 
            // If so, then the target is in range.
            if (target == null) return;


            // If the there is a target and it is in range, move to it; otherwise stop. 
            if (target != null && !GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Stop();
            }
        }

        /// <summary>
        /// Determines if the target is in range.
        /// </summary>
        /// <returns>A boolean representing if the target is in range or not.</returns>
        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        /// <summary>
        /// Sets the target to the selected object.
        /// </summary>
        /// <param name="combatTarget">The object to attack.</param>
        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
        }

        /// <summary>
        /// Cancels the attack by setting the target to null.
        /// </summary>
        public void Cancel()
        {
            target = null;
        }
    }
}