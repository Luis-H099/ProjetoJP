using ProjetoJP;
using ProjetoJP.Data;
using System.Data.SqlClient;


Conexao db = new Conexao();

db.Conectar();

AlunoRepositorio alunoRepositorio = new AlunoRepositorio(db.conn);

int opcoes = 0;

while (opcoes != 5)
{
    opcoes = Menu();
    Console.Clear();
    switch (opcoes)
    {
        case 1:
            CadastrarAluno();
            break;
        case 2:
            var aluno = BuscarAlunoPorId();
            break;
        case 3:
            
            break;
        case 4:
            break;
        case 5:
            Console.WriteLine("ENCERRANDO PROGRAMA....");
            break;
    }
}
Console.ReadKey();

static int Menu()
{
    Console.WriteLine("MENU DE OPÇÕES");
    Console.WriteLine("===================");
    Console.WriteLine("[1] Cadastrar Aluno");
    Console.WriteLine("[2] Consultar Aluno");
    Console.WriteLine("[3] Alterar Dados do Aluno");
    Console.WriteLine("[4] Excluir Aluno");
    Console.WriteLine("[5] Sair");
    int opcoes = int.Parse(Console.ReadLine());
    return opcoes;
}

void CadastrarAluno()
{
    Aluno aluno = new Aluno();

    Console.WriteLine("Preencha os dados solicitados do Aluno");

    Console.WriteLine("Nome Completo");
    aluno.Nome = Console.ReadLine();

    Console.WriteLine("idade");
    aluno.Idade = int.Parse(Console.ReadLine());

    Console.WriteLine("Data de Nascimento (dd/MM/yyyy):");
    aluno.DataNascimento = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

    Console.WriteLine("CPF");
    aluno.Cpf = Console.ReadLine();

    Console.WriteLine("Cep");
    aluno.Cep = Console.ReadLine();

    Console.WriteLine("Endereço");
    aluno.Endereco = Console.ReadLine();

    Console.WriteLine("Número");
    aluno.Numero = Console.ReadLine();

    Console.WriteLine("Bairro");
    aluno.Bairro = Console.ReadLine();

    Console.WriteLine("Cidade");
    aluno.Cidade = Console.ReadLine();

    Console.WriteLine("Estado");
    aluno.Estado = Console.ReadLine();

    Console.WriteLine("Nota1");
    aluno.Nota1 = float.Parse(Console.ReadLine());

    Console.WriteLine("Nota2");
    aluno.Nota2 = float.Parse(Console.ReadLine());

    alunoRepositorio.InserirAluno(db, aluno);
}

Aluno BuscarAlunoPorId()
{
    var id = 1;
    var aluno = alunoRepositorio.BuscarAlunoPorId(id);
    return aluno;
}

string EditarAluno()
{
    Aluno aluno = new Aluno();
    Console.WriteLine("Informe o código do aluno que deseja editar");
    aluno.Id = int.Parse(Console.ReadLine());
    alunoRepositorio.EditarAluno(db, aluno);
    return ("Aluno editado com sucesso");
}





