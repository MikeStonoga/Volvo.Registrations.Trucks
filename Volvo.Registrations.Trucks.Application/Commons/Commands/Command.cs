using MediatR;
using Microsoft.Extensions.Logging;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Application.Commons.Commands;

public abstract class Command<TCommand, TRequirement, TResult, TIBusinessModel, TResultadoDaManipulacaoDosModelosDeNegocio, TIBusinessModelPersistencyGateway>
        : ICommand<TRequirement, TResult>
        where TIBusinessModel : IBusinessModel
        where TIBusinessModelPersistencyGateway : IPersistencyGateway<TIBusinessModel>
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly ILogger<TCommand> Logger;
    protected readonly IMediator Mediator;
    protected readonly TIBusinessModelPersistencyGateway DataPersistencyGateway;
    protected readonly IDomainEventsPersistencyGateway DomainEventsPersistencyGateway;


    private Command() { }
    protected Command(
        IUnitOfWork unitOfWork,
        ILogger<TCommand> logger,
        IMediator mediator,
        IDomainEventsPersistencyGateway domainEvents,
        TIBusinessModelPersistencyGateway dataAccessGateway
    )
    {
        UnitOfWork = unitOfWork;
        Logger = logger;
        Mediator = mediator;
        DomainEventsPersistencyGateway = domainEvents;
        DataPersistencyGateway = dataAccessGateway;
    }

    public virtual async Task<TResult> Execute(TRequirement requirement)
    {
        try
        {
            ManipulateBusinessModelsDTO.Result resultadoDaManipulacaoDosModelosDeNegocio;
            List<IDomainEvent> events;

            try { resultadoDaManipulacaoDosModelosDeNegocio = await ManipulateBusinessModels(requirement); }
            catch (Exception ex) { throw new Exception($"Falha ao manipular os modelos de negócio!", ex); }

            try { events = PrepareEventsForPublishing(new(requisitoDoComando: requirement, resultadoDaManipulacaoDosModelosDeNegocio)); }
            catch (Exception ex) { throw new Exception($"Falha ao preparar eventos para publicar!", ex); }

            // TODO: Pensar melhor essa parte de salvar as alterações e publicar os eventos. uma vez que conseguiu salvar e deu erro ao publicar os eventos ficamos com uma falha
            try
            {
                UnitOfWork.BeginTransaction();
                await SaveChanges(resultadoDaManipulacaoDosModelosDeNegocio);
                await DomainEventsPersistencyGateway.InsertMany(events);
                await UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao salvar alterações!", ex);
            }

            try { foreach (var @event in events) await Mediator.Publish(@event); }
            catch (Exception ex) { throw new Exception($"Falha ao publicar eventos!", ex); }

            try { return await FormatResult(new(requirement, events, resultadoDaManipulacaoDosModelosDeNegocio)); }
            catch (Exception ex) { throw new Exception($"Falha ao formatar resultado!", ex); }
        }
        catch (Exception ex)
        {
            var exception = new Exception($"Ocorreu um erro ao executar o comando {typeof(TCommand).FullName}!", ex);

            Logger.LogError(ex, $"Error on {typeof(TCommand).FullName}.{nameof(Execute)}");

            if (UnitOfWork.HasOpenTransaction)
                await UnitOfWork.Rollback();
            throw exception;
        }
    }

    /// <summary>
    /// Neste método você deve peraparar os objetos e aplicar as alterações em memória!
    /// Recomenda-se que não seja feita alterações no banco através dele!
    /// As alterações no banco devem ser feitas pelo ManipulateEntityRepositoryAction!
    /// </summary>
    /// <param name="requisito">Requisito do commando</param>
    /// <returns>
    /// Retorna um tupla com o aggregado modificado e una lista extra de objetos  que poderão ser usadas nos outros métodos do comando
    /// </returns>
    protected abstract Task<ManipulateBusinessModelsDTO.Result> ManipulateBusinessModels(TRequirement requirement);

    /// <summary>
    /// Realiza as alterações no banco de dados dentro de uma transação!
    /// Deve-se evitar ao máximo alterações dentro desse método
    /// É um método somente para chamar as alterações do repositório
    /// </summary>
    /// <param name="aggreggate">Agregado já alterado recebido do ManipulateEntityAction!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns></returns>
    protected abstract Task SaveChanges(ManipulateBusinessModelsDTO.Result requirement);

    /// <summary>
    /// Obtem o evento de domínio que será salvo junto com  as ManipulateEntityRepositoryAction!
    /// </summary>
    /// <param name="requirement">Requisito do comando!</param>
    /// <param name="aggreggate">Agregado já alterado recebido do ManipulateEntityAction!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns>Evento de Domínio a ser salvo</returns>
    protected abstract List<IDomainEvent> PrepareEventsForPublishing(PrepareEventsForPublishingDTO.Requirement requirement);

    /// <summary>
    /// Obtem o evento de domínio que será salvo junto com  as ManipulateEntityRepositoryAction!
    /// </summary>
    /// <param name="requirement">Requisito do comando!</param>
    /// <param name="eventCreated">Evento de domínio que foi criado!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns>Resultado a ser devolvido para a requisição</returns>
    protected abstract Task<TResult> FormatResult(FormatResultDTO.Requirement requirement);

    protected abstract class ManipulateBusinessModelsDTO
    {
        public class Result
        {
            public TResultadoDaManipulacaoDosModelosDeNegocio BusinessModelManipulationResult { get; private set; }
            public object[]? Extras { get; private set; }

            public Result(
                TResultadoDaManipulacaoDosModelosDeNegocio resultadoDaManipulacaoDosModelosDeNegocio,
                object[]? extras = null
            )
            {
                BusinessModelManipulationResult = resultadoDaManipulacaoDosModelosDeNegocio;
                Extras = extras;
            }
        }
    }

    protected abstract class PrepareEventsForPublishingDTO
    {
        public class Requirement
        {
            public TRequirement RequisitoDoComando { get; private set; }
            public TResultadoDaManipulacaoDosModelosDeNegocio BusinessModelManipulationResult { get; private set; }
            public object[]? Extras { get; private set; }

            public Requirement(TRequirement requisitoDoComando, ManipulateBusinessModelsDTO.Result resultadoDaManipulacaoDosModelosDeNegocio)
            {
                RequisitoDoComando = requisitoDoComando;
                BusinessModelManipulationResult = resultadoDaManipulacaoDosModelosDeNegocio.BusinessModelManipulationResult;
                Extras = resultadoDaManipulacaoDosModelosDeNegocio.Extras;
            }
        }
    }

    protected abstract class FormatResultDTO
    {
        public class Requirement
        {
            public TRequirement RequisitoDoComando { get; private set; }
            public TResultadoDaManipulacaoDosModelosDeNegocio BusinessModelManipulationResult { get; private set; }
            public object[]? Extras { get; private set; }
            public List<IDomainEvent> EventosPublicados { get; private set; }

            public Requirement(TRequirement requisitoDoComando, List<IDomainEvent> eventosPublicados, ManipulateBusinessModelsDTO.Result resultadoDaManipulacaoDosModelosDeNegocio)
            {
                RequisitoDoComando = requisitoDoComando;
                BusinessModelManipulationResult = resultadoDaManipulacaoDosModelosDeNegocio.BusinessModelManipulationResult;
                Extras = resultadoDaManipulacaoDosModelosDeNegocio.Extras;
                EventosPublicados = eventosPublicados;
            }
        }
    }
}

public abstract class Command<TCommand, TRequirement, TResult, TIBusinessModel, TIBusinessModelPersistencyGateway>
    : Command<TCommand, TRequirement, TResult, TIBusinessModel, TIBusinessModel, TIBusinessModelPersistencyGateway>
    where TIBusinessModel : IBusinessModel
    where TIBusinessModelPersistencyGateway : IPersistencyGateway<TIBusinessModel>
{
    protected Command(IUnitOfWork unitOfWork, ILogger<TCommand> logger, IMediator mediator, IDomainEventsPersistencyGateway domainEvents, TIBusinessModelPersistencyGateway dataAccessGateway)
        : base(unitOfWork, logger, mediator, domainEvents, dataAccessGateway)
    {
    }
}