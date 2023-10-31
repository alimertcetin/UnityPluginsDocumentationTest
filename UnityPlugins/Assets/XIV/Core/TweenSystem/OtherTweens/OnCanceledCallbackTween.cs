using System;

namespace XIV.Core.TweenSystem.OtherTweens
{
    internal sealed class OnCanceledCallbackTween : CallbackTween
    {
        Action action;

        public OnCanceledCallbackTween Set(Action action)
        {
            this.action = action;
            return this;
        }
        
        public override void Complete() { }
        public override void Cancel() => action.Invoke();
    }
    
    internal sealed class OnCanceledCallbackTween<T> : CallbackTween
    {
        Action<T> action;
        T value;
        
        public OnCanceledCallbackTween<T> Set(Action<T> action, T value)
        {
            this.action = action;
            this.value = value;
            return this;
        }
        
        public override void Complete() => action.Invoke(value);
        public override void Cancel() { }
    }
}