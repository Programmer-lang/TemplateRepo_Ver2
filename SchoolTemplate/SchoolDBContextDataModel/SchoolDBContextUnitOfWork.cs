using DataModel;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTemplate.SchoolDBContextDataModel {

    /// <summary>
    /// A SchoolDBContextUnitOfWork instance that represents the run-time implementation of the ISchoolDBContextUnitOfWork interface.
    /// </summary>
    public class SchoolDBContextUnitOfWork : DbUnitOfWork<SchoolDBContext>, ISchoolDBContextUnitOfWork {

        public SchoolDBContextUnitOfWork(Func<SchoolDBContext> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Course, decimal> ISchoolDBContextUnitOfWork.Courses {
            get { return GetRepository(x => x.Set<Course>(), (Course x) => x.CourseID); }
        }

        IRepository<Student, decimal> ISchoolDBContextUnitOfWork.Students {
            get { return GetRepository(x => x.Set<Student>(), (Student x) => x.StudentID); }
        }

        IRepository<Teacher, decimal> ISchoolDBContextUnitOfWork.Teachers {
            get { return GetRepository(x => x.Set<Teacher>(), (Teacher x) => x.TeacherID); }
        }

        IRepository<School, decimal> ISchoolDBContextUnitOfWork.Schools {
            get { return GetRepository(x => x.Set<School>(), (School x) => x.SchoolID); }
        }
    }
}
