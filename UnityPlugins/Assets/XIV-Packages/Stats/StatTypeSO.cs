using UnityEngine;
using XIV.DataTypes;

namespace XIV.Stats
{
    [CreateAssetMenu(menuName = "EnumSOs/StatTypeSO", fileName = "StatTypeSO", order = 0)]
    public class StatTypeSO : EnumSOBase
    {
        
#if UNITY_EDITOR
        protected override string GetName() => this.name;
#endif
        
    }
}