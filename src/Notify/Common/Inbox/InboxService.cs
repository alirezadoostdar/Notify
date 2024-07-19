namespace Notify.Common.Inbox
{
    public class InboxService(InboxDbContext dbContext)
    {
        private readonly InboxDbContext _dbContext = dbContext;

        public async Task AddAsync(InboxMessage inboxMessage, CancellationToken cancellationToken)
        {
            await _dbContext.InboxMessages.AddAsync(inboxMessage, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<bool> HasMessageAsync<TMessage>(TMessage message,CancellationToken cancellationToken = default)
            where TMessage : IntegrationMessage
        {
            return _dbContext.InboxMessages.AnyAsync(x=>x.MessageId == message.MessageId,cancellationToken);
        }

        public Task<List<InboxMessage>> GetUnProcessedMessageAsync(CancellationToken cancellationToken)
        {
            return _dbContext.InboxMessages
                             .Where(x => !x.Processed)
                             .OrderBy(x => x.CreatedOn)
                             .ToListAsync(cancellationToken);
        }

        public async Task ProcessMessageAsync(InboxMessage message,CancellationToken cancellationToken)
        {
            message.Process();
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
