using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IAppTaskRepository
    {
        Task<List<AppTask>> GetAppTaskAsync();
        Task<AppTask> GetAppTaskByIdAsync(int id);
        Task<AppTask> CreateTaskAppAsync(AppTask appTask);
        Task<AppTask> UpdateTaskAppAsync(int id, AppTask appTask);
        Task<AppTask> DeleteTaskAppAsync(int id);

    }
}