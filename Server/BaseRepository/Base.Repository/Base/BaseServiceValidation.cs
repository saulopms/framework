using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Base.Repository {

    public abstract class BaseServiceValidation {
        public IList<ValidationFailure> Error { get; set; }

        protected bool ExecutarValidacao<TV, TE> (TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class {
            var validator = validacao.Validate (entidade);
            this.Error = validator.Errors;

            if (validator.IsValid) {
                return true;
            }

            return false;
        }

        protected string GetError () {
            return this.Error[0].ErrorMessage;
        }

    }
}