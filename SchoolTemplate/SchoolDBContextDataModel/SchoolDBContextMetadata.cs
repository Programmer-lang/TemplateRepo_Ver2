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
			        }
		        public static void BuildMetadata(MetadataBuilder<Teacher> builder) {
			builder.DisplayName(SchoolDBContextResources.Teacher);
						builder.Property(x => x.TeacherID).DisplayName(SchoolDBContextResources.Teacher_TeacherID);
						builder.Property(x => x.TeacherName).DisplayName(SchoolDBContextResources.Teacher_TeacherName);
						builder.Property(x => x.School).DisplayName(SchoolDBContextResources.Teacher_School);
			        }
		        public static void BuildMetadata(MetadataBuilder<School> builder) {
			builder.DisplayName(SchoolDBContextResources.School);
						builder.Property(x => x.SchoolID).DisplayName(SchoolDBContextResources.School_SchoolID);
						builder.Property(x => x.SchoolName).DisplayName(SchoolDBContextResources.School_SchoolName);
						builder.Property(x => x.Director).DisplayName(SchoolDBContextResources.School_Director);
			        }
		    }
}