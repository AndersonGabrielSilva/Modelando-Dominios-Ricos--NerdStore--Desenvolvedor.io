using System;
using FluentValidation.Results;
using MediatR;

namespace NerdStore.Core.Messages
{
    /// <summary>
    /// Classe base dos meus comandos
    /// <para>[IRequest<TResult>] - MediatR - É Responsavel para informar que será uma mensagem do tipo Request</para>
    /// <para>IRequest<TResult>Isto será uma mensagem do tipo request e o que irá retornar depois deste request</para>
    /// </summary>
    public abstract class Command : Message, IRequest<bool> //IRequest => Utilizada pelo MediatR
    {
        //Carimbo de Data
        public DateTime Timestamp { get; private set; }

        //Do FluentValidation, utilizado para validar e retornar uma mensagem 
        //Iremos utilizar para validar o nosso commando
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}