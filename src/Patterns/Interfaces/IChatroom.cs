namespace Patterns.Interfaces;

public interface IChatroom
{
    public void Send(string message, Colleague colleague);
}
