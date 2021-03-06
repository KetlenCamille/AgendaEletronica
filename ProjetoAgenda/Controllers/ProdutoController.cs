﻿using Controllers.Base;
using Controllers.DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ProdutoController : IBaseController<Produto>
    {
        Contexto contexto = new Contexto();

        public Produto BuscarPorId(int idProduto)
        {
            return contexto.Produtos.Find(idProduto);
        }

        public int Cadastrar(Produto produto)
        {
            if(produto == null)
            {
                contexto.Produtos.Add(produto);
                contexto.SaveChanges();
                return 1;
            }
            return 0;
        }
    
        public int Editar(Produto produto)
        {
            if(produto != null)
            {
                contexto.Entry(produto).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
                return 1;
            }
            return 0;
        }

        public void Excluir(int idProduto)
        {
            Produto produtoExcluir = BuscarPorId(idProduto);

            if(produtoExcluir != null)
            {
                contexto.Entry(produtoExcluir).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public IList<Produto> ListarTodos()
        {
            return contexto.Produtos.ToList();
        }

        public IList<Produto> ListarPorNome(string nomeProduto)
        {
            return contexto.Produtos.Where(a => a.descricaoProduto.ToLower() == nomeProduto.ToLower() && a.ativoProduto == true).ToList();
        }

    }
}
