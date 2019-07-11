using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ELearning.DataAccess.Tools
{
    public class DeleteStatus
    {
        public List<DeleteStatusModel> SDSM = new List<DeleteStatusModel>();

        public void Initialize(bool oStatus, string oMessage)
        {
            var item = new DeleteStatusModel();
            item.DeleteSatus = oStatus;
            item.Message = oMessage;
            SDSM.Add(item);
        }
    }

    public class DeleteStatusModel
    {
        public bool DeleteSatus { get; set; }
        public string Message { get; set; }
    }

    public class StatusMessageForDeleteOperation<T> where T : class
    {

        public string OperationMessage { get; set; }
        public bool CanDelete { get; set; }

        public StatusMessageForDeleteOperation(string message, List<T> collecton)
        {
            OperationMessage = message;
            CanDelete = collecton.Count <= 0;
        }

        public StatusMessageForDeleteOperation(string message, Expression<Func<T, bool>> expression)
        {
            OperationMessage = message;
            CanDelete = _SetCanDelete(expression);
        }

        private bool _SetCanDelete(Expression<Func<T, bool>> expression)
        {
            //var dbContext = new EntityDbContext(DbContextOptions < EntityDbContext > options);
            //var dbSet = dbContext.Set<T>();
            //if (dbSet.Where(expression).ToList().Any())
            //    return false;
            //else
            return true;
        }

        public StatusMessageForDeleteOperation(string message, int itemCount)
        {
            OperationMessage = message;
            CanDelete = itemCount <= 0;
        }
    }

}
