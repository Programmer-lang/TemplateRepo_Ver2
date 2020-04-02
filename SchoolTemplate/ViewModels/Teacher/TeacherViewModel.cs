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
    /// Represents the single Teacher object view model.
    /// </summary>
    public partial class TeacherViewModel : SingleObjectViewModel<Teacher, decimal, ISchoolDBContextUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TeacherViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TeacherViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TeacherViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TeacherViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TeacherViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TeacherViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Teachers, x => x.TeacherName) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Courses for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Course> LookUpCourses {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TeacherViewModel x) => x.LookUpCourses,
                    getRepositoryFunc: x => x.Courses);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Schools for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<School> LookUpSchools {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TeacherViewModel x) => x.LookUpSchools,
                    getRepositoryFunc: x => x.Schools);
            }
        }


        /// <summary>
        /// The view model for the TeacherCourses detail collection.
        /// </summary>
        public CollectionViewModelBase<Course, Course, decimal, ISchoolDBContextUnitOfWork> TeacherCoursesDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (TeacherViewModel x) => x.TeacherCoursesDetails,
                    getRepositoryFunc: x => x.Courses,
                    foreignKeyExpression: x => x.TeacherID,
                    navigationExpression: x => x.Teacher);
            }
        }

        public override bool CanSave()
        {
            return false;
        }

    }
}
