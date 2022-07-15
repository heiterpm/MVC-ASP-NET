using System;
using System.Collections.Generic;

namespace app_mvc.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }    
        public int Idade { get; set; }
        public char Genero { get; set; }
        public string Curso { get; set; }
        private List<Aluno> _listaAluno { get; set; }


        public void CriarAluno(){
            try
            {
                 _listaAluno = new List<Aluno>()
            {
                new Aluno(){ Id = 1,Nome= "Heiter1",Idade=29, Genero = 'M', Curso="Ti"},
                new Aluno(){ Id = 2,Nome= "Heiter2",Idade=20, Genero = 'F', Curso="Economia"},
                new Aluno(){ Id = 3,Nome= "Heiter3",Idade=25, Genero = 'M', Curso="Filosofia"},
            };
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public List<Aluno> BuscarAluno()
        {
            try
            {
                return _listaAluno;
            }
            catch (System.Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}