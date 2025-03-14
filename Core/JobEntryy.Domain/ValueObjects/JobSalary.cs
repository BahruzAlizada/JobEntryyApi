
namespace JobEntryy.Domain.ValueObjects
{       
    public record JobSalary
    {
        public bool IsSalaryHidden { get; private set; }
        public int Salary { get; private set; }
        public string JobSalaryString => IsSalaryHidden ? "Maaş müsahibə prosesində təyin olunacaqdır" : $"{Salary} Azn";

        private JobSalary(bool isSalaryHidden, int salary)
        {
            IsSalaryHidden = isSalaryHidden;
            Salary = isSalaryHidden ? 0 : salary;
        }

        public static JobSalary Create(bool isSalaryHidden, int salary)
        {
            return new JobSalary(isSalaryHidden, salary);
        }


    }
}
