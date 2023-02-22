namespace GPACalculator.API.Features.Subjects
{
    public class CreateSubjectValidation
    {
        private readonly ICreateSubjectRepository _createSubjectRepository;

        public CreateSubjectValidation(ICreateSubjectRepository repository)
        {
            _createSubjectRepository = repository;
        }

        public void Validate(CreateSubjectRequest? request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }
            if (request.Credits <= 0)
            {
                throw new ArgumentException(nameof(request.Credits));
            }

            var studentExists = _createSubjectRepository.Exists(request.Name);
            if (studentExists)
            {
                throw new ArgumentException(
                    $"Subject with name {request.Name} already exists.");
            }
        }
    }
}
