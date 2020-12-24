using Korelskiy.GlobalStatistic.Domain.Entities;
using Korelskiy.GlobalStatistic.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.GlobalStatistic.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid Id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public void SaveTextFields(TextField entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
