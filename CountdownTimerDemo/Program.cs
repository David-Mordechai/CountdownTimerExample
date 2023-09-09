using CountdownTimerDemo;

ICountdownTimer countdownTimer = new CountdownTimer
{
    OnCountdownFinished = () => { Console.WriteLine("Countdown finished..."); },
    OnStop = () => { Console.WriteLine("Countdown timer stopped");}
};

var restarted = false;
countdownTimer.OnTick = secondsRemaining =>
{
    Console.WriteLine(secondsRemaining.ToString(@"mm\:ss"));
    if (secondsRemaining.Seconds != 2) return;
    if (restarted) return;
    
    Console.WriteLine("Restarting the countdown timer to 5 seconds");
    countdownTimer.Start(TimeSpan.FromSeconds(5));
    restarted = true;
};

countdownTimer.Start(TimeSpan.FromSeconds(10));

Console.ReadKey();
countdownTimer.Stop();

Console.ReadKey();
