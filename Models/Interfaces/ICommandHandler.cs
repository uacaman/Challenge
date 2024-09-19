namespace Core.Interfaces
{
    /// <summary>
    /// Defines a generic interface for handling commands.
    /// </summary>
    /// <typeparam name="TIn">The type of the command that will be executed.</typeparam>
    /// <typeparam name="TOut">The return type after the command is executed.</typeparam>
    public interface ICommandHandler<TIn, TOut>
    {
        /// <summary>
        /// Executes the specified command and returns a result.
        /// </summary>
        /// <param name="command">The command object containing input data needed for execution.</param>
        /// <returns>A task that represents the result of the command execution.</returns>
        Task<TOut> Execute(TIn command);
    }
}