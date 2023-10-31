using System;

namespace XIV.Core.TweenSystem.OtherTweens
{
    internal sealed class OnCompleteCallbackTween : CallbackTween
    {
        Action action;

        public OnCompleteCallbackTween Set(Action action)
        {
            this.action = action;
            return this;
        }
        
        public override void Complete() => action.Invoke();
        public override void Cancel() { }
    }
    
    internal sealed class OnCompleteCallbackTween<T> : CallbackTween
    {
        Action<T> action;
        T value;
        
        public OnCompleteCallbackTween<T> Set(Action<T> action, T value)
        {
            this.action = action;
            this.value = value;
            return this;
        }
        
        public override void Complete() => action.Invoke(value);
        public override void Cancel() { }
    }
}