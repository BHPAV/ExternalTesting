using System.Collections;
using Bespoke.Items.Hull.Mounts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Bespoke.Agent
{
    public class BrainBox : MonoBehaviour
    {
        [SerializeField] private Actor actor;
        [SerializeField] private bool attach = false;
        [SerializeField] private float range = 5f; // Range to search for mounts
        [SerializeField] private float speed = 1f; // Speed to move towards the mount
        [SerializeField] private float attachingDuration = 5f; // Time allowed for attaching

        [SerializeField] private BrainBoxState state = BrainBoxState.Unattached;

        // Update is called once per frame
        private void Update()
        {
            switch (state)
            {
                case BrainBoxState.Idle:
                    // Handle idle state
                    break;
                case BrainBoxState.Attached:
                    // Handle attached state
                    break;
                case BrainBoxState.Unattached:
                    // If unattached and should attach, find mount
                    if (attach == true)
                    {
                        FindMount();
                    }
                    break;
                case BrainBoxState.Attaching:
                    // Handle attaching state (e.g., move towards mount)
                    break;
            }
        }

        private void FindMount()
        {
            BoxMount closestMount = null;
            float closestDistance = range;

            // Perform a sphere cast to find all mounts within range
            Collider[] colliders = Physics.OverlapSphere(transform.position, range);

            foreach (Collider hitCollider in colliders)
            {
                BoxMount mount = hitCollider.GetComponentInChildren<BoxMount>();
                if (mount != null)
                {
                    float distance = Vector3.Distance(transform.position, mount.transform.position);
                    if (distance < closestDistance)
                    {
                        closestMount = mount;
                        closestDistance = distance;
                    }
                }
            }

            // If a mount is found within range, move towards it
            if (closestMount != null)
            {
                state = BrainBoxState.Attaching;
                StartCoroutine(AttachingCoroutine(closestMount));
            }
            else
            {
                Debug.Log("No Mounts Found");
                // You may set the state to Idle or another state here
            }
        }


        private IEnumerator AttachingCoroutine(Mount closestMount)
        {
            float startTime = Time.time;

            while (state == BrainBoxState.Attaching)
            {
                // Move towards the mount
                transform.position = Vector3.MoveTowards(transform.position, closestMount.transform.position, speed * Time.deltaTime);

                // Check if close enough to attach
                if (Vector3.Distance(transform.position, closestMount.transform.position) < 0.1f)
                {
                    closestMount.MountActor(actor);
                    state = BrainBoxState.Attached;
                    yield break;
                }

                // Check if attaching duration has elapsed
                if (Time.time - startTime > attachingDuration)
                {
                    Debug.Log("Attaching timed out");
                    state = BrainBoxState.Unattached; // Or another state
                    yield break;
                }

                yield return null;
            }
        }
    }

    [System.Serializable]
    public enum BrainBoxState
    {
        Idle,
        Attached,
        Unattached,
        Attaching
    }
}
