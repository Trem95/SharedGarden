using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interaction.Reservations.Queries.DTO
{
    public class ReservationsVm
    {
        public IList<ReservationDTO> ReservationList { get; set; }
    }
}
