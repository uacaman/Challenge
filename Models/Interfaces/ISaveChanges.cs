namespace Core.Interfaces
{
    /// <summary>
    /// Represents a marker interface for command handlers that should trigger 
    /// a call to EF SaveChanges based on the outcome of the command execution.
    /// </summary>
    /// <remarks>
    ///
    /// Implementing this interface indicates that, if the command handler's 
    /// execution returns a successful result (implicitly converted true value), the EF SaveChanges 
    /// method should be invoked to persist changes to the database.
    ///
    /// This ensures that changes made during command handling are saved automatically, 
    /// improving consistency and  reducing the need for manual calls to save changes.
    /// </remarks>
    public interface ISaveChanges { }
}
