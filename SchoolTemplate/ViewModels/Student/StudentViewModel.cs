using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.SchoolDBContextDataModel;
using SchoolTemplate.Common;
using DataModel;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the single Student object view model.
    /// </summary>
    public partial class StudentViewModel : SingleObjectViewModel<Student, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of StudentViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static StudentViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new StudentViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the StudentViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the StudentViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected StudentViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Students, x => x.StudentName) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                CoursesDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.Courses, x => x.StudentCourses.Where(y => y.CourseID == x.StudentID).Select(w => w.Course).ToList());
        }

    public virtual AddRemoveDetailEntitiesViewModel<Student, Decimal, Course, Decimal, ISchoolDBContextUnitOfWork> CoursesDetailEntities { get; protected set; }


        public override bool CanSave()
        {
            return false;
        }

    }
}
