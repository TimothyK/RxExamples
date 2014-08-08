using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExamplesWPF
{
    static class RxExtensions
    {


        //http://stackoverflow.com/questions/3211134/how-to-throttle-event-stream-using-rx
        public static IObservable<T> SampleResponsive<T>(this IObservable<T> source, TimeSpan delay)
        {
            return source.Publish(src =>
            {
                var fire = new Subject<T>();

                var whenCanFire = fire
                    .Select(u => new Unit())
                    .Delay(delay)
                    .StartWith(new Unit());

                var subscription = src
                    .CombineVeryLatest(whenCanFire, (x, flag) => x)
                    .Subscribe(fire);

                return fire.Finally(subscription.Dispose);
            });
        }


        private static IObservable<TResult> CombineVeryLatest <TLeft, TRight, TResult>(
            this IObservable<TLeft> leftSource,
            IObservable<TRight> rightSource, 
            Func<TLeft, TRight, TResult> selector)
        {
            return Observable.Defer(() =>
            {
                int l = -1, r = -1;
                return leftSource.Select(Tuple.Create<TLeft, int>)
                    .CombineLatest(rightSource.Select(Tuple.Create<TRight, int>), (x, y) => new { x, y })
                    .Where(t => t.x.Item2 != l && t.y.Item2 != r)
                    .Do(t => { l = t.x.Item2; r = t.y.Item2; })
                    .Select(t => selector(t.x.Item1, t.y.Item1));
            });
        }
    }
}
