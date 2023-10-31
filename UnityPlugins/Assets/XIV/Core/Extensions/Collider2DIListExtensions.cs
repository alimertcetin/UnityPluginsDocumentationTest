using System.Collections.Generic;
using UnityEngine;

namespace XIV.Core.Extensions
{
    public static class Collider2DIListExtensions
    {
        /// <summary>
        /// Searches the closest <see cref="Collider2D"/> by calling <see cref="Collider2D.ClosestPoint(Vector2)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector2 position, int arrayLength, out Vector2 positionOnCollider) where T : Collider2D
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
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector2,int,out UnityEngine.Vector2)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector2 position, out Vector2 positionOnCollider) where T : Collider2D
        {
            int length = searchArray.Count;
            return GetClosestCollider(searchArray, position, length, out positionOnCollider);
        }

        /// <summary>
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector2,int,out UnityEngine.Vector2)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector2 position, int arrayLength) where T : Collider2D
        {
            return GetClosestCollider(searchArray, position, arrayLength, out _);
        }

        /// <summary>
        /// <inheritdoc cref="GetClosestCollider{T}(System.Collections.Generic.IList{T},UnityEngine.Vector2,int,out UnityEngine.Vector2)"/>
        /// </summary>
        public static T GetClosestCollider<T>(this IList<T> searchArray, Vector2 position) where T : Collider2D
        {
            int length = searchArray.Count;
            return GetClosestCollider(searchArray, position, length, out _);
        }
    }
}