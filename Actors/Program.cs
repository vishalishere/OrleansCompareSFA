﻿namespace Actors
{
    using System;
    using System.Threading;
    using Microsoft.ServiceFabric.Actors.Runtime;

    static class Program
    {
        static void Main()
        {
            try
            {
                ActorRuntime.RegisterActorAsync<FriendlyActor>(
                   (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

                ActorRuntime.RegisterActorAsync<PetActor>(
                   (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

                ActorRuntime.RegisterActorAsync<CalculatorActor>(
                   (context, actorType) => new ActorService(context, actorType)).GetAwaiter().GetResult();

                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
