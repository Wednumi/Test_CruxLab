using Validation.Models;

namespace Validation
{
    public class Application
    {
        private static string s_filePath = "Passwords.txt";

        public void Run()
        {
            if(CheckFileExistence() is false)
            {
                return;
            }

            var lines = RetrieveLines();

            var requests = ParseRequests(lines);

            var validPasswordsCount = Validate(requests);

            Console.WriteLine($"Valid passwords: {validPasswordsCount}");
            Console.WriteLine($"Invalid passwords: {requests.Count() - validPasswordsCount}");
            Console.WriteLine($"Did not recognize lines: {lines.Count() - requests.Count()}");
        }

        private bool CheckFileExistence()
        {
            var exists = File.Exists(s_filePath);
            if (exists is false)
            {
                Console.WriteLine("File was not find");
            }
            return exists;
        }

        private List<string> RetrieveLines()
        {
            var stringRows = File.ReadAllLines(s_filePath);

            return stringRows.Where(r => r != string.Empty)
                .Select(r => r.Trim())
                .ToList();
        }

        private List<ValidationRequest> ParseRequests(List<string> lines)
        {
            var validationRows = new List<ValidationRequest>();

            foreach (var row in lines)
            {
                try
                {
                    validationRows.Add(ValidationRequest.Parse(row));
                }
                catch
                { }
            }

            return validationRows;
        }

        private int Validate(List<ValidationRequest> validationRows)
        {
            var validRows = 0;
            validationRows.ForEach(row =>
            {
                if (Validator.IsValid(row))
                {
                    validRows++;
                }
            });
            return validRows;
        }
    }
}
