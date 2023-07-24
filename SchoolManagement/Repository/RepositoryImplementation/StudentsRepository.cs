using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data;
using SchoolManagement.Models;
using SchoolManagement.Repository.RepositoryInterface;

namespace SchoolManagement.Repository.RepositoryImplementation
{
    public class StudentsRepository:IStudentsRepository
    {
        private readonly SchoolManagementDbContext _schoolManagementDbContext;
        public StudentsRepository(SchoolManagementDbContext schoolManagementDbContext)
        {
            _schoolManagementDbContext = schoolManagementDbContext;
        }

        

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = new List<Student>();
            students = _schoolManagementDbContext.Students.ToList();
            return students;
        }

        public async Task<Boolean> CreateStudentAsync(Student model, CancellationToken cancellationToken = default)
        {
            var isCreate = false;
            var exist= await _schoolManagementDbContext.Students.AnyAsync(x=> x.Email.Trim().ToLower()== model.Email.Trim().ToLower());  
            if(cancellationToken.IsCancellationRequested==false)
            {
                if (!exist)
                {
                    await _schoolManagementDbContext.Students.AddAsync(model);
                    await _schoolManagementDbContext.SaveChangesAsync();
                    return isCreate = true;
                }
            }
            return isCreate;
        }
        public async Task<Student> GetStudentBy(int id)
        {
            var student = await _schoolManagementDbContext.Students.FindAsync(id);
            return student;
        }

        public async Task<Boolean>UpdateStudent(Student model, CancellationToken cancellation = default)
        {
            var isUpdate = false;
            var exists= await _schoolManagementDbContext.Students.AnyAsync(x=> x.Email.Trim().ToLower()==model.Email.Trim().ToLower()&& x.Std_Id==model.Std_Id);
            if(cancellation.IsCancellationRequested==false)
            {
                if(!exists)
                {
                    _schoolManagementDbContext.Students.Update(model);
                    await _schoolManagementDbContext.SaveChangesAsync();
                    return isUpdate = true;
                }
            }
            return isUpdate;
        }

        public async Task<Student>GetStudentById(int id)
        {
            var student = await _schoolManagementDbContext.Students.FindAsync(id);
            return student;
        }

        public async Task<Boolean> DeleteStudent(Student student, CancellationToken cancellationToken = default)
        {
            Boolean isDelete=false;
            var exists = await _schoolManagementDbContext.Students.Where(x => x.Std_Id == student.Std_Id).FirstOrDefaultAsync();
            if(cancellationToken.IsCancellationRequested==false)
            {
                
                    _schoolManagementDbContext.Students.Remove(student);
                    await _schoolManagementDbContext.SaveChangesAsync();
                    return isDelete=true;

                

            }
            return isDelete;
        }
    }
}
