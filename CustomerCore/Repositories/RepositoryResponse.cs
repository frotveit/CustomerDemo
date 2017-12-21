

namespace CustomerCore.Repositories
{
    public class RepositoryResponse
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

        public RepositoryResponse(bool succeeded)
        {
            Succeeded = succeeded;
        }

        public static RepositoryResponse Success()
        {
            return new RepositoryResponse(true)
            {
            };
        }

        public static RepositoryResponse Failed(string errorMessage)
        {
            return new RepositoryResponse(false)
            {
                ErrorMessage = errorMessage
            };
        }
    }
}
