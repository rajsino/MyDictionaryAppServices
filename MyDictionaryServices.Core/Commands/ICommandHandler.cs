namespace MyDictionaryServices.Core.Commands
{
    public interface ICommandHandler { }

    public interface ICommandHandler<in TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        CommandHandlerResult Handle(TCommand command);
    }
}