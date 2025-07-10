using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreensProPWA.Shared.Entity
{
    
        public class Training
        {
            public int Id { get; set; }

            public string StaffName { get; set; } = string.Empty;

            public string EquipmentTrainedOn { get; set; } = string.Empty;

            public DateTime TrainingDate { get; set; } = DateTime.Today;

            public int TrainerId { get; set; } 

            public string? TrainerName { get; set; }

            public string? SignatureBase64 { get; set; } // optiona
    }
    
}
