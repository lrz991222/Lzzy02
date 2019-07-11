namespace ELearning.UserAndRole
{
    /// <summary>
    /// 系统角色组类型，在这些类型中：
    ///   1. 适用于系统管理人员 的角色组只能创建一个，一旦创建，将不能被操作删除；
    ///   2. 适用于普通注册用户 的角色组只能创建一个，一旦创建，将不能被操作删除。
    /// </summary>
    public enum ApplicationRoleTypeEnum
    {
        适用于普通注册用户,
        适用于小编,
        适用于景区数据管理员,
        适用于社区数据管理员
    }
}