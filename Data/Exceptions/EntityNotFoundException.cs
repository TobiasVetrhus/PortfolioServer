namespace PortfolioServer.Data.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityType, int entityId)
                : base($"Entity  '{entityType}' with ID  '{entityId}' not found")
        {
        }
    }
}