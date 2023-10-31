using UnityEngine;

namespace XIV_Packages.ScriptableObjects.Channels
{
    [CreateAssetMenu(menuName = MenuPaths.CHANNEL_BASE_MENU + nameof(TransformChannelSO))]
    public class TransformChannelSO : XIVChannelSO<Transform>
    {
        
    }
}