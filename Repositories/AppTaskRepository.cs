using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class AppTaskRepository : IAppTaskRepository
    {
        private readonly CrmDbContext crmDbContext;

        public AppTaskRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<AppTask> CreateTaskAppAsync(AppTask appTask)
        {
            await crmDbContext.AppTasks.AddAsync(appTask);
            await crmDbContext.SaveChangesAsync();
            return appTask;
        }

        public async Task<AppTask> DeleteTaskAppAsync(int id)
        {
            var deleteModel = await crmDbContext.AppTasks.FirstOrDefaultAsync(x => x.AppTaskId == id);
            if (deleteModel != null)
            {
                crmDbContext.Remove(deleteModel);
                await crmDbContext.SaveChangesAsync();
            }

            return deleteModel;
        }

        public async Task<List<AppTask>> GetAppTaskAsync()
        {
            return await crmDbContext.AppTasks.ToListAsync();
        }

        public async Task<AppTask> GetAppTaskByIdAsync(int id)
        {
            return await crmDbContext.AppTasks.FirstOrDefaultAsync(x => x.AppTaskId == id);
        }

        public async Task<AppTask> UpdateTaskAppAsync(int id, AppTask appTask)
        {
            var updateModel = await crmDbContext.AppTasks.FirstOrDefaultAsync(x => x.AppTaskId == id);
            if (updateModel == null)
            {
                return null;
            }
            await crmDbContext.SaveChangesAsync();
            return updateModel;
        }
    }
}