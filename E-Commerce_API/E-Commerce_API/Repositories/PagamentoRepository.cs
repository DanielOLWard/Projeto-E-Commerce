using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_API.Repositories
{
    // 1 - Herdar a interface
    // 2 - Implementar a interface
    // 3 - Injetar o contexto
    public class PagamentoRepository : IPagamentoRepository
    {
        // Injetar o Context
        // Injecao de Dependencia
        private readonly EcommerceContext _context;

        // ctor <Cria o metodo abaixo>
        // Metodo construtor - Metodo que tem o mesmo nome da classe
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pagamento pagamento)
        {
            // Encontro o pagamento que desejo atualizar
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            // Tratamento de erro
            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            // Muda os dados um por um
            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.StatusPagamento = pagamento.StatusPagamento;
            pagamentoEncontrado.DataPagamento = pagamento.DataPagamento;

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public Pagamento BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);// Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o IdProduto igual ao id
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando for mudar algo no Banco de Dados
        }

        public void Deletar(int id)
        {
            // 1 - encontrar o que eu quero excluir
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id); // Find - Procura apenas pela chave primaria

            // Tratamento de erro
            if (pagamentoEncontrado == null) { throw new Exception(); }

            // 2 - Caso eu enconte o produto, removo ele
            _context.Pagamentos.Remove(pagamentoEncontrado);

            // 3 - Salvo as alteracoes
            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            // ToList() - Lista varios
            return _context.Pagamentos
                .Include(p => p.IdPedidoNavigation)
                .ToList();
        }
    }
}
