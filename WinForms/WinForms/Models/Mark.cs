using System.ComponentModel.DataAnnotations;

namespace WinForms.Models
{
    public class Mark : IComparable
    {
        [Key]
        public int Id { get; set; }
        private int value;
        public int Value
        {
            get => value;
            set
            {
                if (value < 1 || value > 100) throw new ArgumentException("Mark cannot be less then 1 and more then 100");
                this.value = value;
            }
        }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public Mark() { }
        public Mark(int value)
        {
            Value = value;
        }
        private void Method1()
        {

        }
        private void Method2()
        {

        }
        private void Method3()
        {

        }
        private void Method4()
        {

        }
        private void Method5()
        {

        }


        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            Mark otherMark = obj as Mark;
            if (otherMark != null)
            {
                return this.Value.CompareTo(otherMark.Value);
            }
            else
                throw new ArgumentException("Object is not a Mark");
        }
    }
}