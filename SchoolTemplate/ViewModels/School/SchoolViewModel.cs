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
using DevExpress.XtraReports.UI;
using System.ComponentModel;

namespace SchoolTemplate.ViewModels {

    /// <summary>
    /// Represents the single School object view model.
    /// </summary>
    public partial class SchoolViewModel : SingleObjectViewModel<School, decimal, ISchoolDBContextUnitOfWork> {


        public ObservableCollection<MenuIDHistory> MenuIDHistory { get; set; }

        public virtual SchoolDBContextModuleDescription ActiveModule { get; protected set; }
        
        public virtual SchoolDBContextModuleDescription SelectedModule { get; set; }

        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";
        public SchoolDBContextModuleDescription[] Modules {get; set;} = new SchoolDBContextModuleDescription[] {

              new SchoolDBContextModuleDescription(SchoolDBContextResources.TeacherPlural, "TeacherCollectionView", TablesGroup, null),
              new SchoolDBContextModuleDescription(SchoolDBContextResources.StudentPlural, "StudentCollectionView", TablesGroup, null),
              new SchoolDBContextModuleDescription(SchoolDBContextResources.DepartmentPlural, "DepartmentCollectionView", TablesGroup, null),
              new SchoolDBContextModuleDescription(SchoolDBContextResources.VehiculePlural, "VehiculeCollectionView", TablesGroup, null),



        };

        public void OnSelectedModuleChanged()
        {
            var service = this.GetService<IDocumentManagerService>();

            var OpenedDoc = service.Documents.Where(x => x.Title.ToString() == SelectedModule.ModuleTitle).FirstOrDefault();

            if(OpenedDoc != null)
            {
                OpenedDoc.Show();
                return;
            }

            switch (SelectedModule.ModuleTitle)
            {
                

                case "Teachers":
                    var doc = service.CreateDocument(SelectedModule.DocumentType, null, this);
                    doc.Title = "Teachers";
                    doc.Show();
                    break;
                case "Students":
                    var docstud = service.CreateDocument(SelectedModule.DocumentType, null, this);
                    docstud.Title = "Students";
                    docstud.Show();
                    break;

                case "Departments":
                    var docDep = service.CreateDocument(SelectedModule.DocumentType, null, this);
                    docDep.Title = "Departments";
                    docDep.Show();
                    break;

                case "Vehicules":
                    var docVeh = service.CreateDocument(SelectedModule.DocumentType, null, this);
                    docVeh.Title = "Vehicules";
                    docVeh.Show();
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

        public IEntitiesViewModel<Student> LookUpStudents
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (SchoolViewModel x) => x.LookUpStudents,
                    getRepositoryFunc: x => x.Students);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Departments for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Department> LookUpDepartments
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (SchoolViewModel x) => x.LookUpDepartments,
                    getRepositoryFunc: x => x.Departments);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Teachers for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Teacher> LookUpTeachers
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (SchoolViewModel x) => x.LookUpTeachers,
                    getRepositoryFunc: x => x.Teachers);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Vehicules for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Vehicule> LookUpVehicules
        {
            get
            {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (SchoolViewModel x) => x.LookUpVehicules,
                    getRepositoryFunc: x => x.Vehicules);
            }
        }


        /// <summary>
        /// The view model for the SchoolStudents detail collection.
        /// </summary>
        public CollectionViewModelBase<Student, Student, decimal, ISchoolDBContextUnitOfWork> SchoolStudentsDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (SchoolViewModel x) => x.SchoolStudentsDetails,
                    getRepositoryFunc: x => x.Students,
                    foreignKeyExpression: x => x.SchoolID,
                    navigationExpression: x => x.School);
            }
        }

        /// <summary>
        /// The view model for the SchoolDepartments detail collection.
        /// </summary>
        public CollectionViewModelBase<Department, Department, decimal, ISchoolDBContextUnitOfWork> SchoolDepartmentsDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (SchoolViewModel x) => x.SchoolDepartmentsDetails,
                    getRepositoryFunc: x => x.Departments,
                    foreignKeyExpression: x => x.SchoolID,
                    navigationExpression: x => x.School);
            }
        }

        /// <summary>
        /// The view model for the SchoolTeachers detail collection.
        /// </summary>
        public CollectionViewModelBase<Teacher, Teacher, decimal, ISchoolDBContextUnitOfWork> SchoolTeachersDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (SchoolViewModel x) => x.SchoolTeachersDetails,
                    getRepositoryFunc: x => x.Teachers,
                    foreignKeyExpression: x => x.SchoolID,
                    navigationExpression: x => x.School);
            }
        }

        /// <summary>
        /// The view model for the SchoolVehicules detail collection.
        /// </summary>
        public CollectionViewModelBase<Vehicule, Vehicule, decimal, ISchoolDBContextUnitOfWork> SchoolVehiculesDetails
        {
            get
            {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (SchoolViewModel x) => x.SchoolVehiculesDetails,
                    getRepositoryFunc: x => x.Vehicules,
                    foreignKeyExpression: x => x.SchoolID,
                    navigationExpression: x => x.School);
            }
        }


      public void Print()
        {
            try
            {

            
                using(XtraReport report1 = new XtraReport())
                {

                    report1.ShowRibbonPreviewDialog();
                }
            }
            catch (Exception ex)
            {

                MessageBoxService.Show(ex.Message);
            }
        }


        //public  void OnClosing(CancelEventArgs cancelEventArgs)
        //{

        //}

        //protected override void OnClosing(CloseAllMessage message)
        //{
        //    base.OnClosing(message);


        //}


        //public  class SchoolModuleDescription : ModuleDescription<SingleObjectViewModel<ISchoolType, decimal, IUnitOfWork>>
        //{
        //    public SchoolModuleDescription(string title, string documentType, string group, Func<SingleObjectViewModel<ISchoolType, decimal, IUnitOfWork>, object> peekCollectionViewModelFactory = null)
        //        : base(title, documentType, group, peekCollectionViewModelFactory)
        //    {
        //    }
        //}
    }
}
