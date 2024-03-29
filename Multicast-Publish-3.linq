<Query Kind="Statements">
  <Reference>&lt;ApplicationData&gt;\LINQPad\Samples\Programming Reactive Extensions and LINQ\System.Reactive.dll</Reference>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
</Query>

/* What Gives? 
 *
 * Remember, that Publish returns a ConnectableObservable; this allows you to
 * control exactly how many times the side-effects happen (usually you only want
 * one!).
 *
 * Let's connect to the Source (i.e. input), by calling Connect().
 */

var sched = new TestScheduler();

var input = sched.CreateHotObservable(
    sched.OnNextAt(200, 1),
    sched.OnNextAt(300, 10),
    sched.OnNextAt(400, 100),
    sched.OnCompletedAt<int>(1100.0));

var published = input.Do(x => Console.WriteLine("Effects!")).Publish();
published.Connect();

published.Subscribe(Console.WriteLine);
published.Subscribe(Console.WriteLine);

sched.Start();

