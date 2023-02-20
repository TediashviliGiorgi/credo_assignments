namespace GPACalculator.API.Features.Students.RegisterStudent
{
    public class RegisterStudentValidation
    {
        private readonly IRegisterStudentRepository _registerStudentRepository;
        public RegisterStudentValidation(IRegisterStudentRepository registerStudentRepository)
        {
            _registerStudentRepository = registerStudentRepository;
        }

        public void Validate(RegisterStudentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.FirstName))
            {
                throw new ArgumentNullException(nameof(request.FirstName));
            }
            if (string.IsNullOrEmpty(request.LastName))
            {
                throw new ArgumentNullException(nameof(request.LastName));
            }
            if (string.IsNullOrEmpty(request.PersonalNumber))
            {
                throw new ArgumentNullException(nameof(request.PersonalNumber));
            }
            if (string.IsNullOrEmpty(request.Course))
            {
                throw new ArgumentNullException(nameof(request.Course));
            }

            var studentExists = _registerStudentRepository.ExistsWithPersonalNumber(request.PersonalNumber);
            if (studentExists)
            {
                throw new ArgumentException(
                    $"Student with private number {request.PersonalNumber} already exists.");
            }
        }
    }
}
