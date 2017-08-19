using System.Collections.Generic;

namespace MyDictionaryServices.Core.Commands
{
    public interface ICommand
    {
        bool IsValid { get; }
        IEnumerable<string> ValidationErrorMessges { get; }

        void Validate();
    }
}