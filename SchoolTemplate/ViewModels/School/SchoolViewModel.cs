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
using SchoolTemplate.Localization;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the single School object view model.
    /// </summary>
    public partial class SchoolViewModel : SingleObjectViewModel<School, decimal, ISchoolDBContextUnitOfWork> {


      
        public virtual SchoolDBContextModuleDescription ActiveModule { get; protected set; }
        
        public virtual SchoolDBContextModuleDescription SelectedModule { get; set; }

        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";
        public SchoolDBContextModuleDescription[] Modules {get; set;} = new SchoolDBContextModuleDescription[] {
             new SchoolDBContextModuleDescription(SchoolDBContextResources.TeacherPlural, "TeacherCollectionView", TablesGroup, null),

            new SchoolDBContextModuleDescription(SchoolDBContextResources.CoursePlural, "CourseCollectionView", TablesGroup, null),
                new SchoolDBContextModuleDescription(SchoolDBContextResources.StudentPlural, "StudentCollectionView", TablesGroup, null),
               // new SchoolDBContextModuleDescription(SchoolDBContextResources.SchoolPlural, "SchoolCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Schools)),
            };

        public void OnSelectedModuleChanged()
        {
            var service = this.GetService<IDocumentManagerService>();

            switch (SelectedModule.ModuleTitle)
            {
               

                case "Teachers":
                    service.CreateDocument(SelectedModule.DocumentType, SchoolTeachersDetails,this);


            break;
                case "Course":
                    break;
                case "Student":
                    break;
            }
            
        }


/// <summary>
/// Creates a new instance of SchoolViewModel as a POCO view model.
/// </summary>
/// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
public static SchoolViewModel Create(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new SchoolViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the SchoolViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SchoolViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected SchoolViewModel(IUnitOfWorkFactory<ISchoolDBContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Schools, x => x.SchoolName) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Teachers for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Teacher> LookUpTeachers {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (SchoolViewModel x) => x.LookUpTeachers,
                    getRepositoryFunc: x => x.Teachers);
            }
        }


        /// <summary>
        /// The view model for the SchoolTeachers detail collection.
        /// </summary>
        public CollectionViewModelBase<Teacher, Teacher, decimal, ISchoolDBContextUnitOfWork> SchoolTeachersDetails {
            get { 
                return GetDetailsCollectionViewModel(
                    propertyExpression: (SchoolViewModel x) => x.SchoolTeachersDetails,
                    getRepositoryFunc: x => x.Teachers,
                    foreignKeyExpression: x => x.SchoolID,
                    navigationExpression: x => x.School);
            }
        }

        //public  class SchoolModuleDescription : ModuleDescription<SingleObjectViewModel<ISchoolType, decimal, IUnitOfWork>>
        //{
        //    public SchoolModuleDescription(string title, string documentType, string group, Func<SingleObjectViewModel<ISchoolType, decimal, IUnitOfWork>, object> peekCollectionViewModelFactory = null)
        //        : base(title, documentType, group, peekCollectionViewModelFactory)
        //    {
        //    }
        //}
    }
}
