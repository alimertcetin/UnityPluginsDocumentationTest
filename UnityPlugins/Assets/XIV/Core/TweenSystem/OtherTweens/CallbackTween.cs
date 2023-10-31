namespace XIV.Core.TweenSystem.OtherTweens
{
    public abstract class CallbackTween : ITween
    {
        public abstract void Complete();
        public abstract void Cancel();
        
        void ITween.Update(float deltaTime) { }
        
        bool ITween.IsDone() => true;
    }
}