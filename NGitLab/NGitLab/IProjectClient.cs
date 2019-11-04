using System.Collections.Generic;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab {
    public interface IProjectClient {
        IEnumerable<Project> Accessible();
        IEnumerable<Project> Owned();
        IEnumerable<Project> Membership();
        IEnumerable<Project> Starred();
        IEnumerable<Project> Forks(int id);
        Project Get(int id);
        Task<Project> GetAsync(int id);
        Project Get(string namespacedpath);
        Task<Project> GetAsync(string namespacedpath);
        Project Create(ProjectCreate project);
        bool Delete(int id);
        Project Star(int id);
    }
}