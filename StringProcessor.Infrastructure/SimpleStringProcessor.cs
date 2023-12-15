using StringProcessor.Domain;
using Buildingblock;
using ExternalStringLibrary;
using ClassLibrary2;

namespace StringProcessor.Infrastructure
{
    public class SimpleStringProcessor : IStringProcessor
    {
        public string Process(string input)
        {
            if (ValidateString.Validate(input))
            {
                return "Validation successful";
            }
            else 
            {
                if (Class2.Verify())
                {
                    ManipulateString manipulate = new ManipulateString();
                    input = manipulate.Manipulate(input);
                }
                return input;
            }
           
        }
    }
}
