namespace Learning_Content_Models.Models
{
    public class StudyMaterialFile
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public int StudyMaterialId { get; set; }
        public virtual StudyMaterial StudyMaterial { get; set; }
    }
}
