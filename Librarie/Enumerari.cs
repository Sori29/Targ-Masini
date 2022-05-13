using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarie
{
    public class Enumerari
    {
        public enum Culoare
        {
            alb = 1,
            negru = 2,
            galben = 3,
            portocaliu = 4,
            gri = 5,
            rosu = 6,
            verde = 7,
            albastru = 8
        };
        [Flags]
        public enum Optiuni
        {
            aer_conditionat = 1,
            navigatie = 2,
            cutie_automata = 3,
            cutie_manuala = 4,
            ABS = 5,
            ESP = 6,
            Airbaguri = 7,
            camera_bord = 8,
            avetizor_centura_de_siguranta = 9,
            sistem_audio_radio = 10,
            mufa_auxiliara = 11,
            tapiterie_piele = 12,
            tapiterie_textila = 13,
            volan_incalzit = 14,
            geamuri_electrice = 15,
            trapa_electrica = 16
        };
    }
}
