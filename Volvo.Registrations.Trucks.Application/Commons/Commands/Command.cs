using MediatR;
using Microsoft.Extensions.Logging;
using Volvo.Registrations.Trucks.Adapters.PersistencyGateway.Commons;
using Volvo.Registrations.Trucks.Application.Abstractions.Commons.Commands;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Entities;
using Volvo.Registrations.Trucks.BusinessModels.Abstractions.Common.Events;

namespace Volvo.Registrations.Trucks.Application.Commons.Commands;

public abstract class Command<TCommand, TRequirement, TResult, TIBusinessModel, TResultadoDaManipulacaoDosModelosDeNegocio, IIBusinessModelPersistencyGateway>
        : ICommand<TRequirement, TResult>
        where TIBusinessModel : IBusinessModel
        where IIBusinessModelPersistencyGateway : IPersistencyGateway<TIBusinessModel>
{
    protected readonly IUnitOfWork UnitOfWork;
    protected readonly ILogger<TCommand> Logger;
    protected readonly IMediator Mediator;
    protected readonly IIBusinessModelPersistencyGateway DataAccessGateway;
    protected readonly IDomainEventsPersistencyGateway DomainEventsPersistencyGateway;


    private Command() { }
    protected Command(
        IUnitOfWork unitOfWork,
        ILogger<TCommand> logger,
        IMediator mediator,
        IDomainEventsPersistencyGateway domainEvents,
        IIBusinessModelPersistencyGateway dataAccessGateway
    )
    {
        UnitOfWork = unitOfWork;
        Logger = logger;
        Mediator = mediator;
        DomainEventsPersistencyGateway = domainEvents;
        DataAccessGateway = dataAccessGateway;
    }

    public virtual async Task<TResult> Execute(TRequirement requisito)
    {
        try
        {
            ManipuleModelosDoNegocioDTO.Resultado resultadoDaManipulacaoDosModelosDeNegocio;
            List<IDomainEvent> events;

            try { resultadoDaManipulacaoDosModelosDeNegocio = await ManipuleModelosDoNegocio(requisito); }
            catch (Exception ex) { throw new Exception($"Falha ao manipular os modelos de negócio!", ex); }

            try { events = PrepararEventosParaPublicar(new(requisitoDoComando: requisito, resultadoDaManipulacaoDosModelosDeNegocio)); }
            catch (Exception ex) { throw new Exception($"Falha ao preparar eventos para publicar!", ex); }

            // TODO: Pensar melhor essa parte de salvar as alterações e publicar os eventos. uma vez que conseguiu salvar e deu erro ao publicar os eventos ficamos com uma falha
            try
            {
                UnitOfWork.BeginTransaction();
                await SalveAlteracoes(resultadoDaManipulacaoDosModelosDeNegocio);
                await DomainEventsPersistencyGateway.RegisterMany(events);
                await UnitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao salvar alterações!", ex);
            }

            try { foreach (var @event in events) await Mediator.Publish(@event); }
            catch (Exception ex) { throw new Exception($"Falha ao publicar eventos!", ex); }

            try { return await FormatarResultado(new(requisito, events, resultadoDaManipulacaoDosModelosDeNegocio)); }
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
    protected abstract Task<ManipuleModelosDoNegocioDTO.Resultado> ManipuleModelosDoNegocio(TRequirement requisito);

    /// <summary>
    /// Realiza as alterações no banco de dados dentro de uma transação!
    /// Deve-se evitar ao máximo alterações dentro desse método
    /// É um método somente para chamar as alterações do repositório
    /// </summary>
    /// <param name="aggreggate">Agregado já alterado recebido do ManipulateEntityAction!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns></returns>
    protected abstract Task SalveAlteracoes(ManipuleModelosDoNegocioDTO.Resultado requisito);

    /// <summary>
    /// Obtem o evento de domínio que será salvo junto com  as ManipulateEntityRepositoryAction!
    /// </summary>
    /// <param name="requirement">Requisito do comando!</param>
    /// <param name="aggreggate">Agregado já alterado recebido do ManipulateEntityAction!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns>Evento de Domínio a ser salvo</returns>
    protected abstract List<IDomainEvent> PrepararEventosParaPublicar(PrepararEventosParaPublicarDTO.Requisito requisito);

    /// <summary>
    /// Obtem o evento de domínio que será salvo junto com  as ManipulateEntityRepositoryAction!
    /// </summary>
    /// <param name="requirement">Requisito do comando!</param>
    /// <param name="eventCreated">Evento de domínio que foi criado!</param>
    /// <param name="extras">Lista Extra de objetos recebida do ManipulateEntityAction!</param>
    /// <returns>Resultado a ser devolvido para a requisição</returns>
    protected abstract Task<TResult> FormatarResultado(FormatarResultadoDTO.Requisito requisito);

    protected abstract class ManipuleModelosDoNegocioDTO
    {
        public class Resultado
        {
            public TResultadoDaManipulacaoDosModelosDeNegocio ResultadoDaManipulacaoDosModelosDeNegocio { get; private set; }
            public object[]? Extras { get; private set; }

            public Resultado(
                TResultadoDaManipulacaoDosModelosDeNegocio resultadoDaManipulacaoDosModelosDeNegocio,
                object[]? extras = null
            )
            {
                ResultadoDaManipulacaoDosModelosDeNegocio = resultadoDaManipulacaoDosModelosDeNegocio;
                Extras = extras;
            }
        }
    }

    protected abstract class PrepararEventosParaPublicarDTO
    {
        public class Requisito
        {
            public TRequirement RequisitoDoComando { get; private set; }
            public TResultadoDaManipulacaoDosModelosDeNegocio ResultadoDaManipulacaoDosModelosDeNegocio { get; private set; }
            public object[]? Extras { get; private set; }

            public Requisito(TRequirement requisitoDoComando, ManipuleModelosDoNegocioDTO.Resultado resultadoDaManipulacaoDosModelosDeNegocio)
            {
                RequisitoDoComando = requisitoDoComando;
                ResultadoDaManipulacaoDosModelosDeNegocio = resultadoDaManipulacaoDosModelosDeNegocio.ResultadoDaManipulacaoDosModelosDeNegocio;
                Extras = resultadoDaManipulacaoDosModelosDeNegocio.Extras;
            }
        }
    }

    protected abstract class FormatarResultadoDTO
    {
        public class Requisito
        {
            public TRequirement RequisitoDoComando { get; private set; }
            public TResultadoDaManipulacaoDosModelosDeNegocio ResultadoDaManipulacaoDosModelosDeNegocio { get; private set; }
            public object[]? Extras { get; private set; }
            public List<IDomainEvent> EventosPublicados { get; private set; }

            public Requisito(TRequirement requisitoDoComando, List<IDomainEvent> eventosPublicados, ManipuleModelosDoNegocioDTO.Resultado resultadoDaManipulacaoDosModelosDeNegocio)
            {
                RequisitoDoComando = requisitoDoComando;
                ResultadoDaManipulacaoDosModelosDeNegocio = resultadoDaManipulacaoDosModelosDeNegocio.ResultadoDaManipulacaoDosModelosDeNegocio;
                Extras = resultadoDaManipulacaoDosModelosDeNegocio.Extras;
                EventosPublicados = eventosPublicados;
            }
        }
    }
}

public abstract class Command<TCommand, TRequirement, TResult, TIEntity, IIBusinessModelPersistencyGateway>
    : Command<TCommand, TRequirement, TResult, TIEntity, TIEntity, IIBusinessModelPersistencyGateway>
    where TIEntity : IBusinessModel
    where IIBusinessModelPersistencyGateway : IPersistencyGateway<TIEntity>
{
    protected Command(IUnitOfWork unitOfWork, ILogger<TCommand> logger, IMediator mediator, IDomainEventsPersistencyGateway domainEvents, IIBusinessModelPersistencyGateway dataAccessGateway)
        : base(unitOfWork, logger, mediator, domainEvents, dataAccessGateway)
    {
    }
}