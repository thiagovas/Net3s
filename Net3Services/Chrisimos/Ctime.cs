using System;

namespace Chrisimos
{
    /// <summary>
    /// Classe que representa o tempo.
    /// </summary>
    public struct Ctime
    {
        public short Hora { get; set; }
        public short Minuto { get; set; }
        public short Segundo { get; set; }
        public short Milisegundo { get; set; }
        private string _agora;
        
        /// <summary>
        /// Guarda o horário atual.
        /// </summary>
        public string Agora
        {
            get
            {
                this.Hora = (short)DateTime.Now.Hour;
                this.Minuto = (short)DateTime.Now.Minute;
                this.Segundo = (short)DateTime.Now.Second;
                this.Milisegundo = (short)DateTime.Now.Millisecond;
                this._agora = Hora + ":" + Minuto + ":" + Segundo + ":" + Milisegundo;
                return _agora;
            }
            private set { _agora = value; }
        }

        /// <summary>
        /// Este método retorna um objeto do tipo Ctime que tem a hora atual.
        /// </summary>
        /// <returns>Retorna um objeto do tipo Ctime.</returns>
        public Ctime PegarHoraAtual()
        { 
            Ctime t = new Ctime();
            t.Hora = (short)DateTime.Now.Hour;
            t.Minuto = (short)DateTime.Now.Minute;
            t.Segundo = (short)DateTime.Now.Second;
            t.Milisegundo = (short)DateTime.Now.Millisecond;
            return t;
        }

        public Ctime Parse(string s)
        {
            if (!string.IsNullOrEmpty(s.Trim()))
            {
                Ctime c = new Ctime();
                try
                {
                    c.Hora = short.Parse(s.Substring(0, 2));
                    c.Minuto = short.Parse(s.Substring(3, 2));
                    c.Segundo = short.Parse(s.Substring(6, 2));
                    c.Milisegundo = short.Parse(s.Substring(9, 4));
                    return c;
                }
                catch (FormatException)
                { throw new FormatException("Valor está em um formato incorreto."); }
            }
            else
            { throw new FormatException("Valor está em um formato incorreto."); }
        }
        
        public bool TryParse(string s, out Ctime c)
        {
            c = new Ctime();
            try
            {
                c = this.Parse(s);
                return true;
            }
            catch
            { return false; }
        }
    }
}
