namespace MyDictionaryServices.Core.Commands
{
    public interface ICommandBus
    {
        CommandResult Send<TCommand>(TCommand command) where TCommand : ICommand;

        void ApplyChanges();
        CommandResult GetDelayedCommandResult();
    }
}