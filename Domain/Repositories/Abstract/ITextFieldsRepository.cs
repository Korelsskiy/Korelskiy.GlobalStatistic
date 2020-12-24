using Korelskiy.GlobalStatistic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.GlobalStatistic.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();
        TextField GetTextFieldById(Guid Id);
        TextField GetTextFieldByCodeWord(string codeWord);
        void SaveTextFields(TextField entity);
        void DeleteTextField(Guid id);
    }
}
