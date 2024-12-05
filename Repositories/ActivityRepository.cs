using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Data;
using jwtauth.Models;
using Microsoft.EntityFrameworkCore;

namespace jwtauth.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly CrmDbContext crmDbContext;

        public ActivityRepository(CrmDbContext crmDbContext)
        {
            this.crmDbContext = crmDbContext;
        }
        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            await crmDbContext.Activities.AddAsync(activity);
            await crmDbContext.SaveChangesAsync();
            return activity;
        }

        public async Task<Activity> DeleteActivityByIdAsync(int id)
        {
            var deleteModel = await crmDbContext.Activities.FirstOrDefaultAsync(x => x.ActivityId == id);
            if (deleteModel != null)
            {
                crmDbContext.Remove(deleteModel);
                await crmDbContext.SaveChangesAsync();
            }

            return deleteModel;
        }

        public async Task<List<Activity>> GetActivityAsync()
        {
            return await crmDbContext.Activities.ToListAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
           return await crmDbContext.Activities.FirstOrDefaultAsync(x => x.ActivityId == id);
        }

        public async Task<Activity> UpdateActivityAsync(int id, Activity activity)
        {
            var updateModel = await crmDbContext.Activities.FirstOrDefaultAsync(x => x.ActivityId == id);
            if (updateModel == null)
            {
                return null;
            }
            await crmDbContext.SaveChangesAsync();
            return updateModel;
        }
    }
}