using System;
using Xunit;
using NewTalents;
using System.Collections.Generic;

namespace TestNewTalents
{
	public class UnitTest1
	{
			public Calculadora construirClasse()
		{
			string data = "01/02/2020";
			Calculadora calc = new Calculadora(data);
			 
			return calc;
		}

		[Theory]
		[InlineData(1, 2, 3)]
		[InlineData(4, 5, 9)]
		public void TesteSomar(int val1, int val2, int resultado)
		{
			Calculadora calc = construirClasse();

			int resultadoCalculadora = calc.somar(val1, val2);

			Assert.Equal(resultado, resultadoCalculadora);
		}

		[Theory]
		[InlineData(1, 2, -1)]
		[InlineData(4, 5, -1)]
		public void TesteSubtrair(int val1, int val2, int resultado)
		{
			Calculadora calc = construirClasse();

			int resultadoCalculadora = calc.subtrair(val1, val2);

			Assert.Equal(resultado, resultadoCalculadora);
		}

		[Theory]
		[InlineData(1, 2, 2)]
		[InlineData(4, 5, 20)]
		public void TesteMultiplicar(int val1, int val2, int resultado)
		{
			Calculadora calc = construirClasse();

			int resultadoCalculadora = calc.multiplicar(val1, val2);

			Assert.Equal(resultado, resultadoCalculadora);
		}

		[Theory]
		[InlineData(2, 2, 1)]
		[InlineData(25, 5, 5)]
		public void TesteDividir(int val1, int val2, int resultado)
		{
			Calculadora calc = construirClasse();

			int resultadoCalculadora = calc.dividir(val1, val2);

			Assert.Equal(resultado, resultadoCalculadora);
		}

		[Fact]
		public void TestarDivisaoPorZero()
		{
			Calculadora calc = construirClasse();

			Assert.Throws<DivideByZeroException>(
				() => calc.dividir(3, 0)
				);
		}

		[Fact]
		public void TestarHistorico()
		{
			Calculadora calc = construirClasse();

			calc.somar(1, 2);
			calc.somar(1, 3);
			calc.somar(2, 2);
			calc.somar(1, 5);
			calc.somar(5, 2);
			calc.somar(7, 2);

			var historicoCalculadora = calc.historico();
			List<string> resultado = new List<string> {"Res: 9", "Res: 7", "Res: 6"};

			Assert.Equal(resultado, historicoCalculadora); 
		}
	}
}
