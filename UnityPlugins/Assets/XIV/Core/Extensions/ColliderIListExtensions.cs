using System.Collections.Generic;
using UnityEngine;

namespace XIV.Core.Extensions
{
    public static class ColliderIListExtensions
    {
        /// <summary>
        /// Searches the closest <see cref="Collider"/> by calling <see cref="Collider.ClosestPoint(Vector3)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector3 position, int arrayLength, out Vector3 positionOnCollider) where T : Collider
        {
            T closestCollider = default;
            positionOnCollider = default;
            float distance = float.MaxValue;
            for (int i = 0; i < arrayLength; i++)
            {
                positionOnCollider = searchArray[i].ClosestPoint(position);
                var diff = positionOnCollider - position;
                var tempDistance = diff.x * diff.x + diff.y * diff.y;
                if (tempDistance < distance)
                {
                    distance = tempDistance;
                    closestCollider = searchArray[i];
                }
            }

            return closestCollider;
        }

        /// <summary>
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector3,int,out UnityEngine.Vector3)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector3 position, out Vector3 positionOnCollider) where T : Collider
        {
            int length = searchArray.Count;
            return GetClosestCollider(searchArray, position, length, out positionOnCollider);
        }

        /// <summary>
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector3,int,out UnityEngine.Vector3)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector3 position, int arrayLength) where T : Collider
        {
            return GetClosestCollider(searchArray, position, arrayLength, out _);
        }

        /// <summary>
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector3,int,out UnityEngine.Vector3)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector3 position) where T : Collider
        {
            int length = searchArray.Count;
            return GetClosestCollider(searchArray, position, length, out _);
        }
    }
}