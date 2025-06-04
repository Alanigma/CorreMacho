using System;

public static class ObserverPause
{

    public static Action OnPause;

    public static void CallPause()
    {
        OnPause?.Invoke();
    }
    
}
