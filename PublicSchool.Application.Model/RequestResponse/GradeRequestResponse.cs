namespace PublicSchool.Application.Model.RequestResponse
{
    public class GradeRequestResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int SchoolId { get; set; }

        public string SchoolName { get; set; }
    }
}