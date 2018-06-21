using UnityEngine;
using UnityEngine.Events;

namespace Threeyes.Extension
{
    public static class UnityExtension
    {

        #region String

        public static bool NotNullOrEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        #endregion

        #region Transform

        /// <summary>
        /// ForAll Child
        /// </summary>
        /// <param name="tf"></param>
        /// <param name="action"></param>
        /// <param name="includeSelf"></param>
        public static void ForEachChild(this Transform tf, UnityAction<Transform> action, bool includeSelf = true)
        {
            if (includeSelf)
                action(tf);

            foreach (Transform tfChild in tf.transform)
            {
                action(tfChild);
            }
        }

        public static void ForEachParent(this Transform tf, UnityAction<Transform> action, bool includeSelf = true)
        {
            Transform target = tf;
            if (includeSelf)
                action(tf);

            while (target.parent)
            {
                action(target.parent);
                target = target.parent;
            }
        }

        /// <summary>
        /// Recursive
        /// </summary>
        /// <param name="tf"></param>
        /// <param name="action"></param>
        /// <param name="includeSelf"></param>
        public static void Recursive(this Transform tf, UnityAction<Transform> action, bool includeSelf = true)
        {
            if (includeSelf)
                action(tf);

            foreach (Transform tfChild in tf.transform)
            {
                Recursive(tfChild, action);
            }
        }

        #endregion

        #region Component

        public static TReturn FindFirstComponentInParent<TReturn>(this Component comp, bool includeSelf = true)
    where TReturn : Component
        {
            TReturn tReturn = null;
            comp.transform.ForEachParent(
               (tf) =>
               {
                   if (!tReturn)
                       tReturn = tf.GetComponent<TReturn>();
               },
               includeSelf
               );
            return tReturn;
        }

        #endregion
    }
}