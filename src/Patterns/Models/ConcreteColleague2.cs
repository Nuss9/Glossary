﻿using Patterns.Abstractions;

namespace Patterns.Models;

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator)
: base(mediator)
    {
    }
    public void Send(string message)
    {
        mediator.Send(message, this);
    }
    public void Notify(string message)
    {
        Console.WriteLine($"{nameof(ConcreteColleague2)} gets message: "
            + message);
    }
}
