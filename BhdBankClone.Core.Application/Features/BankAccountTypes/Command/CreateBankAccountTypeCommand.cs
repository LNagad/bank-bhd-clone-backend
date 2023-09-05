using AutoMapper;
using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccountTypes.Command
{
  public class CreateBankAccountTypeCommand : IRequest<Response<BankAccountTypeDTO>>
  {
    public required string Description { get; set; }
  }

  public class CreateBankAccountTypeCommandHandler : IRequestHandler<CreateBankAccountTypeCommand, Response<BankAccountTypeDTO>>
  {
    private readonly IGenericRepository<AccountType> _repository;
    private readonly IValidator<CreateBankAccountTypeCommand> _validator;
    private readonly IMapper _mapper;

    public CreateBankAccountTypeCommandHandler(IGenericRepository<AccountType> repository, IValidator<CreateBankAccountTypeCommand> validator, IMapper mapper)
    {
      _repository = repository;
      _validator = validator;
      _mapper = mapper;
    }

    public async Task<Response<BankAccountTypeDTO>> Handle(CreateBankAccountTypeCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<BankAccountTypeDTO>() { Data = await CreateBankAccountTypeAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<BankAccountTypeDTO> CreateBankAccountTypeAsync(CreateBankAccountTypeCommand req)
    {
      // TODO: Add validation for product type description so that it is unique
      var accountType = await _repository.AddAsync(_mapper.Map<AccountType>(req));

      return _mapper.Map<BankAccountTypeDTO>(accountType);
    }
  }
}
