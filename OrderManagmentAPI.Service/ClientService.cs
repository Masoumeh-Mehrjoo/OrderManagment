using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Model.Repository;
using OrderManagmentAPI.Repository;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service
{
    public class ClientService : IClientService
    {
        IClientRepository _iclientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._iclientRepository = clientRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public IEnumerable<ClientDto> AllRows()
        {
            try
            {
                var Rep_Clients = _iclientRepository.AllRows();
                var Clients = new List<ClientDto>();

                var ClientsToReturn = _mapper.Map<IEnumerable<ClientDto>>(Rep_Clients);
                return (ClientsToReturn);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ClientDto FindById(int Id)
        {
            var Rep_Client = _iclientRepository.findbyId(Id);
            var ClientToReturn = _mapper.Map<ClientDto>(Rep_Client);
            return (ClientToReturn);
        }

        public ClientDto InsertClient(ClientForCreationDto Client)
        {
            try
            {
                var ClientRep = _mapper.Map<Model.Client>(Client);
                _iclientRepository.Insert(ClientRep);

                var ClientToReturn = _mapper.Map<ClientDto>(ClientRep);
                return ClientToReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ClientDto> SearchedRows(ClientResourceParameter ClientResourceParameter)
        {
            var Rep_Client = _iclientRepository.SearchedRows(ClientResourceParameter);
            var ClientToReturn = _mapper.Map<IEnumerable<ClientDto>>(Rep_Client);
            return (ClientToReturn);
        }
        public void DeleteClient(int Id)
        {
            _iclientRepository.Delete(Id);

        }

        public void EditClient(int Id, JsonPatchDocument<ClientForUpdateDto> patchDocument)
        {
            try
            {
                var Client = _iclientRepository.findbyId(Id);

                var ClientTopatch = _mapper.Map<ClientForUpdateDto>(Client);
                patchDocument.ApplyTo(ClientTopatch);

                _mapper.Map(ClientTopatch, Client);
                _iclientRepository.Edit(Client);

                _iclientRepository.Save();
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }
    }
}
