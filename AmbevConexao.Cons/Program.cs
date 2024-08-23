
using AmbevConexao.Data.Repository;
using AmbevConexao.Domain.Model;
using AmbevConexao.Domain.Model.Enum;

class Program
{
    static void Main(string[] args)
    {
        //IncluirAluno();
        //var alunos = ConsultarTodosAlunos();

        //if (alunos?.Count > 1)
        //{
        //    AlterarNomeAluno(alunos[0]);
        //    ExcluirAluno(alunos[1].Id);
        //}

        //TesteTurno(Turno.Manha);

        SelecionarTurmaAluno();


    }

    private static void TesteTurno(Turno turno)
    { }
   
    private static void IncluirAluno()
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Incluir(Aluno.NovoAluno("Diana"));
        repoAluno.Incluir(Aluno.NovoAluno("Billy"));
    }

    private static void AlterarNomeAluno(Aluno aluno)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Alterar(aluno.AlterarNome("Diana Golden"));
    }

    private static List<Aluno> ConsultarTodosAlunos()
    {
        var repoAluno = new AlunoRepository();
        return repoAluno.SelecionarTudo();
    }

    private static void ExcluirAluno(int id)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Excluir(id);
    }

    private static void SelecionarTurmaAluno()
    {
        TurmaAlunoRepository repo = new TurmaAlunoRepository();

        var dadosCompletos = repo.SelecionarTudoCompleto();
        var dados = repo.SelecionarTudo();       
        
    }

}