using System;
using System.Collections.Generic;
using AcessoCard.Common;
using AcessoCard.Models;
using AcessoCard.Repository;

namespace AcessoCard.Business
{
    public sealed class UserBus : Base.ICrud<UserMod>
    {
        public void Cadastrar(UserMod item)
        {
            item.Senha = new ControleSenhaUser().CriptografarSenha(item.Senha);
            new UserRep().Cadastrar(item);
        }

        public void Atualizar(UserMod item)
        {
            new UserRep().Atualizar(item);
        }

        public IEnumerable<UserMod> Listar()
        {
            return new UserRep().Listar();
        }

        public void Deletar(int id)
        {
            new UserRep().Deletar(id);
        }

        public UserMod GetById(int id)
        {
            return new UserRep().GetById(id);
        }

        public UserMod GetUser(string emailUsuario)
        {
            return new UserRep().GetUser(emailUsuario);
        }
        public string RecuperarSenhaUsuario(string email)
        {
            var cadastroDb = new UserRep().GetUser(email);
            if (cadastroDb == null) return null;

            var senhaDescriptografada = new ControleSenhaUser().Descriptografar(cadastroDb.Senha);
            return senhaDescriptografada;
        }

         
        public UserMod VerificarUsuario(UserMod usuario)
        {
            usuario.Senha = new ControleSenhaUser().CriptografarSenha(usuario.Senha);
            var user = new UserRep().VerificarUsuario(usuario);
            return user;
        }



        public bool AlterarSenha(string email, string novaSenha, string senhaAntiga)
        {
            var usuario = new UserMod {Email = email, Senha = senhaAntiga};
            var userDb = VerificarUsuario(usuario);
            userDb.Senha = new ControleSenhaUser().CriptografarSenha(novaSenha);
            Atualizar(userDb);
            return true;
        }
    }
}
