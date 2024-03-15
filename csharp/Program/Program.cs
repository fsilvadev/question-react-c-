// using System;
// class Program
// {
//   static void Main(string[] args)
//   {
//     // Os funcionários de determinada empresa registram suas entradas e saídas em
//     // equipamentos REP (registrador eletrônico de ponto). Esses registros são
//     // salvos na base de dados no seguinte formato:

//     Registro[] listaRegistros = new Registro[14];
//     listaRegistros[0] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "08:01", Funcionario = "João" };
//     listaRegistros[1] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "07:56", Funcionario = "Maria" };
//     listaRegistros[2] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "12:02", Funcionario = "João" };
//     listaRegistros[3] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "12:01", Funcionario = "Maria" };
//     listaRegistros[4] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "13:01", Funcionario = "João" };
//     listaRegistros[5] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "12:59", Funcionario = "Maria" };
//     listaRegistros[6] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "18:02", Funcionario = "João" };
//     listaRegistros[7] = new Registro
//     { Data = new DateTime(2019, 10, 1), Hora = "17:58", Funcionario = "Maria" };
//     listaRegistros[8] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "08:09", Funcionario = "João" };
//     listaRegistros[9] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "12:01", Funcionario = "João" };
//     listaRegistros[10] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "12:54", Funcionario = "João" };
//     listaRegistros[11] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "12:58", Funcionario = "Maria" };
//     listaRegistros[12] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "18:02", Funcionario = "João" };
//     listaRegistros[13] = new Registro
//     { Data = new DateTime(2019, 10, 2), Hora = "18:30", Funcionario = "Maria" };


//     // Você deve criar um novo array que tenha o total de horas
//     // trabalhadas para cada funcionário em cada dia, ordenado por nome do
//     // funcionário e depois por data. Ele deve possuir os seguintes dados:
//     //
//     // [
//     // { funcionario: 'Maria', data: '2019-10-01', total: '09:04' }
//     // { funcionario: 'Maria', data: '2019-10-02', total: '05:32' },
//     // { funcionario: 'João', data: '2019-10-01', total: '09:02' },
//     // { funcionario: 'João', data: '2019-10-02', total: '09:00' }
//     // ];
//   }
// }
// class Registro
// {
//   public DateTime Data;
//   public string Hora;
//   public string Funcionario;

// SOLUÇÃO

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
  static void Main(string[] args)
  {
    Registro[] listaRegistros = new Registro[14];
    listaRegistros[0] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "08:01", Funcionario = "João" };
    listaRegistros[1] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "07:56", Funcionario = "Maria" };
    listaRegistros[2] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "12:02", Funcionario = "João" };
    listaRegistros[3] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "12:01", Funcionario = "Maria" };
    listaRegistros[4] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "13:01", Funcionario = "João" };
    listaRegistros[5] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "12:59", Funcionario = "Maria" };
    listaRegistros[6] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "18:02", Funcionario = "João" };
    listaRegistros[7] = new Registro { Data = new DateTime(2019, 10, 1), Hora = "17:58", Funcionario = "Maria" };
    listaRegistros[8] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "08:09", Funcionario = "João" };
    listaRegistros[9] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "12:01", Funcionario = "João" };
    listaRegistros[10] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "12:54", Funcionario = "João" };
    listaRegistros[11] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "12:58", Funcionario = "Maria" };
    listaRegistros[12] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "18:02", Funcionario = "João" };
    listaRegistros[13] = new Registro { Data = new DateTime(2019, 10, 2), Hora = "18:30", Funcionario = "Maria" };

    var totais = new Dictionary<(string, DateTime), TimeSpan>();

    foreach (var registro in listaRegistros)
    {
      var chave = (registro.Funcionario, registro.Data);
      var tempo = TimeSpan.Parse(registro.Hora);

      if (!totais.ContainsKey(chave)) totais[chave] = TimeSpan.Zero;
      if (totais[chave] == TimeSpan.Zero) totais[chave] += tempo;
      else
      {
        var horaEntrada = totais[chave];
        var horaSaida = tempo;
        totais[chave] = horaSaida - horaEntrada;
      }
    }

    var novoArray = totais.Select(item => new
    {
      Funcionario = item.Key.Item1,
      Data = item.Key.Item2.ToString("yyyy-MM-dd"),
      Total = item.Value.ToString(@"hh\:mm")
    }).OrderByDescending(item => item.Funcionario).ThenBy(item => item.Data).ToArray();


    foreach (var item in novoArray)
    {
      Console.WriteLine($"{{funcionario: '{item.Funcionario}', data: '{item.Data}', total: '{item.Total}'}}");
    }
  }
}

class Registro
{
  public DateTime Data;
  public string Hora;
  public string Funcionario;
}


// Lógica 

// Crio meu dictionary para armazenar minhas chave que é uma combinação de funcionario + data e o value se torna a hora
// Crio um loop para percorrer sobre o vetor,  e crio as variáveis chave e tempo para armazenar os valores atuais do índice do loop
// Faço as validações para garantir de forma automática a identificação de entrada e saída, e no final atribuindo o valor total de trabalho para cada funcionario e data
