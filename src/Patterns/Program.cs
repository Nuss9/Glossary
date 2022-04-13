using Patterns.Models;

Console.WriteLine("Start example Mediator pattern");
Console.WriteLine("");

ConcreteMediator mediator = new();
ConcreteColleague1 colleague1 = new(mediator);
ConcreteColleague2 colleague2 = new(mediator);

mediator.Colleague1 = colleague1;
mediator.Colleague2 = colleague2;

colleague1.Send("How are you?");
colleague2.Send("Fine, thanks");

Console.WriteLine("");
Console.WriteLine("Finish example Mediator pattern");

Console.ReadKey();
