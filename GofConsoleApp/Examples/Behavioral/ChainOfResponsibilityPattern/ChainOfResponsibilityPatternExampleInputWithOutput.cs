﻿using GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern.InputWithOutput;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators;
using GofPatterns.Behavioral.ChainOfResponsibilityPattern.Orchestrators.Interfaces;

namespace GofConsoleApp.Examples.Behavioral.ChainOfResponsibilityPattern;

internal class ChainOfResponsibilityPatternExampleInputWithOutput : AbstractExample
{
    protected override bool Execute()
    {
        var orchestrator = new ResponsibilityChainOrchestrator<string, string>();

        orchestrator.Append(new ResponsibilityFoo(), "FooChain");
        orchestrator.Append(new ResponsibilityBar(), "BarChain");
        orchestrator.Append(new ResponsibilityFooBar(), "FooBarChain");

        SetBeforeHandling(orchestrator);

        Logger.Log("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >>> Bar
        // IsResponsible >>>>> Bar (Executes)
        var outputBar = orchestrator.Execute("Bar");
        Logger.Log(outputBar);


        Logger.Log("------------- START Orchestrator -------------");

        // Start with >>> Foo
        // IsNotResponsible >> Foo (Not Executes)
        // Invokes >> Bar
        // IsNotResponsible >> Bar (Not Executes)
        // Invokes >> FooBar
        // IsResponsible >>>>> FooBar (Executes)
        var outputFooBar = orchestrator.Execute("FooBar");
        Logger.Log(outputFooBar);

        return true;
    }

    private void SetBeforeHandling(IResponsibilityChainOrchestrator<string, string> orchestrator)
    {
        // Adding Before Handling Tasks
        orchestrator.ExecuteBefore = () =>
        {
            Logger.Log("---- Responsibility Chain ----");
            Logger.Log($"Name({orchestrator.CurrentChain!.Name}).");
        };

        orchestrator.ExecuteBeforeWithInput = input =>
        {
            Logger.Log($"Executing before with input '{input}'.");
        };
    }
}