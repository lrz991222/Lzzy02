using ELearning.DataAccess.Tools;
using ELearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.DataAccess
{
    /// <summary>
    /// 数据访问仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T : class, IEntityBase, new()
    {
        /// <summary>
        /// 持久化数据
        /// </summary>
        void Save();

        /// <summary>
        /// 无限制提取所有业务对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// 除了提取本身的对象数据集合外，还提取包含根据表达式提取关联的的对象的集合，
        /// </summary>
        /// <param name="includeProperties">需要直接提取关联类集合数据的表达式集合，通过逗号隔开</param>
        /// <returns></returns>
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 根据对象的ID提取具体的对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetSingle(Guid id);
        T GetSingle(Guid id, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// 根据 Lambda 表达式提取具体的对象，实际上是提取满足表达式限制的集合的第一个对象集合
        /// </summary>
        /// <param name="predicate">布尔条件的 Lambda 表达式</param>
        /// <returns></returns>
        T GetSingleBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据 Lambda 表达式提取对象集合
        /// </summary>
        /// <param name="predicate">布尔条件的 Lambda 表达式</param>
        /// <returns></returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 按照指定的属性进行分页，提取分页后的对象集合，在本框架中，通常使用 SortCode
        /// </summary>
        /// <typeparam name="TKey">分页所依赖的属性</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页对象的数量</param>
        /// <param name="keySelector">指定分页依赖属性的 Lambda 表达式</param>
        /// <returns></returns>
        PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);
        PaginatedList<T> PaginateDescend<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);
        PaginatedList<T> Paginate(Expression<Func<T, bool>> predicate, ref ListPageParameter pagePara);
        PaginatedList<T> Paginate(Expression<Func<T, bool>> predicate, ref ListPageParameter pagePara, params Expression<Func<T, object>>[] includeProperties);
        /// <summary>
        /// 按照指定的属性进行分页，提取分页后的对象的集合
        /// </summary>
        /// <typeparam name="TKey">分页所依赖的属性</typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页对象的数量</param>
        /// <param name="keySelector">指定分页依赖属性的 Lambda 表达式</param>
        /// <param name="predicate">对象集合过滤 Lambda 表达式</param>
        /// <param name="includeProperties">指定的扩展对象属性的表达式集合，通过逗号隔离</param>
        /// <returns></returns>
        PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        PaginatedList<T> PaginateDescend<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 添加对象到内存中的数据集中
        /// </summary>
        /// <param name="entity"></param>
        bool Add(T entity);

        /// <summary>
        /// 添加对象到内存中的数据集中，并直接持久化。
        /// </summary>
        /// <param name="entity"></param>
        bool AddAndSave(T entity);

        /// <summary>
        /// 编辑内存中对应的数据集的对象
        /// </summary>
        /// <param name="entity"></param>
        bool Edit(T entity);

        /// <summary>
        /// 编辑内存中对应的数据集的对象，并直接持久化。
        /// </summary>
        /// <param name="entity"></param>
        bool EditAndSave(T entity);

        /// <summary>
        /// 批量编辑并持久化处理的操作，下面参数说明以 Persons 为例
        /// </summary>
        /// <param name="predicate">过滤条件，例如：x=>x.Name=="张三"</param>
        /// <param name="newValueExpression">修改值：x2=> new Person {Name="李四"}</param>
        /// 实际例子：_Service.EditAndSaveBy(x => x.Name == "测试数据", x1 => new SystemWorkSection { Description="用于更改的编辑说明" });
        bool EditAndSaveBy(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> newValueExpression);

        /// <summary>
        /// 根据内存中对应的数据集是否存在，自动决定采取添加或者编辑方法处理传入的对象
        /// </summary>
        /// <param name="entity"></param>
        bool AddOrEdit(T entity);

        /// <summary>
        /// 根据内存中对应的数据集是否存在，自动决定采取添加或者编辑方法处理传入的对象，并直接持久化。
        /// </summary>
        /// <param name="entity"></param>
        bool AddOrEditAndSave(T entity);

        /// <summary>
        /// 删除内存中对应的数据集的对象。
        /// </summary>
        /// <param name="entity"></param>
        bool Delete(T entity);

        /// <summary>
        /// 删除内存中对应的数据集的对象，并直接持久化。
        /// </summary>
        /// <param name="entity"></param>
        bool DeleteAndSave(T entity);
        DeleteStatusModel DeleteAndSave(Guid id);
        /// <summary>
        /// 根据条件执行批量删除并持久化的操作
        /// </summary>
        /// <param name="predicate">条件表达式，例如：x=>x.Name=="abc"，满足的数据对象都将被删除</param>
        bool DeleteAndSaveBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据对象ID来执行删除，并根据所定义的删除依赖关系检查删除操作执行后的结果，返回相应的执行状态模型供前端应用使用
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relevanceOperations"></param>
        /// <returns></returns>
        DeleteStatus DeleteAndSave(Guid id, List<object> relevanceOperations);

        /// <summary>
        /// 根据对象 ID 判断在数据库中是否存在相应的对象数据记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool HasInstance(Guid id);

        /// <summary>
        /// 根据条件判断在数据库中是否存在相应的对象数据记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool HasInstance(Expression<Func<T, bool>> predicate);

        T1 GetSingleOther<T1>(Guid id) where T1 : class, IEntityBase, new();

        #region 异步方法定义
        Task<bool> SaveAsyn();
        Task<IQueryable<T>> GetAllAsyn();
        Task<IQueryable<T>> GetAllIncludingAsyn(params Expression<Func<T, object>>[] includeProperties);
        Task<IQueryable<T>> GetAllAsyn(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllIncludingAsyn(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetSingleAsyn(Guid id);
        Task<T> GetSingleAsyn(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsyn(Expression<Func<T, bool>> predicate);

        Task<IQueryable<T>> FindByAsyn(Expression<Func<T, bool>> predicate);
        Task<bool> HasInstanceAsyn(Guid id);
        Task<bool> HasInstanceAsyn(Expression<Func<T, bool>> predicate);

        Task<bool> AddOrEditAndSaveAsyn(T entity);

        Task<DeleteStatusModel> DeleteAndSaveAsyn(Guid id);

        Task<PaginatedList<T>> PaginateAsyn<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);

        Task<PaginatedList<T>> PaginateAsyn<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="sortProperty"></param>
        /// <param name="isDescens"></param>
        /// <param name="predicate"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        Task<PaginatedList<T>> PaginateAsyn<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> sortProperty, bool isDescens, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        #endregion
    }
}
