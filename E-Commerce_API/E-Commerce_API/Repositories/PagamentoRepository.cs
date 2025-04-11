using E_Commerce_API.Context;
using E_Commerce_API.Interfaces;
using E_Commerce_API.Models;

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
        // Metodo construtor
        public PagamentoRepository(EcommerceContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pagamento pagamento)
        {
            throw new NotImplementedException();
        }

        public Pagamento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.ToList();
        }
    }
}
