using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.ViewModel;
using SchoolTemplate.Localization;using SchoolTemplate.SchoolDBContextDataModel;

namespace SchoolTemplate.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the SchoolDBContext data model.
    /// </summary>
    public partial class SchoolDBContextViewModel : DocumentsViewModel<SchoolDBContextModuleDescription, ISchoolDBContextUnitOfWork> {

		const string TablesGroup = "Tables";

		const string ViewsGroup = "Views";
	
        /// <summary>
        /// Creates a new instance of SchoolDBContextViewModel as a POCO view model.
        /// </summary>
        public static SchoolDBContextViewModel Create() {
            return ViewModelSource.Create(() => new SchoolDBContextViewModel());
        }

		        static SchoolDBContextViewModel() {
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata<SchoolDBContextMetadataProvider>();
        }
        /// <summary>
        /// Initializes a new instance of the SchoolDBContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SchoolDBContextViewModel type without the POCO proxy factory.
        /// </summary>
        protected SchoolDBContextViewModel()
		    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        }

        protected override SchoolDBContextModuleDescription[] CreateModules() {
			return new SchoolDBContextModuleDescription[] {
                new SchoolDBContextModuleDescription(SchoolDBContextResources.CoursePlural, "CourseCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Courses)),
                new SchoolDBContextModuleDescription(SchoolDBContextResources.StudentPlural, "StudentCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Students)),
                new SchoolDBContextModuleDescription(SchoolDBContextResources.TeacherPlural, "TeacherCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Teachers)),
                new SchoolDBContextModuleDescription(SchoolDBContextResources.SchoolPlural, "SchoolCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Schools)),
            };
        }
                	}

    public partial class SchoolDBContextModuleDescription : ModuleDescription<SchoolDBContextModuleDescription> {
        public SchoolDBContextModuleDescription(string title, string documentType, string group, Func<SchoolDBContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}