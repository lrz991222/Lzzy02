using ELearning.DataAccess.Tools;
using ELearning.Entities;
using ELearning.ORM.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DataAccess
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
    {
        readonly SqlServerDbContext _EntitiesContext;

        public EntityRepository(SqlServerDbContext context) => _EntitiesContext = context;

        public virtual void Save()
        {
            try
            {
                _EntitiesContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // 获取错误信息集合
                var errorMessages = ex.Message;
                var itemErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " Error: ", itemErrorMessage);
                throw new DbUpdateException(exceptionMessage,ex);
            }
        }

        public virtual IQueryable<T> GetAll() => _EntitiesContext.Set<T>();

        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _EntitiesContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return query;
        }

        public virtual T GetSingle(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);

        public virtual T GetSingle(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> dbSet = _EntitiesContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    dbSet = dbSet.Include(includeProperty);
                }
            }

            var result = dbSet.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public virtual T GetSingleBy(Expression<Func<T, bool>> predicate) => _EntitiesContext.Set<T>().Where(predicate).FirstOrDefault(predicate);

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => _EntitiesContext.Set<T>().Where(predicate);

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector) => Paginate(pageIndex, pageSize, keySelector, null);

        public virtual PaginatedList<T> PaginateDescend<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector) => PaginateDescend(pageIndex, pageSize, keySelector, null);

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = GetAllIncluding(includeProperties).OrderBy(keySelector);
            query = (predicate == null) ? query : query.Where(predicate);
            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual PaginatedList<T> PaginateDescend<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = GetAllIncluding(includeProperties).OrderByDescending(keySelector);
            query = (predicate == null) ? query : query.Where(predicate);
            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual PaginatedList<T> Paginate(Expression<Func<T, bool>> predicate, ref ListPageParameter pagePara) => Paginate(predicate, ref pagePara, null);

        public virtual PaginatedList<T> Paginate(Expression<Func<T, bool>> predicate, ref ListPageParameter pagePara, params Expression<Func<T, object>>[] includeProperties)
        {
            var pageIndex = 1;
            var pageSize = 18;

            pageIndex =Int16.Parse(pagePara.PageIndex);
            pageSize = Int16.Parse(pagePara.PageSize);


            #region 根据属性名称确定排序的属性的 lambda 表达式 

            var sortPropertyName = pagePara.SortProperty;
            var target = Expression.Parameter(typeof(object));
            var type = typeof(T);
            var castTarget = Expression.Convert(target, type);
            var propertyArray = sortPropertyName.Split('.');
            var getPropertyValue = Expression.Property(castTarget, propertyArray[0]);
            for (var i = 0; i < propertyArray.Count(); i++)
            {
                if (i > 0)
                {
                    getPropertyValue = Expression.Property(getPropertyValue, propertyArray[i]);
                }
            }
            var sortExpession = Expression.Lambda<Func<T, object>>(getPropertyValue, target);

            #endregion

            PaginatedList<T> boCollection;
            if (pagePara.SortDesc.ToLower() == "default" || pagePara.SortDesc == "")
            {
                boCollection = Paginate(pageIndex, pageSize, sortExpession, predicate, includeProperties);
            }
            else
            {
                boCollection = PaginateDescend(pageIndex, pageSize, sortExpession, predicate, includeProperties);
            }

            pagePara.PageAmount = boCollection.TotalPageCount.ToString();
            pagePara.PageIndex = boCollection.PageIndex.ToString();
            pagePara.ObjectAmount = ((predicate == null)? GetAll(): GetAll().Where(predicate)).Count().ToString();

            return boCollection;
        }

        public virtual bool Add(T entity)
        {
            try
            {
                _EntitiesContext.Set<T>().Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool AddAndSave(T entity)
        {
            try
            {
                Add(entity);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Edit(T entity)
        {
            try
            {
                _EntitiesContext.Set<T>().Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool EditAndSave(T entity)
        {
            try
            {
                Edit(entity);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool EditAndSaveBy(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> newValueExpression)
        {
            try
            {
                var dbSet = _EntitiesContext.Set<T>();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool AddOrEdit(T entity)
        {
            try
            {
                var p = GetAll().FirstOrDefault(x => x.Id == entity.Id);
                if (p == null)
                {
                    Add(entity);
                }
                else
                {
                    Edit(entity);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool AddOrEditAndSave(T entity)
        {
            try
            {
                AddOrEdit(entity);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Delete(T entity)
        {
            try
            {
                _EntitiesContext.Set<T>().Remove(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool DeleteAndSave(T entity)
        {
            try
            {
                Delete(entity);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual DeleteStatusModel DeleteAndSave(Guid id)
        {
            var result = new DeleteStatusModel() { DeleteSatus = true, Message = "删除操作成功！" };
            var hasIstance = HasInstance(id);
            if (!hasIstance)
            {
                result.DeleteSatus = false;
                result.Message = "不存在所指定的数据，无法执行删除操作！";
            }
            else
            {
                var tobeDeleteItem = GetSingle(id);
                try
                {
                    Delete(tobeDeleteItem);
                    Save();
                }
                catch (DbUpdateException ex)
                {
                    result.DeleteSatus = false;
                    result.Message = "错误信息："+ ex.Message; // 删除操作出现意外，主要原因是关联数据没有处理干净活者是其他原因。
                }
            }
            return result;
        }

        public virtual bool DeleteAndSaveBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var dbSet = _EntitiesContext.Set<T>();
                var toBeDeleteItems = dbSet.Where(predicate);//.Delete();
                foreach (var item in toBeDeleteItems)
                {
                    dbSet.Remove(item);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public virtual DeleteStatus DeleteAndSave(Guid id, List<object> relevanceOperations)
        {
            var deleteStatus = new DeleteStatus();
            var returnStatus = true;
            var returnMessage = "";
            var bo = GetSingle(id);

            if (bo == null)
            {
                returnStatus = false;
                returnMessage = "你所删除的数据不存在，如果确定不是数据逻辑错误原因，请将本情况报告系统管理人员。";
                deleteStatus.Initialize(returnStatus, returnMessage);
            }
            else
            {
                #region 处理关联关系

                var i = 0;
                foreach (var deleteOperationObject in relevanceOperations)
                {
                    var deleteProperty = deleteOperationObject.GetType().GetProperties().Where(pn => pn.Name == "CanDelete").FirstOrDefault();
                    var itCanDelete = (bool) deleteProperty.GetValue(deleteOperationObject);

                    var messageProperty = deleteOperationObject.GetType().GetProperties().Where(pn => pn.Name == "OperationMessage").FirstOrDefault();
                    var messageValue = messageProperty.GetValue(deleteOperationObject) as string;

                    if (!itCanDelete)
                    {
                        returnStatus = false;
                        returnMessage += (i++) + "、" + messageValue + "。\n";
                    }
                }

                #endregion

                if (returnStatus)
                {
                    try
                    {
                        DeleteAndSave(bo);
                        deleteStatus.Initialize(returnStatus, returnMessage);
                    }
                    catch (DbUpdateException)
                    {
                        returnStatus = false;
                        returnMessage = "无法删除所选数据，其信息正被使用，如果确定不是数据逻辑错误原因，请将本情况报告系统管理人员。";
                        deleteStatus.Initialize(returnStatus, returnMessage);
                    }
                }
                else
                {
                    deleteStatus.Initialize(returnStatus, returnMessage);
                }
            }
            return deleteStatus;
        }

        public virtual bool HasInstance(Guid id)
        {
            var dbSet = _EntitiesContext.Set<T>();
            return dbSet.Any(x => x.Id == id);
        }

        public bool HasInstance(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _EntitiesContext.Set<T>();
            return dbSet.Any(predicate);
        }

        public virtual T1 GetSingleOther<T1>(Guid id) where T1 : class, IEntityBase, new()
        {
            var dbSet = _EntitiesContext.Set<T1>();
            return dbSet.Find(id);
        }


        #region 异步方法的具体实现
        public virtual async Task<bool> SaveAsyn()
        {
            await _EntitiesContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<IQueryable<T>> GetAllAsyn()
        {
            var dbSet = _EntitiesContext.Set<T>();
            var result = await dbSet.ToListAsync();
            return result.AsQueryable<T>();
        }

        public virtual async Task<IQueryable<T>> GetAllIncludingAsyn(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _EntitiesContext.Set<T>(); //.Include(includeProperties);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            var result = await query.ToListAsync();
            return result.AsQueryable();
        }

        public virtual async Task<IQueryable<T>> GetAllAsyn(Expression<Func<T, bool>> predicate)
        {
            var result = await _EntitiesContext.Set<T>().Where(predicate).ToListAsync();
            return result.AsQueryable();

        }

        public virtual async Task<IQueryable<T>> GetAllIncludingAsyn(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _EntitiesContext.Set<T>().Where(predicate);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            var result = await query.ToListAsync();
            return result.AsQueryable();
        }

        public virtual async Task<T> GetSingleAsyn(Guid id)
        {
            var dbSet = _EntitiesContext.Set<T>();
            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public virtual async Task<T> GetSingleAsyn(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> dbSet = _EntitiesContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    dbSet = dbSet.Include(includeProperty);
                }
            }

            var result = await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public virtual async Task<T> GetSingleAsyn(Expression<Func<T, bool>> predicate)
        {
            var dbSet = _EntitiesContext.Set<T>();
            var result = await dbSet.FirstOrDefaultAsync(predicate);
            return result;
        }


        public virtual async Task<IQueryable<T>> FindByAsyn(Expression<Func<T, bool>> predicate)
        {
            var result= await _EntitiesContext.Set<T>().Where(predicate).ToListAsync();
            return result.AsQueryable();
        }

        public virtual async Task<bool> HasInstanceAsyn(Guid id) => await _EntitiesContext.Set<T>().AnyAsync(x => x.Id == id);

        public virtual async Task<bool> HasInstanceAsyn(Expression<Func<T, bool>> predicate) => await _EntitiesContext.Set<T>().AnyAsync(predicate);

        public virtual async Task<bool> AddOrEditAndSaveAsyn(T entity)
        {
            var dbSet = _EntitiesContext.Set<T>();
            var hasInstance = await dbSet.AnyAsync(x => x.Id == entity.Id);
            if (hasInstance)
                dbSet.Update(entity);
            else
                await dbSet.AddAsync(entity);
            try
            {
                await _EntitiesContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public virtual async Task<DeleteStatusModel> DeleteAndSaveAsyn(Guid id)
        {
            var result = new DeleteStatusModel() { DeleteSatus = true, Message = "删除操作成功！" };
            var hasIstance = await HasInstanceAsyn(id);
            if(!hasIstance)
            {
                result.DeleteSatus = false;
                result.Message = "不存在所指定的数据，无法执行删除操作！";
            }
            else
            {
                var tobeDeleteItem = await GetSingleAsyn(id);
                try
                {
                    _EntitiesContext.Set<T>().Remove(tobeDeleteItem);
                    _EntitiesContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    result.DeleteSatus = false;
                    result.Message = ex.Message;
                }
            }
            return result;
        }

        public virtual async Task<PaginatedList<T>> PaginateAsyn<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector)
        {
            var result = await PaginateAsyn(pageIndex, pageSize, keySelector, null);
            return result;
        }

        public virtual async Task<PaginatedList<T>> PaginateAsyn<TKey>(
            int pageIndex,
            int pageSize,
            Expression<Func<T, TKey>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await GetAllIncludingAsyn(includeProperties);
            query = query.OrderBy(keySelector);
            query = (predicate == null) ? query : query.Where(predicate);
            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public async Task<PaginatedList<T>> PaginateAsyn<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> sortProperty, bool isDescend, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await GetAllIncludingAsyn(includeProperties);

            query = (isDescend == true) ? query.OrderBy(sortProperty) : query.OrderByDescending(sortProperty);
            query = (predicate == null) ? query : query.Where(predicate);

            return query.ToPaginatedList(pageIndex, pageSize);

        }

        #endregion

    }
}
