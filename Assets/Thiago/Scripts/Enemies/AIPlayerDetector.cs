using System.Collections;
using UnityEngine;

namespace SVS.AI
{
    public class AIPlayerDetector : MonoBehaviour
    {
        [field: SerializeField]

        public bool playerDetected { get; private set; }


        public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.transform.position;

        [Header("OverlapBox parameters")]
        [SerializeField]
        private Transform detectorOrigin;
        public Vector2 detectorSize = Vector2.one;
        public Vector2 detectorOriginOffSet = Vector2.zero;

        public float detectionDelay = 0.3f;

        public LayerMask detectorLayerMask;

        [Header("Gizmo parameters")]
        public Color gizmoIdColor = Color.green;
        public Color gizmoDetectedColor = Color.red;
        public bool showGizmo = true;

        private GameObject target;

        public GameObject Target
        {
            get => target;
            private set
            {
                target = value;
                playerDetected = target != null;
            }
        }

        private void Start()
        {
            StartCoroutine(DetectionCoroutine());
        }

        IEnumerator DetectionCoroutine()
        {
            yield return new WaitForSeconds(detectionDelay);
            PerformDetection();
            StartCoroutine(DetectionCoroutine());

        }

        public void PerformDetection()
        {
            Collider2D collider = Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffSet, detectorSize, 0, detectorLayerMask);

            if(collider != null)
            {
                Target = collider.gameObject;
            }
            else
            {
                Target = null;
            }
        }

        private void OnDrawGizmos()
        {
            if(showGizmo && detectorOrigin != null)
            {
                Gizmos.color = gizmoIdColor;
                if (playerDetected)
                {
                    Gizmos.color = gizmoDetectedColor;
                    
                }
                Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffSet, detectorSize);
            }
        }

    }
}

