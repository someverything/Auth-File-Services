﻿using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleServices
    {
        Task<IResult> CreateRoleAsync(string roleName);
        Task<IResult> DeleteRoleAsync(string id);
        Task<IResult> UpdateRoleAsync(string roleId, string roleName);
        IDataResult<List<GetRoleDTO>> GetAllRoles();
    }
}
