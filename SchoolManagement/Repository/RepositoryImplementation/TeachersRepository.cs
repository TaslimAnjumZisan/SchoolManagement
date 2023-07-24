using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryInterface;

namespace SchoolManagement.Repository.RepositoryImplementation
{
    public class TeachersRepository:ITeachersRepository
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;
        public TeachersRepository(SchoolManagementDbContext schoolManagementDbContext)
        {
            _schoolManagementDbContext = schoolManagementDbContext;
        }
        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            List<Teacher> teachers=new List<Teacher>();
            teachers= _schoolManagementDbContext.Teachers.ToList();
            return teachers;
        }

        public async Task<Boolean> CreateTeacherAsync(Teacher model, CancellationToken cancellationToken = default)
        {
            var isCreate = false;
            var exists = await _schoolManagementDbContext.Teachers.AnyAsync(x=> x.Email.Trim().ToLower()==model.Email.Trim().ToLower());
            if(cancellationToken.IsCancellationRequested==false)
            {
                if(!exists)
                {
                    await _schoolManagementDbContext.Teachers.AddAsync(model);
                    _schoolManagementDbContext.SaveChangesAsync();
                    return isCreate = true;

                }
            }
            return isCreate;
        }

        

        
    }
}
