using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementModel.EntityModels;

namespace UserManagementInterface
{
    public interface IRolePermissionRepository
    {
        Task<IQueryable<RolePermission>> GetAll();
        Task<RolePermission> GetRolePermissionById(int id);
        Task<RolePermission> GetRolePermissionByRoleName(string roleName);
        Task<RolePermission> Save(RolePermission rolePermission);
        Task<RolePermission> Update(RolePermission rolePermission);
        Task<RolePermission> Delete(int id);
    }
}
