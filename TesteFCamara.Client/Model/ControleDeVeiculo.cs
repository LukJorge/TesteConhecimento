﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TesteFCamara.Client.Model
{
    class ControleDeVeiculo
    {
        public int ID { get; set; }
        public Veiculo Veiculo { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
