using DataModel;
using DevExpress.Mvvm.DataAnnotations;
using SchoolTemplate.Localization;

namespace SchoolTemplate.SchoolDBContextDataModel {

    public class SchoolDBContextMetadataProvider {
		        public static void BuildMetadata(MetadataBuilder<Course> builder) {
			builder.DisplayName(SchoolDBContextResources.Course);
						builder.Property(x => x.CourseID).DisplayName(SchoolDBContextResources.Course_CourseID);
						builder.Property(x => x.CourseName).DisplayName(SchoolDBContextResources.Course_CourseName);
						builder.Property(x => x.Teacher).DisplayName(SchoolDBContextResources.Course_Teacher);
			        }
		        public static void BuildMetadata(MetadataBuilder<Student> builder) {
			builder.DisplayName(SchoolDBContextResources.Student);
						builder.Property(x => x.StudentID).DisplayName(SchoolDBContextResources.Student_StudentID);
						builder.Property(x => x.StudentName).DisplayName(SchoolDBContextResources.Student_StudentName);
						builder.Property(x => x.School).DisplayName(SchoolDBContextResources.Student_School);
			        }
		        public static void BuildMetadata(MetadataBuilder<School> builder) {
			builder.DisplayName(SchoolDBContextResources.School);
						builder.Property(x => x.SchoolID).DisplayName(SchoolDBContextResources.School_SchoolID);
						builder.Property(x => x.SchoolName).DisplayName(SchoolDBContextResources.School_SchoolName);
						builder.Property(x => x.Director).DisplayName(SchoolDBContextResources.School_Director);
			        }
		        public static void BuildMetadata(MetadataBuilder<Department> builder) {
			builder.DisplayName(SchoolDBContextResources.Department);
						builder.Property(x => x.DepartmentID).DisplayName(SchoolDBContextResources.Department_DepartmentID);
						builder.Property(x => x.DepartmentName).DisplayName(SchoolDBContextResources.Department_DepartmentName);
						builder.Property(x => x.Description).DisplayName(SchoolDBContextResources.Department_Description);
						builder.Property(x => x.School).DisplayName(SchoolDBContextResources.Department_School);
			        }
		        public static void BuildMetadata(MetadataBuilder<Teacher> builder) {
			builder.DisplayName(SchoolDBContextResources.Teacher);
						builder.Property(x => x.TeacherID).DisplayName(SchoolDBContextResources.Teacher_TeacherID);
						builder.Property(x => x.TeacherName).DisplayName(SchoolDBContextResources.Teacher_TeacherName);
						builder.Property(x => x.School).DisplayName(SchoolDBContextResources.Teacher_School);
			        }
		        public static void BuildMetadata(MetadataBuilder<Vehicule> builder) {
			builder.DisplayName(SchoolDBContextResources.Vehicule);
						builder.Property(x => x.VehiculeID).DisplayName(SchoolDBContextResources.Vehicule_VehiculeID);
						builder.Property(x => x.VehiculeName).DisplayName(SchoolDBContextResources.Vehicule_VehiculeName);
						builder.Property(x => x.VehiculeType).DisplayName(SchoolDBContextResources.Vehicule_VehiculeType);
						builder.Property(x => x.DriverName).DisplayName(SchoolDBContextResources.Vehicule_DriverName);
						builder.Property(x => x.School).DisplayName(SchoolDBContextResources.Vehicule_School);
			        }
		    }
}