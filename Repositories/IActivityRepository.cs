using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtauth.Models;

namespace jwtauth.Repositories
{
    public interface IActivityRepository
    {
        Task<List<Activity>> GetActivityAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task<Activity> CreateActivityAsync(Activity activity);
        Task<Activity> UpdateActivityAsync(int id, Activity activity);
        Task<Activity> DeleteActivityByIdAsync(int id);

    }
}