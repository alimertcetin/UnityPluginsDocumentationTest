using XIV.Core.Utils;

namespace XIV.Core.TweenSystem.OtherTweens
{
    internal sealed class WaitTween : ITween
    {
        Timer timer;

        public WaitTween Set(float duration)
        {
            timer.Restart(duration);
            return this;
        }

        void ITween.Update(float deltaTime) => timer.Update(deltaTime);
        bool ITween.IsDone() => timer.IsDone;
        
        void ITween.Complete() { }
        void ITween.Cancel() { }
    }
}