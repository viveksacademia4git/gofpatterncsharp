﻿using GofConsoleApp.Examples.Behavioral.CommandPattern.CommandRequests.Interfaces;
using GofPatterns.Behavioral.CommandPattern.Interfaces.Commands;

namespace GofConsoleApp.Examples.Behavioral.CommandPattern.Commands.Interfaces;

internal interface IFoodCommand : ICommand<IFoodCommandRequest> { }