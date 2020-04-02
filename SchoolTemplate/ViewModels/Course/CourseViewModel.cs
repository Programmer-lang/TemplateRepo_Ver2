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
    /// Represents the single Course object view model.
    /// </summary>
    public partial class CourseViewModel : SingleObjectViewModel<Course, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of CourseViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CourseViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new CourseViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the CourseViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CourseViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CourseViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Courses, x => x.CourseName) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                StudentsDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.Students, x => x.StudentCourses.Where(y=> y.CourseID == x.CourseID).Select(w=> w.Student).ToList());
        }
        /// <summary>
        /// The view model that contains a look-up collection of Teachers for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Teacher> LookUpTeachers {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (CourseViewModel x) => x.LookUpTeachers,
                    getRepositoryFunc: x => x.Teachers);
            }
        }

        public virtual AddRemoveDetailEntitiesViewModel<Course, Decimal, Student, Decimal, ISchoolDBContextUnitOfWork> StudentsDetailEntities { get; protected set; }



        public override bool CanSave()
        {
            return false;
        }


    }
}
