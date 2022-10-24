using UnityEngine;

namespace Week08
{
    public class QuaternionVsEuler : MonoBehaviour
    {
        public Transform startRot, endRot;
        public bool useQuaternion = false;
        [Range(1, 30)]
        public float duration = 3.0f;

        void Update()
        {
            float t = Time.time % duration / duration;

            //Using Quaternions in the interpolation results in the mesh taking the shortest rotation angle to the end rotation. 
            Quaternion qFrom = startRot.rotation;
            Quaternion qTo = endRot.rotation;
            Quaternion qt = Quaternion.Slerp(qFrom, qTo, t);

            Vector3 eFrom = startRot.eulerAngles;
            Vector3 eTo = endRot.eulerAngles;
            Vector3 et = Vector3.Lerp(eFrom, eTo, t);

            transform.rotation = useQuaternion ? qt : Quaternion.Euler(et);
        }
    }
}