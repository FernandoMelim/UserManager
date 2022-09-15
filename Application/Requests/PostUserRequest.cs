﻿using Application.Responses;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Requests;

public class PostUserRequest : IRequest<PostUserResponse>, IValidatableObject
{
    [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
    [StringLength(255, MinimumLength = 3)]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo 'Sobrenome' é obrigatório")]
    [StringLength(255, MinimumLength = 3)]
    [DataType(DataType.Text)]
    public string Surname { get; set; }

    [Required(ErrorMessage = "O campo 'E-mail' é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo 'E-mail' não é válido")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo 'Data de nascimento' é obrigatório")]
    [DataType(DataType.DateTime)]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "O campo 'Nível de escolaridade' é obrigatório")]
    public SchoolingLevelEnum? SchoolingLevel { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validationResult = new List<ValidationResult>();

        if (BirthDate.Value.Date > DateTime.Now.Date)
            validationResult.Add(new ValidationResult("Data de nascimento maior do que a data atual"));

        if(SchoolingLevel != null && (SchoolingLevel < 0 || (int)SchoolingLevel > 3))
            validationResult.Add(new ValidationResult("Adicione um nível escolar correto"));

        return validationResult;
    }
}

