using AutoMapper;
using Loja.Application.Contratos;
using Loja.Application.Dtos;
using Loja.Application.Service;
using Loja.Application.Validations;
using Loja.Domain.Entidades;
using Loja.Domain.Filters;
using Loja.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Application
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepositorio _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepositorio personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ICollection<PersonDto>>> GetAllAsync()
        {
            var get = await _personRepository.BuscarPessoa();
            return ResultService.OK<ICollection<PersonDto>>(_mapper.Map<ICollection<PersonDto>>(get));
        }

        public async Task<ResultService<PersonDto>> GetByIdAsync(int id)
        {
            var get = await _personRepository.BuscarPessoaById(id);
            if (get == null) return ResultService.Fail<PersonDto>("Pessoa Não Encontrada");
            return ResultService.OK(_mapper.Map<PersonDto>(get));
        }

        public async Task<ResultService<PersonDto>> CreateAsync(PersonDto person)
        {
            if (person == null)
                return ResultService.Fail<PersonDto>("Objeto deve Ser Informado");

            var result = new PersonDtoValidation().Validate(person);
            if (!result.IsValid) return ResultService.RequestError<PersonDto>("Problemas de Validade", result);

            var adicionar = _mapper.Map<Person>(person);
            var retorno = await _personRepository.CriarPessoa(adicionar);
            return ResultService.OK<PersonDto>(_mapper.Map<PersonDto>(retorno));
        }

        public async Task<ResultService> UpdateAsync(PersonDto person)
        {
            if (person == null) return ResultService.Fail("Pessoa deve ser Informada.");
            var validar = new PersonDtoValidation().Validate(person);
            if (validar.IsValid) return ResultService.RequestError("Problemas com a Validação dos Campos", validar);

            var update = await _personRepository.BuscarPessoaById(person.Id);
            if (update == null) return ResultService.Fail("Pessoa Não Encontrada");

            update = _mapper.Map<PersonDto, Person>(person, update);
            await _personRepository.EditarPessoa(update);
            return ResultService.OK("Edição Feita com Sucesso.");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var deletar = await _personRepository.BuscarPessoaById(id);
            if (deletar == null) return ResultService.Fail("Pessoa Não Encontrada");
            await _personRepository.DeletarPessoa(deletar);
            return ResultService.OK($"Pessoa do ID:{id} foi Deletada.");
        }

        public async Task<ResultService<PagedBaseResponseDto<PersonDto>>> GetPage(PersonFilter personFilter)
        {
            var peoplePaged = await _personRepository.GetPaged(personFilter);
            var result = new PagedBaseResponseDto<PersonDto>(peoplePaged.TotalRegisters, _mapper.Map<List<PersonDto>>(peoplePaged.Data));
            return ResultService.OK(result);
        }
    }
}
