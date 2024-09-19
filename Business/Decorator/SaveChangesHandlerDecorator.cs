using Core;
using Core.Interfaces;
using Data;

namespace Business.Decorator
{
    /// <summary>
    /// Decorator command to call SaveChanges EF Core when needed 
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public class SaveChangesHandlerDecorator<TIn, TOut> : ICommandHandler<TIn, TOut>
    {
        private readonly ICommandHandler<TIn, TOut> _decorated;
        private readonly ChallengeDbContext _challengeContext;

        public SaveChangesHandlerDecorator(ICommandHandler<TIn, TOut> decorated, ChallengeDbContext challengeContext)
        {
            _decorated = decorated;
            _challengeContext = challengeContext;
        }

        /// <summary>
        /// When the result is of type Result and there is no Error, SaveChanges is called
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<TOut> Execute(TIn command)
        {
            var result = await _decorated.Execute(command);

            if (_decorated is ISaveChanges)
            {
                if (typeof(TOut).IsGenericType && typeof(TOut).GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var response = result as dynamic;
                    if (response == true)
                    {
                        _challengeContext.SaveChanges();
                    }
                }
            }

            return result;
        }
    }
}
