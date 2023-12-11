﻿using GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample;
using GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample.States;
using GofPattern.Behavioral.StatePattern.Interfaces;
using static GofConsoleApp.Examples.Behavioral.StatePattern.BulbExample.Enums.EnumStatePatternBulbExample;

namespace GofConsoleApp.Examples.Behavioral.StatePattern;

internal class StatePatternBulbExample : AbstractExample
{
    private readonly IState<BulbStateContext> on = new OnState();
    private readonly IState<BulbStateContext> off = new OffState();

    protected override bool Execute()
    {
        IStateContext<BulbStateContext> bulb = new BulbStateContext(off, Logger);

        Logger.Log($"Bulb is {bulb.State.Name} now.");

        do
        {
            var inputOption = AcceptInputEnum(Invalid, "instruction", Invalid);

            if (IsInvalidOrQuit(inputOption, Invalid, Quit, out var output))
                return output;

            if (bulb.State.Name.Equals(inputOption.ToString()))
            {
                Logger.Log($"Bulb already in {bulb.State.Name} state.");
                continue;
            }

            switch (inputOption)
            {
                case On:
                    bulb.SetState(on);
                    break;
                case Off:
                    bulb.SetState(off);
                    break;
            }

            bulb.Execute();

        } while (true);
    }
}