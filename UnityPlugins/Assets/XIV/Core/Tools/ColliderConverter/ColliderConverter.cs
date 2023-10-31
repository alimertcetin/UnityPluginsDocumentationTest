#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace XIV.Core.Tools.ColliderConverter
{
    public static class ColliderConverter
    {
        static Rigidbody2DParams[] rigidbody2DBuffer = new Rigidbody2DParams[16];
        static BoxCollider2DParams[] boxCollider2DBuffer = new BoxCollider2DParams[16];
        static CapsuleCollider2DParams[] capsuleCollider2DBuffer = new CapsuleCollider2DParams[16];
        static CircleColliderParams[] circleCollider2DBuffer = new CircleColliderParams[16];
        static int rigidbody2DBufferIndex;
        static int boxCollider2DBufferIndex;
        static int capsuleCollider2DBufferIndex;
        static int circleCollider2DBufferIndex;
        
        
        public struct Rigidbody2DParams
        {
            public float mass;
            public float drag;
            public float angularDrag;
            public float gravityScale;
            public bool isKinematic;
            public RigidbodyInterpolation interpolation;
            public CollisionDetectionMode collisionDetectionMode;
        }
        
        public struct BoxCollider2DParams
        {
            public Vector3 size;
            public Vector3 center;
            public bool isTrigger;
        }
        
        public struct CapsuleCollider2DParams
        {
            public float radius;
            public float height;
            public Vector3 center;
            public CapsuleDirection2D direction;
            public bool isTrigger;
        }
        
        public struct CircleColliderParams
        {
            public float radius;
            public Vector3 center;
            public bool isTrigger;
        }

        static void Write_RigidbodyArray(Rigidbody2DParams @params)
        {
            if (rigidbody2DBufferIndex >= rigidbody2DBuffer.Length) rigidbody2DBufferIndex = 0;
            rigidbody2DBuffer[rigidbody2DBufferIndex] = @params;
            rigidbody2DBufferIndex++;
        }
        static void Write_BoxColliderArray(BoxCollider2DParams @params)
        {
            if (boxCollider2DBufferIndex >= boxCollider2DBuffer.Length) boxCollider2DBufferIndex = 0;
            boxCollider2DBuffer[boxCollider2DBufferIndex] = @params;
            boxCollider2DBufferIndex++;
        }
        static void Write_CapsuleColliderArray(CapsuleCollider2DParams @params)
        {
            if (capsuleCollider2DBufferIndex >= capsuleCollider2DBuffer.Length) capsuleCollider2DBufferIndex = 0;
            capsuleCollider2DBuffer[capsuleCollider2DBufferIndex] = @params;
            capsuleCollider2DBufferIndex++;
        }
        static void Write_CircleColliderArray(CircleColliderParams @params)
        {
            if (circleCollider2DBufferIndex >= circleCollider2DBuffer.Length) circleCollider2DBufferIndex = 0;
            circleCollider2DBuffer[circleCollider2DBufferIndex] = @params;
            circleCollider2DBufferIndex++;
        }
        
        public static Rigidbody2DParams ConvertRigidbody(Rigidbody rigidbody)
        {
            Rigidbody2DParams params2D;
            params2D.mass = rigidbody.mass;
            params2D.drag = rigidbody.drag;
            params2D.angularDrag = rigidbody.angularDrag;
            params2D.gravityScale = rigidbody.useGravity ? 1 : 0;
            params2D.isKinematic = rigidbody.isKinematic;
            params2D.interpolation = rigidbody.interpolation;
            params2D.collisionDetectionMode = rigidbody.collisionDetectionMode;
            Write_RigidbodyArray(params2D);
            
            return params2D;
        }
        
        public static Rigidbody2DParams ConvertRigidbody(Rigidbody2D rigidbody2D)
        {
            Rigidbody2DParams params2D;
            params2D.mass = rigidbody2D.mass;
            params2D.drag = rigidbody2D.drag;
            params2D.angularDrag = rigidbody2D.angularDrag;
            params2D.gravityScale = rigidbody2D.gravityScale;
            params2D.isKinematic = rigidbody2D.isKinematic;
            params2D.interpolation = (RigidbodyInterpolation)(int)rigidbody2D.interpolation;
            params2D.collisionDetectionMode = (CollisionDetectionMode)(int)rigidbody2D.collisionDetectionMode;
            Write_RigidbodyArray(params2D);
            
            return params2D;
        }
        
        public static BoxCollider2DParams ConvertBoxCollider(BoxCollider boxCollider)
        {
            BoxCollider2DParams params2D;
            params2D.size = boxCollider.size;
            params2D.center = boxCollider.center;
            params2D.isTrigger = boxCollider.isTrigger;
            Write_BoxColliderArray(params2D);

            return params2D;
        }
        
        public static BoxCollider2DParams ConvertBoxCollider(BoxCollider2D boxCollider2D)
        {
            BoxCollider2DParams params2D;
            params2D.size = boxCollider2D.size;
            params2D.center = boxCollider2D.offset;
            params2D.isTrigger = boxCollider2D.isTrigger;
            Write_BoxColliderArray(params2D);

            return params2D;
        }
        
        public static CapsuleCollider2DParams ConvertCapsuleCollider(CapsuleCollider capsuleCollider)
        {
            CapsuleCollider2DParams params2D;
            params2D.radius = capsuleCollider.radius;
            params2D.height = capsuleCollider.height;
            params2D.center = capsuleCollider.center;
            params2D.direction = (CapsuleDirection2D)capsuleCollider.direction;
            params2D.isTrigger = capsuleCollider.isTrigger;
            Write_CapsuleColliderArray(params2D);

            return params2D;
        }
        
        public static CapsuleCollider2DParams ConvertCapsuleCollider(CapsuleCollider2D capsuleCollider2D)
        {
            CapsuleCollider2DParams params2D;
            var size = capsuleCollider2D.size;
            params2D.radius = size.x / 2f;
            params2D.height = size.y;
            params2D.center = capsuleCollider2D.offset;
            params2D.direction = capsuleCollider2D.direction;
            params2D.isTrigger = capsuleCollider2D.isTrigger;
            Write_CapsuleColliderArray(params2D);

            return params2D;
        }

        public static CircleColliderParams ConvertCircleCollider(CircleCollider2D circleCollider)
        {
            CircleColliderParams params3D;
            params3D.radius = circleCollider.radius;
            params3D.center = circleCollider.offset;
            params3D.isTrigger = circleCollider.isTrigger;
            Write_CircleColliderArray(params3D);

            return params3D;
        }

        public static CircleColliderParams ConvertCircleCollider(SphereCollider sphereCollider)
        {
            CircleColliderParams params3D;
            params3D.radius = sphereCollider.radius;
            params3D.center = sphereCollider.center;
            params3D.isTrigger = sphereCollider.isTrigger;
            Write_CircleColliderArray(params3D);

            return params3D;
        }
        
        
        
        
        public static void SetRigidbodyProperties(Rigidbody2D rigidbody, Rigidbody2DParams params2D)
        {
            rigidbody.mass = params2D.mass;
            rigidbody.drag = params2D.drag;
            rigidbody.angularDrag = params2D.angularDrag;
            rigidbody.gravityScale = params2D.gravityScale;
            rigidbody.isKinematic = params2D.isKinematic;
            rigidbody.interpolation = (RigidbodyInterpolation2D)(int)params2D.interpolation;
            rigidbody.collisionDetectionMode = (CollisionDetectionMode2D)(int)params2D.collisionDetectionMode;
        }
        
        public static void SetRigidbodyProperties(Rigidbody rigidbody, Rigidbody2DParams params2D)
        {
            rigidbody.mass = params2D.mass;
            rigidbody.drag = params2D.drag;
            rigidbody.angularDrag = params2D.angularDrag;
            rigidbody.useGravity = params2D.gravityScale > 0;
            rigidbody.isKinematic = params2D.isKinematic;
            rigidbody.interpolation = params2D.interpolation;
            rigidbody.collisionDetectionMode = params2D.collisionDetectionMode;
        }
        
        public static void SetCapsuleColliderProperties(CapsuleCollider2D capsuleCollider, CapsuleCollider2DParams params2D)
        {
            capsuleCollider.size = new Vector2(params2D.radius * 2, params2D.height);
            capsuleCollider.offset = params2D.center;
            capsuleCollider.direction = params2D.direction;
            capsuleCollider.isTrigger = params2D.isTrigger;
        }
        
        public static void SetCapsuleColliderProperties(CapsuleCollider capsuleCollider, CapsuleCollider2DParams params2D)
        {
            capsuleCollider.height = params2D.height;
            capsuleCollider.radius = params2D.radius;
            capsuleCollider.center = params2D.center;
            capsuleCollider.direction = (int)params2D.direction;
            capsuleCollider.isTrigger = params2D.isTrigger;
        }
        
        public static void SetCircleColliderProperties(CircleCollider2D circleCollider, CircleColliderParams params2D)
        {
            circleCollider.radius = params2D.radius;
            circleCollider.offset = params2D.center;
            circleCollider.isTrigger = params2D.isTrigger;
        }
        
        public static void SetCircleColliderProperties(SphereCollider sphereCollider, CircleColliderParams params2D)
        {
            sphereCollider.radius = params2D.radius;
            sphereCollider.center = params2D.center;
            sphereCollider.isTrigger = params2D.isTrigger;
        }
        
        public static void SetBoxColliderProperties(BoxCollider2D boxCollider, BoxCollider2DParams params2D)
        {
            boxCollider.size = params2D.size;
            boxCollider.offset = params2D.center;
            boxCollider.isTrigger = params2D.isTrigger;
        }
        
        public static void SetBoxColliderProperties(BoxCollider boxCollider, BoxCollider2DParams params2D)
        {
            boxCollider.size = params2D.size;
            boxCollider.center = params2D.center;
            boxCollider.isTrigger = params2D.isTrigger;
        }
        

        static bool UseUndo()
        {
#if UNITY_EDITOR
            return Application.isPlaying == false;
#else
            return false;
#endif
        }

        public static void DestroyImmediate(Object obj)
        {
#if UNITY_EDITOR
            if (UseUndo()) Undo.DestroyObjectImmediate(obj);
            else Object.DestroyImmediate(obj);
#else
            Object.DestroyImmediate(obj);
#endif
        }

        public static T AddComponent<T>(GameObject gameObject) where T : Component
        {
#if UNITY_EDITOR
            return UseUndo() ? Undo.AddComponent<T>(gameObject) : gameObject.AddComponent<T>();
#else
            return gameObject.AddComponent<T>();
#endif
        }
        
        
        
        public static void ConvertCollidersTo2D(GameObject gameObject)
        {
            // Get all collider components on the GameObject
            Collider[] colliders = gameObject.GetComponents<Collider>();

            // Iterate over the collider components
            for (int i = 0; i < colliders.Length; i++)
            {
                // Get the current collider
                Collider collider = colliders[i];
                
                // Check if the GameObject has a Rigidbody component
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();
                bool hasRigidbody = rigidbody != null;
                
                Rigidbody2DParams rbParams = new Rigidbody2DParams();
                if (hasRigidbody)
                {
                    // Convert the Rigidbody to a Rigidbody2D
                    rbParams = ConvertRigidbody(rigidbody);
                    DestroyImmediate(rigidbody);
                }

                // Check the type of the collider
                if (collider is CapsuleCollider capsuleCollider)
                {
                    // Convert the CapsuleCollider to a CapsuleCollider2D
                    CapsuleCollider2DParams capsuleCollider2D = ConvertCapsuleCollider(capsuleCollider);
                    DestroyImmediate(capsuleCollider);
                    var collider2d = AddComponent<CapsuleCollider2D>(gameObject);
                    SetCapsuleColliderProperties(collider2d, capsuleCollider2D);
                }
                else if (collider is SphereCollider sphereCollider)
                {
                    // Convert the SphereCollider to a CircleCollider2D
                    CircleColliderParams circleCollider2D = ConvertCircleCollider(sphereCollider);
                    DestroyImmediate(sphereCollider);
                    var collider2d = AddComponent<CircleCollider2D>(gameObject);
                    SetCircleColliderProperties(collider2d, circleCollider2D);
                }
                else if (collider is BoxCollider boxCollider)
                {
                    // Convert the BoxCollider to a BoxCollider2D
                    BoxCollider2DParams boxCollider2D = ConvertBoxCollider(boxCollider);
                    DestroyImmediate(boxCollider);
                    var collider2d = AddComponent<BoxCollider2D>(gameObject);
                    SetBoxColliderProperties(collider2d, boxCollider2D);
                    
                    
                }

                if (hasRigidbody)
                {
                    var rb2d = AddComponent<Rigidbody2D>(gameObject);
                    SetRigidbodyProperties(rb2d, rbParams);
                }
            }
            
        }
        
        public static void ConvertCollidersTo3D(GameObject gameObject)
        {
            // Get all collider components on the GameObject
            Collider2D[] colliders2D = gameObject.GetComponents<Collider2D>();

            // Iterate over the collider components
            for (int i = 0; i < colliders2D.Length; i++)
            {
                // Get the current collider
                Collider2D collider2D = colliders2D[i];
                
                // Check if the GameObject has a Rigidbody component
                Rigidbody2D rigidbody = collider2D.GetComponent<Rigidbody2D>();
                bool hasRigidbody = rigidbody != null;
                
                Rigidbody2DParams rbParams = new Rigidbody2DParams();
                if (hasRigidbody)
                {
                    // Convert the Rigidbody to a Rigidbody2D
                    rbParams = ConvertRigidbody(rigidbody);
                    DestroyImmediate(rigidbody);
                }

                // Check the type of the collider
                if (collider2D is CapsuleCollider2D capsuleCollider2D)
                {
                    // Convert the CapsuleCollider2D to a CapsuleCollider
                    CapsuleCollider2DParams capsuleCollider = ConvertCapsuleCollider(capsuleCollider2D);
                    DestroyImmediate(capsuleCollider2D);
                    var collider = AddComponent<CapsuleCollider>(gameObject);
                    SetCapsuleColliderProperties(collider, capsuleCollider);
                }
                else if (collider2D is CircleCollider2D circleCollider2D)
                {
                    // Convert the CircleCollider2D to a SphereCollider
                    CircleColliderParams sphereCollider = ConvertCircleCollider(circleCollider2D);
                    DestroyImmediate(circleCollider2D);
                    var collider = AddComponent<SphereCollider>(gameObject);
                    SetCircleColliderProperties(collider, sphereCollider);
                }
                else if (collider2D is BoxCollider2D boxCollider2D)
                {
                    // Convert the BoxCollider2D to a BoxCollider
                    BoxCollider2DParams boxCollider = ConvertBoxCollider(boxCollider2D);
                    DestroyImmediate(boxCollider2D);
                    var collider = AddComponent<BoxCollider>(gameObject);
                    SetBoxColliderProperties(collider, boxCollider);
                }
                

                if (hasRigidbody)
                {
                    var rb = AddComponent<Rigidbody>(gameObject);
                    SetRigidbodyProperties(rb, rbParams);
                }
                
            }
        }
        
        public static void ConvertCollidersTo3D_Recursive(GameObject gameObject)
        {
            // Convert the colliders on the current GameObject to 3D
            ConvertCollidersTo3D(gameObject);

            // Get all child GameObjects of the current GameObject
            Transform transform = gameObject.transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                // Convert the colliders on the child GameObject to 3D
                GameObject child = transform.GetChild(i).gameObject;
                ConvertCollidersTo3D_Recursive(child);
            }
        }
        
        public static void ConvertCollidersTo2D_Recursive(GameObject gameObject)
        {
            // Convert the colliders on the current GameObject to 3D
            ConvertCollidersTo2D(gameObject);

            // Get all child GameObjects of the current GameObject
            Transform transform = gameObject.transform;
            for (int i = 0; i < transform.childCount; i++)
            {
                // Convert the colliders on the child GameObject to 3D
                GameObject child = transform.GetChild(i).gameObject;
                ConvertCollidersTo2D_Recursive(child);
            }
        }
        
    }
}